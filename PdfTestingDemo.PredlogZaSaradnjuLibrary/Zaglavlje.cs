﻿using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PdfTestingDemo.PredlogZaSaradnjuLibrary
{
    public class Zaglavlje
    {
        public void DodajZaglavlje(Kompanija kompanija,PdfPage stranica)
        {
            //TODO: create logic
        }
        public void DodajZaglavljeLevo(Kompanija kompanija, PdfPage stranica)
        {
            XGraphics gfx = XGraphics.FromPdfPage(stranica);
            XFont font = new XFont("Times New Roman", 12, XFontStyle.Regular);
            XTextFormatter tf = new XTextFormatter(gfx);


            XRect xRect = new XRect(30, 20, 350, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("Naziv kompanije:"+kompanija.Naziv, font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            xRect = new XRect(30, 35, 350, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("Lokacija kompanije:" + LokacijaHelper(kompanija.Lokacije), font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            xRect = new XRect(30, 50, 350, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("Kontakti kompanije:" + KontakHelper(kompanija.Kontakti), font, XBrushes.Black, xRect, XStringFormats.TopLeft);
        }

        private string LokacijaHelper(IEnumerable<Lokacija> lokacije)
        {
            Lokacija trenutnaLokacija = lokacije.LastOrDefault();

            if (trenutnaLokacija == null)
                return "Nedostupna lokacija za kompaniju.";

            return " grad: "+ trenutnaLokacija.Grad.Naziv+" ul. "+trenutnaLokacija.NazivUlice+" br."+trenutnaLokacija.Broj+" sprat:"+trenutnaLokacija.Sprat+" stan:"+trenutnaLokacija.Vrata;
        }

        private string KontakHelper(IEnumerable<Kontakt> kontakti)
        {
            Kontakt email = kontakti.FirstOrDefault(k => 
                                    k.VrstaKontakta.NazivVrsteKontakta.ToLower() == "email");

            Kontakt fiksniTel = kontakti.FirstOrDefault(k=>
                                    k.VrstaKontakta.NazivVrsteKontakta.ToLower()=="fiksni");

            if(email == null && fiksniTel == null)
            {
                return "Za kompaniju ne postoje kontakti!";
            }
            if(email == null)
            {
                return "Fiksni telefon: " + fiksniTel.Sadrzaj;
            }
            if(fiksniTel == null)
            {
                return "Email: " +email.Sadrzaj;
            }
            return " Fiksni telefon: " + fiksniTel.Sadrzaj+ "  Email:" + email.Sadrzaj;
        }

        public void DodajZaglavljeDesno(Kompanija kompanija, PdfPage stranica)
        {
            XGraphics gfx = XGraphics.FromPdfPage(stranica);
            XFont font = new XFont("Times New Roman", 12, XFontStyle.Regular);
            XTextFormatter tf = new XTextFormatter(gfx);

            XRect xRect = new XRect(230, 20, 350, 220);
            tf.Alignment = XParagraphAlignment.Right;
            tf.DrawString("Naziv kompanije:" + kompanija.Naziv, font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            xRect = new XRect(230, 35, 350, 220);
            tf.Alignment = XParagraphAlignment.Right;
            tf.DrawString("Lokacija kompanije:" + LokacijaHelper(kompanija.Lokacije), font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            xRect = new XRect(230, 50, 350, 220);
            tf.Alignment = XParagraphAlignment.Right;
            tf.DrawString("Kontakti kompanije:" + KontakHelper(kompanija.Kontakti), font, XBrushes.Black, xRect, XStringFormats.TopLeft);


        }
        public void DodajSlikuUZaglavlje(Kompanija kompanija, PdfPage stranica)
        {
            //TODO: create logic
        }
    }
}
