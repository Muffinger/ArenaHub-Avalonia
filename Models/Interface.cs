using System;
using System.IO.Ports;
using System.Collections.Generic;

namespace ArenaHub_Avalonia.Models
{
    public class Interface
    {
        private SerialPort serialPort;

        public void OpenPort(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                ClosePort();
            }

            serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            serialPort.Open();
            Console.WriteLine($"Port {portName} geöffnet.");
        }

        public void ClosePort()
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
                Console.WriteLine("Port geschlossen.");
            }
        }

        public List<string> GetAvailablePorts()
        {
            return new List<string>(SerialPort.GetPortNames());
        }
    }
}
