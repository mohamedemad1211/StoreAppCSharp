using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBl.Models;
using StoreBl.DataAccessL;
namespace StoreBl.Bl
{
    public class ClsItem : IBusinessLayer<StoreModel>
    {
        public bool Add(StoreModel table)
        {
            List<StoreModel> lstStores = GetAll();
            //foreach(var store in lstStores)
            //{
            //    if(store.StoreId==table.StoreId)
            //    {
            //        return false;
            //    }
            //}
            //List <StoreModel> OldStore = lstStores.Where(a => a.StoreId == table.StoreId).ToList(); //search in list
            //if (OldStore.Count > 0)
            //    return false;
            int nStoreId = 0;
            if (lstStores.Count == 0)
                nStoreId = 1;
            else
            {
                nStoreId = lstStores.Max(a => a.StoreId) + 1;
            }
                string storeData = string.Format("-{0}#{1}", nStoreId, table.StoreName);
           IDataAccess myDataAccess = DataAccessHelper.CreateObject();
            myDataAccess.Insert(FileNames.stores.ToString()+".txt", storeData);
            return true;
        }

        public bool Delete(int id)
        {
            List<StoreModel> lstStores = GetAll();
            StoreModel model = lstStores.Where(a => a.StoreId == id).FirstOrDefault();
            if (model == null)
                return false;
            else
            {
                lstStores.Remove(model);
                string sFileData = string.Empty;
                int nCount = 0;
                foreach(var store in lstStores)
                {
                    if(nCount==0)
                         sFileData += string.Format("{0}#{1}", store.StoreId, store.StoreName);
                    else
                        sFileData += string.Format("-{0}#{1}", store.StoreId, store.StoreName);
                    nCount++;
                }
                IDataAccess myDataAccess = DataAccessHelper.CreateObject();
                myDataAccess.Delete(FileNames.stores.ToString() + ".txt", sFileData);
                return true;
            }


        }

        public List<StoreModel> GetAll() // merhod returns a list of storemodel objects
        {
            IDataAccess myDataAccess = DataAccessHelper.CreateObject(); // create a data access object using the helper
            string storeList =  myDataAccess.GetAll(FileNames.stores.ToString() + ".txt"); // read all store data from the file "stores.txt" as a single string 
            string[] Stores = storeList.Split('-'); //split the string into individual store entries using as a delimiter
            List<StoreModel> listStores = new List<StoreModel>(); // Initialize an empty list to hold the final store models
            StoreModel oStoreModel; // Declare a temporary variable to hold each store model during iteration
            foreach (string myStore in Stores) // Loop through each store entry
            {
                if (string.IsNullOrEmpty(myStore)) // Skip if the store entry is null or empty
                    continue;
                string[] StoreFileds = myStore.Split('#'); // Split store data into fields using '#' as a separator
                oStoreModel = new StoreModel(); // Create a new StoreModel object
                oStoreModel.StoreId = Convert.ToInt32 (StoreFileds[0]); // Parse and assign the Store ID from the first field
                oStoreModel.StoreName = StoreFileds[1]; // Assign the Store Name from the second field
                listStores.Add(oStoreModel); // Add the populated StoreModel object to the list

            }
            return listStores;
        }
    }
}
