using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
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


            XRect xRect = new XRect(30, 20, 250, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("Naziv kompanije:"+kompanija.Naziv, font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            xRect = new XRect(30, 35, 250, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("Naziv kompanije:" + kompanija.Naziv, font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            xRect = new XRect(30, 50, 250, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("Naziv kompanije:" + kompanija.Naziv, font, XBrushes.Black, xRect, XStringFormats.TopLeft);

        }
        public void DodajZaglavljeDesno(Kompanija kompanija, PdfPage stranica)
        {
            //TODO: create logic
        }
        public void DodajSlikuUZaglavlje(Kompanija kompanija, PdfPage stranica)
        {
            //TODO: create logic
        }
    }
}
