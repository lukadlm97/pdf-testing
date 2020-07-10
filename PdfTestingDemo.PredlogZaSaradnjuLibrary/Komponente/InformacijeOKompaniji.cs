using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Text;

namespace PdfTestingDemo.PredlogZaSaradnjuLibrary
{
    public class InformacijeOKompaniji
    {
        public void PostaviInformacije(Kompanija k,PdfPage stranica)
        {
            XGraphics gfx = XGraphics.FromPdfPage(stranica);
            XFont font = new XFont("Times New Roman", 18, XFontStyle.Regular);
            XFont fontBold = new XFont("Times New Roman", 12, XFontStyle.BoldItalic);
            XTextFormatter tf = new XTextFormatter(gfx);
            XRect xRect = new XRect(40, 410, 350, 220);
            tf.Alignment = XParagraphAlignment.Center;
            tf.DrawString("Informacije o kompaniji "+k.Naziv, font, XBrushes.Black, xRect, XStringFormats.TopLeft);
            font = new XFont("Times New Roman", 12, XFontStyle.Regular);
            xRect = new XRect(60, 450, 350, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("Naziv kompanije: ", fontBold, XBrushes.Black, xRect, XStringFormats.TopLeft);
            xRect = new XRect(175, 450, 350, 220);
            tf.DrawString(k.Naziv, font, XBrushes.Black, xRect, XStringFormats.TopLeft);
            xRect = new XRect(60, 465, 350, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("Adresa kompanije: ", fontBold, XBrushes.Black, xRect, XStringFormats.TopLeft);
            xRect = new XRect(175, 465, 350, 220);
            tf.DrawString(HelperClass.Instance.LokacijaHelper(k.Lokacije), font, XBrushes.Black, xRect, XStringFormats.TopLeft);
            xRect = new XRect(60, 480, 350, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("Kontakti kompanije: ", fontBold, XBrushes.Black, xRect, XStringFormats.TopLeft);
            int variableHеigh = 480;
            foreach(Kontakt kontakt in k.Kontakti){
                xRect = new XRect(175, variableHеigh, 350, 220);
                tf.DrawString(HelperClass.Instance.IspisiKontakt(kontakt), font, XBrushes.Black, xRect, XStringFormats.TopLeft);
                variableHеigh += 15;
            }
            gfx.Dispose();
        }
        public void PostaviInformacijeBold(Kompanija k, PdfPage stranica)
        {
            XGraphics gfx = XGraphics.FromPdfPage(stranica);
            XFont font = new XFont("Times New Roman", 18, XFontStyle.Bold);
            XFont fontBold = new XFont("Times New Roman", 12, XFontStyle.Bold);
            XTextFormatter tf = new XTextFormatter(gfx);

            XRect xRect = new XRect(40, 410, 350, 220);
            tf.Alignment = XParagraphAlignment.Center;
            tf.DrawString("Informacije o kompaniji " + k.Naziv, font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            font = new XFont("Times New Roman", 12, XFontStyle.Regular);

            xRect = new XRect(60, 450, 350, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("Naziv kompanije: ", fontBold, XBrushes.Black, xRect, XStringFormats.TopLeft);
            xRect = new XRect(175, 450, 350, 220);
            tf.DrawString(k.Naziv, font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            xRect = new XRect(60, 465, 350, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("Adresa kompanije: ", fontBold, XBrushes.Black, xRect, XStringFormats.TopLeft);
            xRect = new XRect(175, 465, 350, 220);
            tf.DrawString(HelperClass.Instance.LokacijaHelper(k.Lokacije), font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            xRect = new XRect(60, 480, 350, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("Kontakti kompanije: ", fontBold, XBrushes.Black, xRect, XStringFormats.TopLeft);

            int variableHigh = 480;

            foreach (Kontakt kontakt in k.Kontakti)
            {
                xRect = new XRect(175, variableHigh, 350, 220);
                tf.DrawString(HelperClass.Instance.IspisiKontakt(kontakt), font, XBrushes.Black, xRect, XStringFormats.TopLeft);
                variableHigh += 15;
            }

            gfx.Dispose();
        }
        public void PostaviInformacijeItalic(Kompanija k, PdfPage stranica)
        {
            XGraphics gfx = XGraphics.FromPdfPage(stranica);
            XFont font = new XFont("Times New Roman", 18, XFontStyle.Italic);
            XFont fontBold = new XFont("Times New Roman", 12, XFontStyle.BoldItalic);
            XTextFormatter tf = new XTextFormatter(gfx);

            XRect xRect = new XRect(40, 410, 350, 220);
            tf.Alignment = XParagraphAlignment.Center;
            tf.DrawString("Informacije o kompaniji " + k.Naziv, font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            font = new XFont("Times New Roman", 12, XFontStyle.Italic);

            xRect = new XRect(60, 450, 350, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("Naziv kompanije: ", fontBold, XBrushes.Black, xRect, XStringFormats.TopLeft);
            xRect = new XRect(175, 450, 350, 220);
            tf.DrawString(k.Naziv, font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            xRect = new XRect(60, 465, 350, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("Adresa kompanije: ", fontBold, XBrushes.Black, xRect, XStringFormats.TopLeft);
            xRect = new XRect(175, 465, 350, 220);
            tf.DrawString(HelperClass.Instance.LokacijaHelper(k.Lokacije), font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            xRect = new XRect(60, 480, 350, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("Kontakti kompanije: ", fontBold, XBrushes.Black, xRect, XStringFormats.TopLeft);

            int variableHigh = 480;

            foreach (Kontakt kontakt in k.Kontakti)
            {
                xRect = new XRect(175, variableHigh, 350, 220);
                tf.DrawString(HelperClass.Instance.IspisiKontakt(kontakt), font, XBrushes.Black, xRect, XStringFormats.TopLeft);
                variableHigh += 15;
            }

            gfx.Dispose();
        }
       
    }

}
