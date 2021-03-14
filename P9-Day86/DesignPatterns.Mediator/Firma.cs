using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Mediator
{
    public abstract class Firma
    {
        protected INakliye _nakliye;
        protected Firma(INakliye nakliye)
        {
            _nakliye = nakliye;
        }
        public abstract void NakliyeyeBasla();
    }
}
