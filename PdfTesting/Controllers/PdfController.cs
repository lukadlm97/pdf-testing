using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;

namespace PdfTesting.Controllers
{
    public class PdfController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GenerateSimplePdf()
        {
                PdfDocument document = new PdfDocument();
                document.Info.Title = "Created with PDFSharp";

                PdfPage page = document.AddPage();
                XGraphics grf = XGraphics.FromPdfPage(page);
                XFont font = new XFont("Arial", 20, XFontStyle.Regular);
                grf.DrawString("Hello World!", font, XBrushes.Black,
                    new XRect(0, 0, page.Width, page.Height), XStringFormat.Center);

                MemoryStream stream = new MemoryStream();
                document.Save(stream, false);
                stream.Position = 0;

                return File(stream, "application/pdf", "HelloPDF.pdf");
        }

        public IActionResult GeneratePdfA4Page()
        {
            PdfDocument document = new PdfDocument();

            XFont font = new XFont("Times", 25, XFontStyle.Bold);

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            gfx.DrawString("Page 1", font, XBrushes.Black, 20, 50, XStringFormat.Default);

            page.Size = PdfSharp.PageSize.A4;
            page.Orientation = PdfSharp.PageOrientation.Landscape;

            MemoryStream stream = new MemoryStream();

            document.Save(stream, false);
            stream.Position = 0;
            return File(stream, "application/pdf", "A4.pdf");
        }


        public IActionResult GeneratePdfWithMultiPage()
        {
            PdfDocument document = new PdfDocument();
            XFont font = new XFont("Verdana", 16);

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            gfx.DrawString("Page 1", font, XBrushes.Black, 20, 50, XStringFormat.Default);

            PdfOutline outline = document.Outlines.Add("Root", page, true, PdfOutlineStyle.Bold, XColors.Red);

            for (int idx = 2; idx < 5; idx++)
            {
                page = document.AddPage();

                gfx = XGraphics.FromPdfPage(page);
                string text = "Page" + idx;
                gfx.DrawString(text, font, XBrushes.Black, 20, 50, XStringFormats.Default);

                outline.Outlines.Add(text, page, true);
            }


            MemoryStream stream = new MemoryStream();

            document.Save(stream, false);
            stream.Position = 0;
            return File(stream, "application/pdf", "MultiPage.pdf");
        }

        private XRect GetRect(int idx)
        {
            XRect rect = new XRect(0, 0, XUnit.FromCentimeter(21).Point / 3 * 0.9, XUnit.FromCentimeter(29.7).Point / 3 * 0.9);
            rect.X = (idx % 3) * XUnit.FromCentimeter(21).Point / 3 + XUnit.FromCentimeter(21).Point * 0.05 / 3;
            rect.Y = (idx / 3) * XUnit.FromCentimeter(29.7).Point / 3 + XUnit.FromCentimeter(29.7).Point * 0.05 / 3;
            return rect;
        }

        public IActionResult GeneratePdfWithWatermark()
        {
            const string text =
                             "Facin exeraessisit la consenim iureet dignibh eu facilluptat vercil dunt autpat. " +
                             "Ecte magna faccum dolor sequisc iliquat, quat, quipiss equipit accummy niate magna " +
                             "facil iure eraesequis am velit, quat atis dolore dolent luptat nulla adio odipissectet " +
                             "lan venis do essequatio conulla facillandrem zzriusci bla ad minim inis nim velit eugait " +
                             "aut aut lor at ilit ut nulla ate te eugait alit augiamet ad magnim iurem il eu feuissi.\n" +
                             "Guer sequis duis eu feugait luptat lum adiamet, si tate dolore mod eu facidunt adignisl in " +
                             "henim dolorem nulla faccum vel inis dolutpatum iusto od min ex euis adio exer sed del " +
                             "dolor ing enit veniamcon vullutat praestrud molenis ciduisim doloborem ipit nulla consequisi.\n" +
                             "Nos adit pratetu eriurem delestie del ut lumsandreet nis exerilisit wis nos alit venit praestrud " +
                             "dolor sum volore facidui blaor erillaortis ad ea augue corem dunt nis  iustinciduis euisi.\n" +
                             "Ut ulputate volore min ut nulpute dolobor sequism olorperilit autatie modit wisl illuptat dolore " +
                             "min ut in ute doloboreet ip ex et am dunt at.";

            PdfDocument document = new PdfDocument();

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Prepend);
            XFont font = new XFont("Times New Roman", 16, XFontStyle.Bold);
            XTextFormatter tf = new XTextFormatter(gfx);

