using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Text;

namespace PdfTestingDemo.PredlogZaSaradnjuLibrary
{
    public class KomponentaPredlagaca
    {
        public void DodajPredlagaca(Predlagac predlagac,PdfPage stranica)
        {
            XGraphics gfx = XGraphics.FromPdfPage(stranica);
            XFont font = new XFont("Times New Roman", 12, XFontStyle.Regular);
            XTextFormatter tf = new XTextFormatter(gfx);

            XRect xRect = new XRect(350, 660, 350, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("________________________________",
                font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            xRect = new XRect(410, 680, 350, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString("(podnosilac)",
                font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            xRect = new XRect(370, 700, 350, 220);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString(predlagac.Titula+" "+predlagac.Ime+" "+predlagac.Prezime,
                font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            gfx.Dispose();
        }
        public void DodajPozicijuPredlagaca(PdfPage stranica)
        {
            //TODO: create logic
        }
    }
}
