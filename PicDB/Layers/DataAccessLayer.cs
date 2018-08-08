using BIF.SWE2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.Models;
using System.Data.SqlClient;
using System.Data;

namespace PicDB.Layers
{
    class DataAccessLayer : IDataAccessLayer
    {
        private static DataAccessLayer _instance = null;
        private static string _connectionString;

        public static DataAccessLayer Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new DataAccessLayer();
                    _connectionString = @"Data source=DESKTOP-RK06UV5\SQLEXPRESS;" +
                                        "Initial Catalog=MyWebServerDB;" +
                                        "Trusted_Connection=True";
                }

                return _instance;
            }
        }

        public void DeletePhotographer(int ID)
        {
            throw new NotImplementedException();
        }

        public void DeletePicture(int ID)
        {
            throw new NotImplementedException();
        }

        public ICameraModel GetCamera(int ID)
        {
            throw new NotImplementedException();
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

        public IEnumerable<IPictureModel> GetPictures(string namePart, IPhotographerModel photographerParts, IIPTCModel iptcParts, IEXIFModel exifParts)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPictureModel> GetPictures()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO " +
                               "Pictures (temperature, date, location) " +
                               "VALUES (@param1, @param2, @param3)";
            }
                throw new NotImplementedException();
        }

        public void Save(IPictureModel picture)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                try
                {
                    string query =  "INSERT INTO " +
                                    "Pictures (Filename) " +
                                    "VALUES (@param1)";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.Add("@param1", SqlDbType.VarChar).Value = picture.FileName;

                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                catch
                {

                }
                finally
                {
                    connection.Close();
                }
                
            }
        }

        public void Save(IPhotographerModel photographer)
        {
            throw new NotImplementedException();
        }
    }
}
