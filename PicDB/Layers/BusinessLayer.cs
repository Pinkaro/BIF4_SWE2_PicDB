using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Models;
using PicDB.utils;

namespace PicDB.Layers
{
    /// <summary>
    /// The businessLayer implements all use cases and is the connection to the DataAccessLayer.
    /// </summary>
    public class BusinessLayer : IBusinessLayer
    {
        /// <summary>
        /// Instance to connect BusinessLayer and DataAccessLayer.
        /// </summary>
        public IDataAccessLayer DataAccessLayer;

        public BusinessLayer()
        {
            DataAccessLayerFactory factory = DataAccessLayerFactory.Instance;
            DataAccessLayer = factory.CreateDataAccessLayer(false);
        }

        /// <summary>
        /// Returns a list of ALL Pictures from the directory, based on a database query.
        /// </summary>
        /// <returns>IEnumerable of IPicturemodels</returns>
        public IEnumerable<IPictureModel> GetPictures()
        {
            return DataAccessLayer.GetPictures(null, null, null, null);
        }

        /// <summary>
        /// Returns a filterd list of Pictures from the directory, based on a database query.
        /// </summary>
        /// <param name="namePart">A filter for filename</param>
        /// <param name="photographerParts">A filter for a photographer</param>
        /// <param name="iptcParts">A filter for IPTC information</param>
        /// <param name="exifParts">A filter for EXIF information</param>
        /// <returns></returns>
        public IEnumerable<IPictureModel> GetPictures(string namePart, IPhotographerModel photographerParts, IIPTCModel iptcParts,
            IEXIFModel exifParts)
        {
            return DataAccessLayer.GetPictures(namePart, photographerParts, iptcParts, exifParts);
        }

        /// <summary>
        /// Returns ONE Picture from the database.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IPictureModel GetPicture(int ID)
        {
            return DataAccessLayer.GetPicture(ID);
        }

        /// <summary>
        /// Saves all changes for one picture to the database.
        /// </summary>
        /// <param name="picture"></param>
        public void Save(IPictureModel picture)
        {
            DataAccessLayer.Save(picture);
        }

        /// <summary>
        /// Deletes a Picture from the database AND from the file system.
        /// </summary>
        /// <param name="ID"></param>
        public void DeletePicture(int ID)
        {
            DataAccessLayer.DeletePicture(ID);
        }

        /// <summary>
        /// Syncs the picture folder with the database.
        /// </summary>
        public void Sync()
        {
            //Alle Filenamen holen die sich im angegebenen Verzeichnis finden
            IEnumerable<string> pathFiles = Directory.EnumerateFiles(GlobalInformation.Path);
            //Erstelle eine Liste und füge mit einer foreach Schleife die gefunden Files von pathFiles und füge die einzelnen Elemente der Liste hinzu
            var files = new HashSet<string>(pathFiles.Select(Path.GetFileName)); 
            
            //Erstelle eine Liste von allen Bilder, welche sich in der Datenbank befinden
            List<IPictureModel> pictures = DataAccessLayer.GetPictures(null, null, null, null).ToList();
 
            foreach (var pictureModel in pictures)
            {
                //Falls das Bild aus der Datenbank nicht im Ordner ist, Lösche es aus der Datenbank
                if (!files.Contains(pictureModel.FileName))
                {
                    DeletePicture(pictureModel.ID);
                }
                //falls es bereits synchronisiert ist dann lösche es aus den zu synchronisierenden Files raus
                else
                {
                    files.Remove(pictureModel.FileName);
                }
            }

            //Alle Files die noch nicht mit dem Ordner synchronisiert sind, zur Datenbank hinzufügen
            foreach (var filename in files)
            {
                IPictureModel pictureModel = new PictureModel(filename);
                pictureModel.EXIF = ExtractEXIF(filename);
                pictureModel.IPTC = ExtractIPTC(filename);
                Save(pictureModel);
            }
        }

        /// <summary>
        /// Returns a list of ALL photographers, based on a database query.
        /// </summary>
        /// <returns>IEnumerable of IPhotographerModel</returns>
        public IEnumerable<IPhotographerModel> GetPhotographers()
        {
            return DataAccessLayer.GetPhotographers();
        }

