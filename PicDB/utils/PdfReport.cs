using BIF.SWE2.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PicDB.Layers;
using PicDB.Models;
using PicDB.ViewModels;

namespace PicDB.utils
{
    class PdfReport
    {
        public void CreateReport(string tags)
        {
            BusinessLayer bl = new BusinessLayer();

            Dictionary<string, int> tagDict = bl.GetTagCount();

            string[] tagArray = tags.Split(';');

            for (int i = 0; i < tagArray.Length; i++)
            {
                tagArray[i] = tagArray[i].ToLower();
            }

            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = tags;

            // Create an empty page
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            XFont font = new XFont("Verdana", 10);


            gfx.DrawString("Tag: Count", font, XBrushes.Black,
                new XRect(10, 0, page.Width, 10),
                XStringFormats.TopLeft);

            gfx.DrawString("________", font, XBrushes.Black,
                new XRect(10, 0, page.Width, 10),
                XStringFormats.TopLeft);

            int textHeight = 20;

            if (String.IsNullOrWhiteSpace(tags))
            {
                foreach (KeyValuePair<string, int> valuePair in tagDict)
                {

                    // Draw the text
                    gfx.DrawString(valuePair.Key + ": " + valuePair.Value, font, XBrushes.Black,
                        new XRect(10, textHeight, page.Width, 10),
                        XStringFormats.TopLeft);

                    textHeight += 10;

                }
            }
            else
            {
                foreach (KeyValuePair<string, int> valuePair in tagDict)
                {
                    if (tagArray.Contains((valuePair.Key).ToLower()))
                    {
                        // Draw the text
                        gfx.DrawString(valuePair.Key + ": " + valuePair.Value, font, XBrushes.Black,
                            new XRect(10, textHeight, page.Width, 10),
                            XStringFormats.TopLeft);

                        textHeight += 10;
                    }
                }
            }



            if (String.IsNullOrWhiteSpace(tags))
            {
                document.Save(GlobalInformation.ReportPath + $"\\TagReportFull{DateTime.Now.Ticks}.pdf");
            }
            else
            {
                document.Save(GlobalInformation.ReportPath + $"\\TagReport{DateTime.Now.Ticks}.pdf");
            }

        }

        public void CreateReport(IPictureViewModel picture)
        {
            var report = new PdfDocument();
            var page = report.AddPage();
            var filename = picture.FileName + $"_Report{DateTime.Now.Ticks}.pdf";

            var gfx = XGraphics.FromPdfPage(page);

            if (!File.Exists(picture.FilePath))
            {
                throw new FileNotFoundException();
            }

            var image = XImage.FromFile(picture.FilePath);

            // Print Headline
            var font = new XFont("Times New Roman", 20, XFontStyle.Regular);
            XRect rect = new XRect(20, 20, page.Width - 20, 220);
            gfx.DrawRectangle(XBrushes.White, rect);
            gfx.DrawString(picture.FileName, font, XBrushes.Black, rect, XStringFormats.TopCenter);

            // Print Image
            gfx.DrawImage(image, page.Width / 6, 50, page.Width / 1.5, page.Height / 3);

            // Print EXIF
            double infoYCoord = (rect.Y + page.Width / 1.8);
            double infoHeight = (page.Height -(rect.Height + page.Height / 3) ) / 2; // Get Height that has already been used and only take half of it
            string exifContent = string.Format("{0}\n" +
                                               "{1}: {2}\n" +
                                               "{3}: {4}\n" +
                                               "{5}: {6}\n" +
                                               "{7}: {8}\n" +
                                               "{9}: {10}\n" +
                                               "{11}: {12}\n" +
                                               "{13}: {14}\n" +
                                               "{15}: {16}", 
                                                "EXIF", 
                                                "Make", picture.EXIF.Make,
                                                "FNumber", picture.EXIF.FNumber,
                                                "ExposureTime", picture.EXIF.ExposureTime,
                                                "ISOValue", picture.EXIF.ISOValue,
                                                "ISORating", picture.EXIF.ISORating,
                                                "Flash", picture.EXIF.Flash,
                                                "ExposureProgram", picture.EXIF.ExposureProgram,
                                                "Exp.Pro.Resource", picture.EXIF.ExposureProgramResource
                                                    );
            font = new XFont("Times New Roman", 14, XFontStyle.Regular);
            rect = new XRect(60, infoYCoord, page.Width / 2 - 20, infoHeight);
            XTextFormatter tf = new XTextFormatter(gfx);
            tf.DrawString(exifContent, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            // Print IPTC
            string iptcContent = string.Format("{0}\n" +
                                               "{1}: {2}\n" +
                                               "{3}: {4}\n" +
                                               "{5}: {6}\n" +
                                               "{7}: {8}\n" +
                                               "{9}: {10}\n",
                "IPTC",
                "Keywords", picture.IPTC.Keywords,
                "ByLine", picture.IPTC.ByLine,
                "CopyrightNotice", picture.IPTC.CopyrightNotice,
                "Headline", picture.IPTC.Headline,
                "Caption", picture.IPTC.Caption);

            rect = new XRect(page.Width/2 + 50, infoYCoord, page.Width / 2 - 20, infoHeight);
            tf.DrawString(iptcContent, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            // Print Photographer
            string photographerContent = string.Format("{0}\n" +
                                                       "{1}: {2}\n" +
                                                       "{3}: {4}\n" +
                                                       "{5}: {6}\n",
                                                       "Photographer",
                                                       "Full name", picture.Photographer.FirstName + " " + picture.Photographer.LastName,
                                                       "Birthday", picture.Photographer.BirthDay.ToString(),
                                                       "Notes", picture.Photographer.Notes);

            rect = new XRect(60, infoYCoord + 10*14, page.Width - 100, infoHeight);
            tf.DrawString(photographerContent, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            report.Save(GlobalInformation.ReportPath + "\\" + filename);
        }
    }
}
