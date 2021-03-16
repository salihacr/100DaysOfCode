using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Decorator.Decorator_App
{
    class UseUDP : TransportLayer
    {
        public UseUDP(IDatagram datagram) : base(datagram) { }
        public void AddUDPHeader()
        {
            Console.WriteLine("UDP protokolü devreye sokuldu.");
        }
        public override void Send()
        {
            AddUDPHeader();
            base.Send();
        }
    }
}
