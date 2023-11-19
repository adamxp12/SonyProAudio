using System;
using System.IO.Ports;
using System.Linq;

namespace ExtendedSerialPort
{
    /*
     * The base SerialPort was driving me nuts. It worked 90% of the time but sometimes packets came in too fast and it merged them together
     * the is no easy way to simply read until the terminator chracter of 0XFF so found a solution
     * 
     * This class was made up from other code some from
     * https://www.vgies.com/a-reliable-serial-port-in-c/ 
     * 
     * but I replaced the ContinuousRead() function as I needed to do something complex 
     * again I found the code I needed on stackoverflow
     * https://stackoverflow.com/questions/38732358/continuously-reading-from-serial-port-asynchronously-properly
     * 
     * Is this the best SerialPort implemention? probably not and any seasoned C# coder reading this file will probably scream
     * but guess what this blooming works. I get every single darn packet as its own event. nothing is lost. and I think its lightweight being async
     * who knows. feel free to belittle me about this mess
     */

    public class ReliableSerialPort : SerialPort
    {
        public ReliableSerialPort(string portName, int baudRate)
        {
            PortName = portName;
            BaudRate = baudRate;
            Handshake = Handshake.None;
            DtrEnable = true;
            NewLine = " ";
            ReceivedBytesThreshold = 1024;
        }

        new public void Open()
        {
            base.Open();
            ContinuousRead();
        }


        private async void ContinuousRead()
        {
            string result = null;
            while (true)
            {
                if (!IsOpen) break;
                byte[] buffer = new byte[1];
                try
                {
                    await BaseStream.ReadAsync(buffer, 0, 1);
                } catch (Exception e)
                {
                    Console.WriteLine("error "+e.Message);
                }
                
                result += BitConverter.ToString(buffer)+"-";

                if (result.EndsWith("FF-"))
                {
                    result = result.Substring(0, result.Length-1);
                    OnDataReceived(result.Split('-').Select(b => Convert.ToByte(b, 16)).ToArray());
                    result = null;
                }
            }
        }

        public delegate void DataReceivedEventHandler(object sender, DataReceivedArgs e);
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public event EventHandler<DataReceivedArgs> DataReceived;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        public virtual void OnDataReceived(byte[] data)
        {
            var handler = DataReceived;
            if (handler != null)
            {
                handler(this, new DataReceivedArgs { Data = data });
            }
        }
    }

    public class DataReceivedArgs : EventArgs
    {
        public byte[] Data { get; set; }
    }
}