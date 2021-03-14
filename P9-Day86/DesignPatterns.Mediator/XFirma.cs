using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Mediator
{
    public class XFirma : Firma
    {
        public XFirma(INakliye nakliye) : base(nakliye)
        {

        }
        public override void NakliyeyeBasla()
        {
            Console.WriteLine("Iğdır'dan eşyalar yüklendi.");
            _nakliye.MaliDevret(this);
        }
    }
}
