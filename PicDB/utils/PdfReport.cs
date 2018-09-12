using BIF.SWE2.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PicDB.Models;
using PicDB.ViewModels;

namespace PicDB.utils
{
    class PdfReport
    {
        private string _tags;
        public void CreateReport(IPictureListViewModel pictures, string tags)
        {
            _tags = tags;
            var PicturesWithTags = GetFilteredPictureList((PictureListViewModel)pictures, tags);
            CheckTags();
            var report = new PdfDocument();

            foreach (PictureViewModel pictureViewModel in PicturesWithTags)
            {
                if (!File.Exists(pictureViewModel.FilePath))
                {
                    throw new FileNotFoundException();
                }

                var page = report.AddPage();
                var gfx = XGraphics.FromPdfPage(page);
                var image = XImage.FromFile(pictureViewModel.FilePath);

                var font = new XFont("Times New Roman", 20, XFontStyle.Regular);
                XRect rect = new XRect(20, 0, page.Width - 20, 220);
                gfx.DrawRectangle(XBrushes.White, rect);

                gfx.DrawString("Tags: " + _tags, font, XBrushes.Black, rect, XStringFormats.TopCenter);
                gfx.DrawImage(image, 50, 220, page.Width/1.5, page.Height/3);
            }
            var filename = $"Report{DateTime.Now.Ticks}.pdf";
            report.Save(GlobalInformation.ReportPath + "\\" + filename);
        }

        public void CreateReport(IPictureViewModel picture)
        {
            var report = new PdfDocument();
            var page = report.AddPage();
            var filename = $"Report{DateTime.Now.Ticks}.pdf";

            var gfx = XGraphics.FromPdfPage(page);

            if (!File.Exists(picture.FilePath))
            {
                throw new FileNotFoundException();
            }

            var image = XImage.FromFile(picture.FilePath);

            var font = new XFont("Times New Roman", 20, XFontStyle.Regular);
            XRect rect = new XRect(0, 0, 250, 220);
            gfx.DrawRectangle(XBrushes.White, rect);

            gfx.DrawString(picture.FileName, font, XBrushes.Black, rect, XStringFormats.TopCenter);
            gfx.DrawImage(image, 50, 220, 400, 400);

            report.Save(GlobalInformation.ReportPath + "\\" + filename);
        }

        private List<PictureViewModel> GetFilteredPictureList(PictureListViewModel plvm, string tags)
        {
            List<PictureViewModel> filteredPictures = new List<PictureViewModel>();

            //load picture list into new list
            foreach (PictureViewModel picture in plvm.List)
            {
                filteredPictures.Add(picture);
            }

            //get array of Tags
            string[] tagArray = tags.Split(' ');

            //filter list
            foreach (string tag in tagArray)
            {
                foreach (PictureViewModel picture in plvm.List)
                {
                    if (!picture.IPTC.Keywords.Contains(tag) && filteredPictures.Contains(picture))
                    {
                        filteredPictures.Remove(picture);
                    }
                }
            }
            return filteredPictures;
        }

        private void CheckTags()
        {
            if (string.IsNullOrWhiteSpace(_tags))
            {
                _tags = "no tags given, returned full list.";
            }
        }
    }
}
