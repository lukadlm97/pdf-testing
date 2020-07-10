using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Text;

namespace PdfTestingDemo.PredlogZaSaradnjuLibrary
{
    public class Opis
    {
        public void PostaviOpisNewRoman(string opis,PdfPage stranica)
        {
            XGraphics gfx = XGraphics.FromPdfPage(stranica);
            XFont font = new XFont("Times New Roman", 13, XFontStyle.Regular);
            XTextFormatter tf = new XTextFormatter(gfx);

            XRect xRect = new XRect(60, 160, 490, 220);
            tf.Alignment = XParagraphAlignment.Justify;
            tf.DrawString(opis, font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            gfx.Dispose();
        }
        public void PostaviOpisItalic(string opis, PdfPage stranica)
        {
            XGraphics gfx = XGraphics.FromPdfPage(stranica);
            XFont font = new XFont("Times New Roman", 13, XFontStyle.Italic);
            XTextFormatter tf = new XTextFormatter(gfx);

            XRect xRect = new XRect(60, 160, 490, 220);
            tf.Alignment = XParagraphAlignment.Justify;
            tf.DrawString(opis, font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            gfx.Dispose();
        }
        public void PostaviOpisLevoPoravnanje(string opis, PdfPage stranica)
        {
            XGraphics gfx = XGraphics.FromPdfPage(stranica);
            XFont font = new XFont("Times New Roman", 13, XFontStyle.Regular);
            XTextFormatter tf = new XTextFormatter(gfx);

            XRect xRect = new XRect(60, 160, 490, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString(opis, font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            gfx.Dispose();
        }
        public void PostaviOpisJustify(string opis, PdfPage stranica)
        {
            XGraphics gfx = XGraphics.FromPdfPage(stranica);
            XFont font = new XFont("Times New Roman", 13, XFontStyle.Regular);
            XTextFormatter tf = new XTextFormatter(gfx);

            XRect xRect = new XRect(60, 160, 490, 220);
            tf.Alignment = XParagraphAlignment.Justify;
            tf.DrawString(opis, font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            gfx.Dispose();
        }
       
    }
}
