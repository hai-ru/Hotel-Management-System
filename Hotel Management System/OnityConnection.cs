using Onity.HT24;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System
{
    internal class OnityConnection
    {
        public Boolean createCard(string room,DateTime endDate)
        {
            try
            {
                string IP = Properties.Settings.Default.OnityIP;
                int port = int.Parse(Properties.Settings.Default.OnityPort);

                using (var client = new Client(IP, port))
                {

                    endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 14, 0, 0);

                    var writeData = new WriteData
                    {
                        EncoderNumber = 1,
                        Room1 = room,
                        InitialDateTime = DateTime.Today,
                        FinalDateTime = endDate
                    };

                    var uid = client.Write(writeData);
                    Console.WriteLine($"Written on {uid} tag");

                    Console.WriteLine("Read ... ");

                    var readData = new ReadData
                    {
                        EncoderNumber = 1,
                        ExpellingType = EjectionType.E
                    };

                    var read = client.Read(readData);
                    Console.WriteLine($"Room {read.Room1} {read.Uid}");
                    return true;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public Boolean checkoutCard(string room)
        {
            try
            {
                string IP = Properties.Settings.Default.OnityIP;
                int port = int.Parse(Properties.Settings.Default.OnityPort);

                using (var client = new Client(IP, port))
                {
                    CheckoutData data = new CheckoutData
                    {
                        EncoderNumber = 1,
                        Room = room,
                    };
                    client.Checkout(data);
                    return true;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }
        
        public string readCard()
        {
            try
            {
                string IP = Properties.Settings.Default.OnityIP;
                int port = int.Parse(Properties.Settings.Default.OnityPort);

                using (var client = new Client(IP, port))
                {
                    var readData = new ReadData
                    {
                        EncoderNumber = 1,
                        ExpellingType = EjectionType.E
                    };

                    var read = client.Read(readData);
                    Console.WriteLine($"Room {read.Room1} {read.Uid}");
                    return read.Room1;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return "";
            }
        }
    }
}
