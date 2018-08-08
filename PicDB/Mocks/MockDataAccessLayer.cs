using BIF.SWE2.Interfaces;
using PicDB.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.Models;
using PicDB.Models;

namespace PicDB.Mocks
{
    public class MockDataAccessLayer : IDataAccessLayer
    {
        Dictionary<int, ICameraModel> cameras;
        Dictionary<int, IPhotographerModel> photographers;
        Dictionary<int, IPictureModel> pictures;

        int photographersNextId = 1;

        public MockDataAccessLayer()
        {
            cameras = new Dictionary<int, ICameraModel>();
            CameraModel mockCamera = new CameraModel(1);

            cameras.Add(mockCamera.ID, mockCamera);

            photographers = new Dictionary<int, IPhotographerModel>();
            PhotographerModel mockPhotographer = new PhotographerModel();

            photographers.Add(mockPhotographer.ID, mockPhotographer);

            pictures = new Dictionary<int, IPictureModel>();
        }

        public void DeletePhotographer(int ID)
        {
            photographers.Remove(ID);
        }

        public void DeletePicture(int ID)
        {
            pictures.Remove(ID);
        }

        public ICameraModel GetCamera(int ID)
        {
            return new CameraModel(ID);
        }

        public IEnumerable<ICameraModel> GetCameras()
        { 
            return new List<ICameraModel>(cameras.Values);
        }

        public IPhotographerModel GetPhotographer(int ID)
        {
            return new PhotographerModel(ID);
        }

        public IEnumerable<IPhotographerModel> GetPhotographers()
        {
            return new List<IPhotographerModel>(photographers.Values);
        }

        public IPictureModel GetPicture(int ID)
        {
            return new PictureModel(ID);
        }

        public IEnumerable<IPictureModel> GetPictures(string namePart, IPhotographerModel photographerParts, IIPTCModel iptcParts, IEXIFModel exifParts)
        {
            if(namePart != null && namePart != string.Empty)
            {
                List<IPictureModel> filteredPictures = new List<IPictureModel>();
                
                foreach(KeyValuePair<int, IPictureModel> item in pictures)
                {
                    if (item.Value.FileName.ToLower().Contains(namePart))
                    {
                        filteredPictures.Add(item.Value);
                    }
                }
                return filteredPictures;
            }

            return new List<IPictureModel>(pictures.Values);
        }

        public void Save(IPictureModel picture)
        {
            pictures.Add(picture.ID, picture);
        }

        public void Save(IPhotographerModel photographer)
        {
            photographers.Add(photographer.ID, photographer);
        }
    }
}
