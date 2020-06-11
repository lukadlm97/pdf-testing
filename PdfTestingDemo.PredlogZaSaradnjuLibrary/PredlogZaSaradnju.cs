using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Text;

namespace PdfTestingDemo.PredlogZaSaradnjuLibrary
{
    public class PredlogZaSaradnju
    {
        public int sifraPredloga { get; set; }
        public string naslov { get; set; }
        public string opisPredloga { get; set; }
        public DateTime datumPredlaganja { get; set; }
        public Kompanija Kompanija { get; set; }
        public PdfDocument dokument { get; set; }


        public PdfDocument KreirajPredlog()
        {
            return null;
        }
        public PdfPage KreirajStranicu(PdfDocument dokument)
        {
            return null;
        }
    }
}
