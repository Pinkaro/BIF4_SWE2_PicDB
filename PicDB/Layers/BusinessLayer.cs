using BIF.SWE2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.Models;
using System.IO;
using PicDB.Models;
using System.Reflection;
using PicDB.Mocks;
using PicDB.utils;
using PicDB.utils.Exceptions;
using System.Windows.Media.Imaging;

namespace PicDB.Layers
{
    public class BusinessLayer : IBusinessLayer
    {
        /// <summary>
        /// Path to pictures
        /// </summary>
        public string FilePath;
        private MockDataAccessLayer _dal;
        public MockDataAccessLayer MockDal
        {
            get { return _dal;  }
        }

        private static BusinessLayer _instance;
        private static object lazy_lock = new Object();

        public static BusinessLayer Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lazy_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new BusinessLayer();
                            _instance.Sync();
                        }
                    }
                }
                return _instance;
            }
        }

        private BusinessLayer()
        {
            _dal = new MockDataAccessLayer();
            FilePath = AssemblyHelper.PictureFolderPath;
        }

        private BusinessLayer(string path)
        {
            _dal = new MockDataAccessLayer();
            FilePath = path;
        }

        public void DeletePhotographer(int ID)
        {
            throw new NotImplementedException();
        }

        public void DeletePicture(int ID)
        {
            throw new NotImplementedException();
        }

        public IEXIFModel ExtractEXIF(string filename)
        {
            IEnumerable<IPictureModel> pictures = _dal.GetPictures(null, null, null, null);
            IEXIFModel exifModel = null;

            foreach(IPictureModel picture in pictures)
            {
                if (picture.FileName.Equals(filename))
                {
                    exifModel = picture.EXIF;
                }
            }

            if(exifModel == null)
            {
                throw new PictureNotFoundException("\"" + filename + "\" does not exist.");
            }

            return exifModel;
        }

        public IIPTCModel ExtractIPTC(string filename)
        {
            IEnumerable<IPictureModel> pictures = _dal.GetPictures(null, null, null, null);
            IIPTCModel iptcModel = null;

            foreach (IPictureModel picture in pictures)
            {
                if (picture.FileName.Equals(filename))
                {
                    iptcModel = picture.IPTC;
                }
            }

            if (iptcModel == null)
            {
                throw new PictureNotFoundException("\"" + filename + "\" does not exist.");
            }

            return iptcModel;
        }

        public ICameraModel GetCamera(int ID)
        {
            return _dal.GetCamera(ID);
        }

        public IEnumerable<ICameraModel> GetCameras()
        {
            return _dal.GetCameras();
        }

        public IPhotographerModel GetPhotographer(int ID)
        {
            return _dal.GetPhotographer(ID);
        }

        public IEnumerable<IPhotographerModel> GetPhotographers()
        {
            return _dal.GetPhotographers();
        }

        public IPictureModel GetPicture(int ID)
        {
            return _dal.GetPicture(ID);
        }

        public IEnumerable<IPictureModel> GetPictures()
        {
            return _dal.GetPictures(null, null, null, null);
        }

        public IEnumerable<IPictureModel> GetPictures(string namePart, IPhotographerModel photographerParts, IIPTCModel iptcParts, IEXIFModel exifParts)
        {
            return _dal.GetPictures(namePart, photographerParts, iptcParts, exifParts);
        }

        public void Save(IPictureModel picture)
        {
            _dal.Save(picture);
        }

        public void Save(IPhotographerModel photographer)
        {
            _dal.Save(photographer);
        }

        public void Sync()
        {
            int ID = 999;

            //FilePath = "./Pictures";
            foreach (string file in Directory.EnumerateFiles(FilePath))
            {
                IPictureModel pictureModel = new PictureModel(ID--);
                pictureModel.FileName = file.Substring(file.LastIndexOf("\\") + 1);

                _dal.Save(pictureModel);
            }
        }

        public void WriteIPTC(string filename, IIPTCModel iptc)
        {
            throw new NotImplementedException();
        }
    }
}
