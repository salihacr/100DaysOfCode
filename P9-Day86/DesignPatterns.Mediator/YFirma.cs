using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Mediator
{
    public class YFirma : Firma
    {
        public YFirma(INakliye nakliye) : base(nakliye)
        {

        }
        public override void NakliyeyeBasla()
        {
            Console.WriteLine("Sivas'tan eşyalar yüklendi.");
            _nakliye.MaliDevret(this);
        }
    }
}
