using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Decorator.Decorator_App
{
    // Concrete Decorator
    class UseTCP : TransportLayer
    {
        public UseTCP(IDatagram datagram) : base(datagram) { }
        private void AddTCPHeader()
        {
            Console.WriteLine("TCP Protokolü devreye sokuldu.");
        }
        public override void Send()
        {
            AddTCPHeader();
            base.Send();
        }
    }
}