            XRect xRect = new XRect(40, 40, 250, 220);
            gfx.DrawRectangle(XBrushes.SeaShell, xRect);
            tf.DrawString("Naslov", font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            font = new XFont("Times New Roman", 10, XFontStyle.Bold);

            XRect rect = new XRect(40, 100, 250, 220);
            gfx.DrawRectangle(XBrushes.SeaShell, rect);
            //tf.Alignment = ParagraphAlignment.Left;
            tf.DrawString(text, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            var size = gfx.MeasureString("PDFSharp", font);

            gfx.TranslateTransform(page.Width / 2, page.Height / 2);
            gfx.RotateTransform(-Math.Atan(page.Height / page.Width) * 180 / Math.PI);
            gfx.TranslateTransform(-page.Width / 2, -page.Height / 2);

            var format = new XStringFormat();
            format.Alignment = XStringAlignment.Near;
            format.LineAlignment = XLineAlignment.Near;

            XBrush brush = new XSolidBrush(XColor.FromArgb(128, 255, 0, 0));

            gfx.DrawString("Wathermark", font, brush, new XPoint((page.Width - size.Width) / 2, (page.Height - size.Height) / 2), format);
            MemoryStream stream = new MemoryStream();

            document.Save(stream, false);
            stream.Position = 0;
            return File(stream, "application/pdf", "watermark.pdf");
        }
        public IActionResult GeneretePdfWithGradient()
        {
            var document = new PdfDocument();
            using (document = new PdfDocument())
            {
                var page = document.AddPage();
                var graphics = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Append);

                var bounds = new XRect(graphics.PageOrigin, graphics.PageSize);
                var state = graphics.Save();

                graphics.DrawRectangle(
                    new XLinearGradientBrush(bounds,
                    XColor.FromKnownColor(XKnownColor.Red),
                    XColor.FromKnownColor(XKnownColor.White),
                    XLinearGradientMode.ForwardDiagonal), bounds
                    );
                graphics.Restore(state);
                graphics.DrawString("Hello world",
                    new XFont("Arial", 20),
                    XBrushes.Black,
                    bounds.Center,
                    XStringFormat.Center);

                XPen pen = new XPen(XColors.DarkBlue, 2.5);
                graphics.DrawPie(pen, 10, 0, 100, 90, -120, 75);


                document.Save("test.pdf");
                document.Close();
            }
            MemoryStream stream = new MemoryStream();

            document.Save(stream, false);
            stream.Position = 0;
            return File(stream, "application/pdf", "test.pdf");
        }
        public IActionResult GeneratePdfWithTextAlignment()
        {
            const string text =
                          "Facin exeraessisit la consenim iureet dignibh eu facilluptat vercil dunt autpat. " +
                          "Ecte magna faccum dolor sequisc iliquat, quat, quipiss equipit accummy niate magna " +
                          "facil iure eraesequis am velit, quat atis dolore dolent luptat nulla adio odipissectet " +
                          "lan venis do essequatio conulla facillandrem zzriusci bla ad minim inis nim velit eugait " +
                          "aut aut lor at ilit ut nulla ate te eugait alit augiamet ad magnim iurem il eu feuissi.\n" +
                          "Guer sequis duis eu feugait luptat lum adiamet, si tate dolore mod eu facidunt adignisl in " +
                          "henim dolorem nulla faccum vel inis dolutpatum iusto od min ex euis adio exer sed del " +
                          "dolor ing enit veniamcon vullutat praestrud molenis ciduisim doloborem ipit nulla consequisi.\n" +
                          "Nos adit pratetu eriurem delestie del ut lumsandreet nis exerilisit wis nos alit venit praestrud " +
                          "dolor sum volore facidui blaor erillaortis ad ea augue corem dunt nis  iustinciduis euisi.\n" +
                          "Ut ulputate volore min ut nulpute dolobor sequism olorperilit autatie modit wisl illuptat dolore " +
                          "min ut in ute doloboreet ip ex et am dunt at.";

            PdfDocument document = new PdfDocument();

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Times New Roman", 16, XFontStyle.Bold);
            XTextFormatter tf = new XTextFormatter(gfx);

            XRect xRect = new XRect(40, 40, 250, 220);
            gfx.DrawRectangle(XBrushes.SeaShell, xRect);
            tf.DrawString("Naslov", font, XBrushes.Black, xRect, XStringFormats.TopLeft);

            font = new XFont("Times New Roman", 10, XFontStyle.Bold);

            XRect rect = new XRect(40, 100, 250, 220);
            gfx.DrawRectangle(XBrushes.SeaShell, rect);
            //tf.Alignment = ParagraphAlignment.Left;
            tf.DrawString(text, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            rect = new XRect(310, 100, 250, 220);
            gfx.DrawRectangle(XBrushes.SeaShell, rect);
            tf.Alignment = XParagraphAlignment.Right;
            tf.DrawString(text, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            rect = new XRect(40, 400, 250, 220);
            gfx.DrawRectangle(XBrushes.SeaShell, rect);
            tf.Alignment = XParagraphAlignment.Center;
            tf.DrawString(text, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            rect = new XRect(310, 400, 250, 220);
            gfx.DrawRectangle(XBrushes.SeaShell, rect);
            tf.Alignment = XParagraphAlignment.Justify;
            tf.DrawString(text, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            MemoryStream stream = new MemoryStream();

            document.Save(stream, false);
            stream.Position = 0;
            return File(stream, "application/pdf", "alignment.pdf");
        }

        public IActionResult GeneratePdfWithImage()
        {
            PdfDocument document = new PdfDocument();

            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);
            DrawImage(gfx, "wwwroot/images/photo.jpg", 50, 50, 250, 250);
            MemoryStream stream = new MemoryStream();

            document.Save(stream, false);
            stream.Position = 0;
            return File(stream, "application/pdf", "image.pdf");
        }

        private void DrawImage(XGraphics gfx, string img, int v2, int v3, int v4, int v5)
        {
            gfx.DrawImage(XImage.FromFile(img), v2, v3, v4, v5);
        }

        public IActionResult GenTable()
        {
            const string text =
                              "Facin exeraessisit la consenim iureet dignibh eu facilluptat vercil dunt autpat. " +
                              "Ecte magna faccum dolor sequisc iliquat, quat, quipiss equipit accummy niate magna " +
                              "facil iure eraesequis am velit, quat atis dolore dolent luptat nulla adio odipissectet " +
                              "lan venis do essequatio conulla facillandrem zzriusci bla ad minim inis nim velit eugait " +
                              "aut aut lor at ilit ut nulla ate te eugait alit augiamet ad magnim iurem il eu feuissi.\n" +
                              "Guer sequis duis eu feugait luptat lum adiamet, si tate dolore mod eu facidunt adignisl in " +
                              "henim dolorem nulla faccum vel inis dolutpatum iusto od min ex euis adio exer sed del " +
                              "dolor ing enit veniamcon vullutat praestrud molenis ciduisim doloborem ipit nulla consequisi.\n" +
                              "Nos adit pratetu eriurem delestie del ut lumsandreet nis exerilisit wis nos alit venit praestrud " +
                              "dolor sum volore facidui blaor erillaortis ad ea augue corem dunt nis  iustinciduis euisi.\n" +
                              "Ut ulputate volore min ut nulpute dolobor sequism olorperilit autatie modit wisl illuptat dolore " +
                              "min ut in ute doloboreet ip ex et am dunt at.";

            PdfDocument document = new PdfDocument();
            document.Info.Title = "A simple invoce";
            document.Info.Subject = "Demonstrate how to create an invoce.";
            document.Info.Author = "Luka Radovanovic";

            PdfPage page = document.AddPage();
            page.Size = PdfSharp.PageSize.A4;
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XTextFormatter tf = new XTextFormatter(gfx);

            XFont font = new XFont("Times New Roman", 20, XFontStyle.Bold);
            XRect rect = new XRect(40, 50, 50, 50);
            tf.Alignment = XParagraphAlignment.Center;
            tf.DrawString("Naslov", font, XBrushes.Black, rect, XStringFormats.TopLeft);

            font = new XFont("Times New Roman", 14, XFontStyle.Regular);
            rect = new XRect(40, 100, 500, 500);
            gfx.DrawRectangle(XBrushes.SeaShell, rect);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString(text, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            MemoryStream stream = new MemoryStream();


            document.Save(stream, false);
            stream.Position = 0;
            return File(stream, "application/pdf", "table.pdf");
        }
    }
}