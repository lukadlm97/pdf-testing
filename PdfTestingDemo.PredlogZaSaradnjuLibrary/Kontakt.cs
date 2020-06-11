using System;
using System.Collections.Generic;
using System.Text;

namespace PdfTestingDemo.PredlogZaSaradnjuLibrary
{
    public class Kontakt
    {
        public int KontaktId { get; set; }
        public string Sadrzaj { get; set; }
        public VrstaKontakta VrstaKontakta { get; set; }
    }
}
