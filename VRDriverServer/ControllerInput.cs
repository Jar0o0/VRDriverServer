using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HidSharp;

namespace VRDriverServer
{
    public class ControllerInput
    {
        HidDevice lJoy;
        HidDevice rJoy;
        static byte packetCounter = 0;
        public Joycon rightJoycon;
        public Joycon leftJoycon;
        public void Initialize()
        {
            rightJoycon = new Joycon();
            leftJoycon = new Joycon();
            rightJoycon.Initialize();
            leftJoycon.Initialize();
            var list = DeviceList.Local;

            lJoy = list.GetHidDevices(0x057E, 0x2006).FirstOrDefault();
            rJoy = list.GetHidDevices(0x057E, 0x2007).FirstOrDefault();

            if(lJoy == null && rJoy == null)
            {
                MessageBox.Show("No Joycons found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(lJoy == null || rJoy == null)
            {
                MessageBox.Show("Only one joycon found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Task t1 = Task.Run(() => InitAndReadJoyCon(lJoy, "Left"));
            Task t2 = Task.Run(() => InitAndReadJoyCon(rJoy, "Right"));
        }

        void InitAndReadJoyCon(HidDevice joycon, string name)
        {
            if (!joycon.TryOpen(out HidStream stream))
            {
                Console.WriteLine($"{name} Joy-Con failed to open.");
                return;
            }

            void SendSubCommand(byte subcommand, byte[] data)
            {
                byte[] buf = new byte[49];
                buf[0] = 0x01; // Output report ID
                buf[1] = packetCounter++;
                buf[10] = subcommand;
                Array.Copy(data, 0, buf, 11, data.Length);

                stream.Write(buf);
            }

            void SendSpiWrite(byte address, byte value)
            {
                byte[] buf = new byte[49];
                buf[0] = 0x01; // Output report ID
                buf[1] = packetCounter++;
                buf[10] = 0x10; // SPI write subcommand

                // SPI write format: 0x00 (write), addr_high, addr_low, data_byte
                buf[11] = 0x00;             // SPI write
                buf[12] = 0x00;             // High byte of address (0x00 for IMU registers)
                buf[13] = address;          // Low byte of register address
                buf[14] = value;            // Data to write

                stream.Write(buf, 0, buf.Length);
            }

            SendSpiWrite(0x1B, 0x00);
            Thread.Sleep(100);
            SendSpiWrite(0x1C, 0x00);
            Thread.Sleep(100);


            SendSubCommand(0x80, new byte[] { 0x01 }); // Handshake
            Thread.Sleep(100);

            SendSubCommand(0x40, new byte[] { 0x01 }); // Enable IMU
            Thread.Sleep(100);

            SendSubCommand(0x03, new byte[] { 0x30 }); // Set report mode to 0x30
            Thread.Sleep(100);
            
            byte[] buffer = new byte[joycon.MaxInputReportLength];

            Console.WriteLine($"{name} Joy-Con IMU enabled. Reading...");

            while (true)
            {
                try
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read > 0 && buffer[0] == 0x30)
                    {
                        int[] rightBuffer = new int[3];
                        int[] leftBuffer = new int[3];

                        for (int i = 0; i < 3; i++)
                        {
                            int baseIndex = 13 + i * 12;
                            short gx = BitConverter.ToInt16(buffer, baseIndex + 6);
                            short gy = BitConverter.ToInt16(buffer, baseIndex + 8);
                            short gz = BitConverter.ToInt16(buffer, baseIndex + 10);

                            if(name == "Right")
                            {
                                rightBuffer[0] += gx;
                                rightBuffer[1] += gy;
                                rightBuffer[2] += gz;
                            }
                            else if(name == "Left")
                            {
                                leftBuffer[0] += gx;
                                leftBuffer[1] += gy;
                                leftBuffer[2] += gz;
                            }

                            //Console.WriteLine($"{name} Gyro[{i + 1}]: X={gx} Y={gy} Z={gz}");
                        }

                        short accelX = 0;
                        short accelY = 0;
                        short accelZ = 0;

                        accelX = BitConverter.ToInt16(buffer, 13);
                        accelY = BitConverter.ToInt16(buffer, 15);
                        accelZ = BitConverter.ToInt16(buffer, 17);

                        if(name == "Right")
                        {
                            rightJoycon.accelX = accelX;
                            rightJoycon.accelY = accelY;
                            rightJoycon.accelZ = accelZ;
                        }
                        else if (name == "Left")
                        {
                            leftJoycon.accelX = accelX;
                            leftJoycon.accelY = accelY;
                            leftJoycon.accelZ = accelZ;
                        }

                        rightJoycon.gyroX = (short)(rightBuffer[0] / 3);
                        rightJoycon.gyroY = (short)(rightBuffer[1] / 3);
                        rightJoycon.gyroZ = (short)(rightBuffer[2] / 3);
                        leftJoycon.gyroX = (short)(leftBuffer[0] / 3);
                        leftJoycon.gyroY = (short)(leftBuffer[1] / 3);
                        leftJoycon.gyroZ = (short)(leftBuffer[2] / 3);
                    }
                }
                catch (TimeoutException)
                {
                    Console.WriteLine($"{name} Joy-Con timeout.");
                }
            }
        }
    }
}
