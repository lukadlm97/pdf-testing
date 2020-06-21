using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PdfTestingDemo.PredlogZaSaradnjuLibrary
{
    public class PostavljacDatuma
    {
        public void PostaviEvropskiDatum(DateTime datum,PdfPage stranica)
        {
            XGraphics gfx = XGraphics.FromPdfPage(stranica);
            XFont font = new XFont("Times New Roman", 12, XFontStyle.Regular);
            XTextFormatter tf = new XTextFormatter(gfx);

            XRect xRect = new XRect(60, 690, 350, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("U Beogradu, " +datum.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)+" godine", 
                font, XBrushes.Black, xRect, XStringFormats.TopLeft);

        }
        public void PostaviUSADatum(DateTime datum, PdfPage stranica)
        {
            XGraphics gfx = XGraphics.FromPdfPage(stranica);
            XFont font = new XFont("Times New Roman", 12, XFontStyle.Regular);
            XTextFormatter tf = new XTextFormatter(gfx);
            
            XRect xRect = new XRect(60, 690, 350, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("U Beogradu, " + datum.ToString("d") + " godine",
                font, XBrushes.Black, xRect, XStringFormats.TopLeft);
        }
        public void PostaviSaTackomDatum(DateTime datum, PdfPage stranica)
        {
            XGraphics gfx = XGraphics.FromPdfPage(stranica);
            XFont font = new XFont("Times New Roman", 12, XFontStyle.Regular);
            XTextFormatter tf = new XTextFormatter(gfx);

            XRect xRect = new XRect(60, 690, 350, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("U Beogradu, " + datum.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture) + ". godine",
                font, XBrushes.Black, xRect, XStringFormats.TopLeft);

        }
    }
}
