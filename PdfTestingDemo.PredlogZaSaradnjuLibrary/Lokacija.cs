using System;
using System.Collections.Generic;
using System.Text;

namespace PdfTestingDemo.PredlogZaSaradnjuLibrary
{
    public class Lokacija
    {
        public int LokacijaId { get; set; }
        public Grad Grad { get; set; }
        public string NazivUlice { get; set; }
        public int Broj { get; set; }
        public int Sprat { get; set; }
        public int Vrata { get; set; }
    }
}
