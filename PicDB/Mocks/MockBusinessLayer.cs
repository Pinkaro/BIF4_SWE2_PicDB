using BIF.SWE2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.Models;
using PicDB.Layers;
using System.IO;
using PicDB.Models;
using System.Reflection;

namespace PicDB.Mocks
{
    class MockBusinessLayer : IBusinessLayer
    {
        private List<IPictureModel> _filesInDB;
        private string _filePath;
        private MockDataAccessLayer _dal;

        public MockBusinessLayer()
        {
            _filesInDB = new List<IPictureModel>();
            _dal = new MockDataAccessLayer();

            SetFilePath();
        }

        public MockBusinessLayer(string path)
        {
            _filesInDB = new List<IPictureModel>();
            _filePath = path;

            _dal = new MockDataAccessLayer();
        }

        private void SetFilePath()
        {
            //string pathToAssembly = Assembly.GetEntryAssembly().Location;
            //string assemblyName = pathToAssembly.Split('\\').Last();

            //// remove .exe
            //_filePath = pathToAssembly.Replace(assemblyName, "");

            _filePath = @"C:\AAA-Technikum_BWI\fourthSemester\SWE2\SWE2-CS\deploy\Pictures";
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
            throw new NotImplementedException();
        }

        public IIPTCModel ExtractIPTC(string filename)
        {
            throw new NotImplementedException();
        }

        public ICameraModel GetCamera(int ID)
        {
            return _dal.GetCamera(ID);
        }

        public IEnumerable<ICameraModel> GetCameras()
        {
            throw new NotImplementedException();
        }

        public IPhotographerModel GetPhotographer(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPhotographerModel> GetPhotographers()
        {
            throw new NotImplementedException();
        }

        public IPictureModel GetPicture(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPictureModel> GetPictures()
        {
            return _filesInDB;
        }

        public IEnumerable<IPictureModel> GetPictures(string namePart, IPhotographerModel photographerParts, IIPTCModel iptcParts, IEXIFModel exifParts)
        {
            throw new NotImplementedException();
        }

        public void Save(IPictureModel picture)
        {
            throw new NotImplementedException();
        }

        public void Save(IPhotographerModel photographer)
        {
            throw new NotImplementedException();
        }

        public void Sync()
        {
            foreach (string file in Directory.EnumerateFiles(_filePath))
            {
                _filesInDB.Add(new PictureModel());
            }
        }

        public void WriteIPTC(string filename, IIPTCModel iptc)
        {
            throw new NotImplementedException();
        }
    }
}
