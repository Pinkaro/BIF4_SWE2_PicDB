﻿using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Layers;
using PicDB.ViewModels;

namespace PicDB.Uebungen
{
    public class UEB3 : IUEB3
    {
        public void HelloWorld()
        {
        }

        public IBusinessLayer GetBusinessLayer()
        {
            BusinessLayer bl = new BusinessLayer();
            bl.Sync();
            return bl;
        }

        public void TestSetup(string picturePath)
        {
            
        }

        public IDataAccessLayer GetDataAccessLayer()
        {
            BusinessLayer bl = new BusinessLayer();
            bl.Sync();
            return bl.DataAccessLayer;
        }

        public ISearchViewModel GetSearchViewModel()
        {
            return new SearchViewModel();
        }
    }
}
