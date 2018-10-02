using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIF.SWE2.Interfaces;
using PicDB.Layers;
using PicDB.Mocks;

namespace PicDB.utils
{
    /// <summary>
    /// A factory to create instances derived from IDataAccessLayer
    /// </summary>
    public class DataAccessLayerFactory
    {
        private static DataAccessLayerFactory _instance;

        /// <summary>
        /// Instance of factory
        /// </summary>
        public static DataAccessLayerFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataAccessLayerFactory();
                    return _instance;
                }

                return _instance;
            }
        }

        private DataAccessLayerFactory() { }

        /// <summary>
        /// Creates an instance of a DataAccessLayer
        /// </summary>
        /// <param name="getMock"></param>
        /// <returns></returns>
        public IDataAccessLayer CreateDataAccessLayer(bool getMock)
        {
            if (getMock) return new MockDataAccessLayer();
            return new DataAccessLayer();
            
        }
    }
}
