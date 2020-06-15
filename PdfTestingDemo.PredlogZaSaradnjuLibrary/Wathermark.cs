using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Text;

namespace PdfTestingDemo.PredlogZaSaradnjuLibrary
{
    public class Wathermark
    {
        public void PostaviWathermark(string nazivKompanije,PdfPage strana)
        {
            XGraphics gfx = XGraphics.FromPdfPage(strana, XGraphicsPdfPageOptions.Prepend);
            XFont font = new XFont("Times New Roman", 26, XFontStyle.Bold);
            XTextFormatter textFormatter = new XTextFormatter(gfx);

            var size = gfx.MeasureString("PDFSharp", font);

            gfx.TranslateTransform(strana.Width / 2, strana.Height / 2);
            gfx.RotateTransform(-Math.Atan(strana.Height / strana.Width) * 180 / Math.PI);
            gfx.TranslateTransform(-strana.Width / 2, -strana.Height / 2);

            var format = new XStringFormat();

            format.Alignment = XStringAlignment.Near;
            format.LineAlignment = XLineAlignment.Near;

            XBrush brush = new XSolidBrush(XColor.FromArgb(128,141,184,224));

            gfx.DrawString(nazivKompanije.ToUpper(),
                font,
                brush,
                new XPoint((strana.Width - size.Width) / 2, (strana.Height - size.Height) / 2), format);
                                                                         

        }
    }
}
