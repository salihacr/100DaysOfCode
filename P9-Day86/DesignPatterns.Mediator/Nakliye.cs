using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Mediator
{
    public class Nakliye : INakliye
    {
        XFirma _xFirma;
        YFirma _yFirma;
        ZFirma _zFirma;
        public XFirma XFirma { set => _xFirma = value; }
        public YFirma YFirma { set => _yFirma = value; }
        public ZFirma ZFirma { set => _zFirma = value; }
        public void MaliDevret(Firma firma)
        {
            if (firma is XFirma)
            {
                Console.WriteLine("Eşyalar Sivas'ta tekrar nakledilmek üzere indirildi.");
                _yFirma.NakliyeyeBasla();
            }
            else if (firma is YFirma)
            {
                Console.WriteLine("Eşyalar Ankara'da tekrar nakledilmek üzere indirildi.");
                _zFirma.NakliyeyeBasla();
            }
            else
            {
                Console.WriteLine("Eşyalar Edirne'ye vardı çok şükür...");
            }
        }
    }
}
