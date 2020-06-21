using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PdfTestingDemo.PredlogZaSaradnjuLibrary
{
    public class HelperClass
    {
        static HelperClass _instance;

        private HelperClass()
        {

        }

        public static HelperClass Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HelperClass();
                return _instance;
            }
        }

        public string IspisiKontakt(Kontakt kontakt)
        {
            return kontakt.Sadrzaj+" ("+kontakt.VrstaKontakta.NazivVrsteKontakta+")";
        }

        public string LokacijaHelper(IEnumerable<Lokacija> lokacije)
        {
            Lokacija trenutnaLokacija = lokacije.LastOrDefault();

            if (trenutnaLokacija == null)
                return "Nedostupna lokacija za kompaniju.";

            return " grad: " + trenutnaLokacija.Grad.Naziv + " ul. " + trenutnaLokacija.NazivUlice + " br." + trenutnaLokacija.Broj + " sprat:" + trenutnaLokacija.Sprat + " stan:" + trenutnaLokacija.Vrata;
        }
    }
}
