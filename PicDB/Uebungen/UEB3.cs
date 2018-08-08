using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB;
using PicDB.Mocks;
using PicDB.Models;
using PicDB.Layers;

namespace Uebungen
{
    public class UEB3 : IUEB3
    {
        public void HelloWorld()
        {
        }

        public IBusinessLayer GetBusinessLayer()
        {
            BusinessLayer.Instance.Sync();
            return BusinessLayer.Instance;
        }

        public void TestSetup(string picturePath)
        {
            
        }

        public IDataAccessLayer GetDataAccessLayer()
        {
            BusinessLayer.Instance.Sync();
            return BusinessLayer.Instance.MockDal;
        }

        public ISearchViewModel GetSearchViewModel()
        {
            return new SearchViewModel();
        }
    }
}
