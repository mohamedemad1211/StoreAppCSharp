using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBl.DataAccessL;
using StoreBl.Models;
namespace StoreBl.Bl
{
    public class ClsItems : IBusinessLayer<ItemModel>
    {
        public bool Add(ItemModel table)
        {
            List<ItemModel> lstItems = GetAll();
            int nItemId = 0;
            if (lstItems.Count == 0)
                nItemId = 1;
            else
            {
                nItemId = lstItems.Max(a => a.ItemId) + 1;
            }
            string ItemData = string.Format("-{0}#{1}#{2}", nItemId, table.ItemName,table.ItemPrice);
            IDataAccess myDataAccess = DataAccessHelper.CreateObject();
            myDataAccess.Insert(FileNames.items.ToString() + ".txt", ItemData);
            return true;
        }

        public bool Delete(int id)
        {
            List<ItemModel> lstItems = GetAll();
            ItemModel model = lstItems.Where(a => a.ItemId == id).FirstOrDefault();
            if (model == null)
                return false;
            else
            {
                lstItems.Remove(model);
                string sFileData = string.Empty;
                int nCount = 0;
                foreach (var item in lstItems)
                {
                    if (nCount == 0)
                        sFileData += string.Format("{0}#{1}#{2}", item.ItemId, item.ItemName, item.ItemPrice);
                    else
                        sFileData += string.Format("-{0}#{1}#{2}", item.ItemId, item.ItemName, item.ItemPrice);
                    nCount++;
                }
                IDataAccess myDataAccess = DataAccessHelper.CreateObject();
                myDataAccess.Delete(FileNames.items.ToString() + ".txt", sFileData);
                return true;
            }
        }

        public List<ItemModel> GetAll()
        {

            IDataAccess myDataAccess = DataAccessHelper.CreateObject(); // create a data access object using the helper
            string ItemList = myDataAccess.GetAll(FileNames.items.ToString() + ".txt"); // read all store data from the file "stores.txt" as a single string 
            string[] Items = ItemList.Split('-'); //split the string into individual store entries using as a delimiter
            List<ItemModel> listItems = new List<ItemModel>(); // Initialize an empty list to hold the final store models
            ItemModel oItemModel; // Declare a temporary variable to hold each store model during iteration
            foreach (string myItem in Items) // Loop through each store entry
            {
                if (string.IsNullOrEmpty(myItem)) // Skip if the store entry is null or empty
                    continue;
                string[] ItemFileds = myItem.Split('#'); // Split store data into fields using '#' as a separator
                oItemModel = new ItemModel(); // Create a new StoreModel object
                oItemModel.ItemId = Convert.ToInt32(ItemFileds[0]); // Parse and assign the Store ID from the first field
                oItemModel.ItemName = ItemFileds[1]; // Assign the Store Name from the second field
                oItemModel.ItemPrice = Convert.ToDecimal( ItemFileds[2]);
                listItems.Add(oItemModel); // Add the populated StoreModel object to the list

            }
            return listItems;
        }
    }
}