        /// <summary>
        /// Returns a list of ONE photographers, based on a database query.
        /// </summary>
        /// <returns>IEnumerable of IPhotographerModel</returns>
        public IPhotographerModel GetPhotographer(int ID)
        {
            return DataAccessLayer.GetPhotographer(ID);
        }

        /// <summary>
        /// Saves all changes of one photographer to the database.
        /// </summary>
        /// <param name="photographer"></param>
        public void Save(IPhotographerModel photographer)
        {
            DataAccessLayer.Save(photographer);
        }

        /// <summary>
        /// Deletes a photographer from database based on given ID
        /// </summary>
        /// <param name="ID"></param>
        public void DeletePhotographer(int ID)
        {
            DataAccessLayer.DeletePhotographer(ID);
        }

        /// <summary>
        /// Extracts IPTC information from a picture. NOTE: You may simulate the action.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public IIPTCModel ExtractIPTC(string filename)
        {
            var iptcData = new IPTCModel();
            IEnumerable<string> pathFiles = Directory.EnumerateFiles(GlobalInformation.Path);
            if (!pathFiles.Contains(Path.Combine(GlobalInformation.Path, filename))) throw new FileNotFoundException();
            iptcData.ByLine = "ByLine";
            iptcData.Caption = "caption";
            iptcData.CopyrightNotice = "this is my shit - bro!";
            iptcData.Headline = "I'm the Head";
            iptcData.Keywords = "Blame on me";
            return iptcData;
        }

        /// <summary>
        /// Extracts EXIF information from a picture. NOTE: You may simulate the action.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public IEXIFModel ExtractEXIF(string filename)
        {
            var exifData = new EXIFModel();
            IEnumerable<string> pathFiles = Directory.EnumerateFiles(GlobalInformation.Path);
            if (!pathFiles.Contains(Path.Combine(GlobalInformation.Path, filename))) throw new FileNotFoundException();
            exifData.ExposureProgram = ExposurePrograms.CreativeProgram;
            exifData.ExposureTime = 10;
            exifData.FNumber = 2;
            exifData.Flash = true;
            exifData.ISOValue = 8008;
            exifData.Make = "Make";
            return exifData;
        }

        /// <summary>
        /// Writes IPTC information back to a picture. NOTE: You may simulate the action.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="iptc"></param>
        public void WriteIPTC(string filename, IIPTCModel iptc)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a list of ALL Cameras.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICameraModel> GetCameras()
        {
            return DataAccessLayer.GetCameras();
        }

        /// <summary>
        /// Returns ONE Camera
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ICameraModel GetCamera(int ID)
        {
            return DataAccessLayer.GetCamera(ID);
        }

        /// <summary>
        /// Updates ONE camera
        /// </summary>
        /// <param name="cameraModel"></param>
        public void UpdateCamera(ICameraModel cameraModel)
        {
            ((DataAccessLayer) DataAccessLayer).UpdateCamera(cameraModel);
        }

        /// <summary>
        /// Deletes ONE camera based on ID
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteCamera(int ID)
        {
            ((DataAccessLayer) DataAccessLayer).DeleteCamera(ID);
        }

        /// <summary>
        /// Saves a camera to the database
        /// </summary>
        /// <param name="camera"></param>
        public void SaveCamera(CameraModel camera)
        {
            var dal = (DataAccessLayer)DataAccessLayer;
            dal.SaveCamera(camera);
        }

        /// <summary>
        /// Updates a photographer
        /// </summary>
        /// <param name="photographerModel"></param>
        public void UpdatePhotographer(PhotographerModel photographerModel)
        {
            ((DataAccessLayer) DataAccessLayer).UpdatePhotographer(photographerModel);
        }

        /// <summary>
        /// Saves a photographer to the database
        /// </summary>
        /// <param name="photographerModel"></param>
        public void SavePhotographer(PhotographerModel photographerModel)
        {
            ((DataAccessLayer)DataAccessLayer).SavePhotographer(photographerModel);
        }

        /// <summary>
        /// Returns a dictionary with all tags as their key and a count of occurences as their value.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> GetTagCount()
        {
            return ((DataAccessLayer) DataAccessLayer).GetTagCount();
        }
    }
}
