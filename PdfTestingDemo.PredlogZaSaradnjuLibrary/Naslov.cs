﻿using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using System;
using System.Collections.Generic;
using System.Text;

namespace PdfTestingDemo.PredlogZaSaradnjuLibrary
{
    public class Naslov
    {
        public void PostaviVelikNaslov(string naslov,PdfPage stranica)
        {
            XGraphics gfx = XGraphics.FromPdfPage(stranica);
            XFont font = new XFont("Times New Roman", 18, XFontStyle.Regular);
            XTextFormatter tf = new XTextFormatter(gfx);

            XRect xRect = new XRect(170, 100, 350, 220);
            tf.Alignment = XParagraphAlignment.Center;
            tf.DrawString(naslov, font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            gfx.Dispose();
        }
        public void PostaviBoldiranNaslov(string naslov, PdfPage stranica)
        {
            //TODO: create logic
        }
        public void PostaviItalicNaslov(string naslov, PdfPage stranica)
        {
            //TODO: create logic
        }
    }
}
