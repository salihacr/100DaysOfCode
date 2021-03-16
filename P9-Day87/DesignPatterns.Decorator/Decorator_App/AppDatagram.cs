using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Decorator.Decorator_App
{
    public class AppDatagram : IDatagram
    {
        public void Send()
        {
            Console.WriteLine("IP datagram gönder.");
        }
    }
}
