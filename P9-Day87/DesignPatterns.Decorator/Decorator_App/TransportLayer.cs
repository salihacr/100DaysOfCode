using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Decorator.Decorator_App
{
    // Decorator
    class TransportLayer : IDatagram
    {
        readonly IDatagram _dataGram;
        public TransportLayer(IDatagram datagram)
        {
            _dataGram = datagram;
        }
        public virtual void Send()
        {
            _dataGram.Send();
        }
    }
}
