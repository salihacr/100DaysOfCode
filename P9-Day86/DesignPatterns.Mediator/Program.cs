using System;

namespace DesignPatterns.Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Nakliye nakliye = new Nakliye();
            XFirma xFirma = new XFirma(nakliye);
            YFirma yFirma = new YFirma(nakliye);
            ZFirma zFirma = new ZFirma(nakliye);

            nakliye.XFirma = xFirma;
            nakliye.YFirma = yFirma;
            nakliye.ZFirma = zFirma;

            xFirma.NakliyeyeBasla();

            Console.ReadKey();
        }
    }
}
