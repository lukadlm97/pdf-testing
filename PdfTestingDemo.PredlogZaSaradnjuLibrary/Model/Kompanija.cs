using System;
using System.Collections.Generic;
using System.Text;

namespace PdfTestingDemo.PredlogZaSaradnjuLibrary
{
    public  class Kompanija
    {
        public int KompanijaId { get; set; }
        public string Naziv { get; set; }
        public IEnumerable<Lokacija> Lokacije { get; set; }
        public IEnumerable<Kontakt> Kontakti { get; set; }

    }
}
