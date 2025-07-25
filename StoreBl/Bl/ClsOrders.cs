using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBl.DataAccessL;
using StoreBl.Models;
namespace StoreBl.Bl
{
    public class ClsOrders : IBusinessLayer<OrderModel>
    {
        

        public bool Add(OrderModel table)
        {
            List<OrderModel> lstOrders = GetAll();
            int nOrderId = 0;
            if (lstOrders.Count == 0)
                nOrderId = 1;
            else
            {
                nOrderId = lstOrders.Max(a => a.OrderId) + 1;
            }
            string OrderData = string.Format("-{0}#{1}#{2}#{3}", nOrderId, table.OrderDate, table.OrderItem.ItemId, table.OrderStore.StoreId);
            IDataAccess myDataAccess = DataAccessHelper.CreateObject();
            myDataAccess.Insert(FileNames.orders.ToString() + ".txt", OrderData);
            return true;
        }

        public bool Delete(int id)
        {
            List<OrderModel> lstOrders = GetAll();
            OrderModel model = lstOrders.Where(a => a.OrderId == id).FirstOrDefault();
            if (model == null)
                return false;
            else
            {
                lstOrders.Remove(model);
                string sFileData = string.Empty;
                int nCount = 0;
                foreach (var order in lstOrders)
                {
                    if (nCount == 0)
                        sFileData += string.Format("{0}#{1}#{2}#{3}", order.OrderId, order.OrderDate, order.OrderItem.ItemId, order.OrderStore.StoreId);
                    else
                        sFileData += string.Format("-{0}#{1}#{2}#{3}", order.OrderId, order.OrderDate, order.OrderItem.ItemId, order.OrderStore.StoreId);
                    nCount++;
                }
                IDataAccess myDataAccess = DataAccessHelper.CreateObject();
                myDataAccess.Delete(FileNames.orders.ToString() + ".txt", sFileData);
                return true;
            }
        }

        public List<OrderModel> GetAll()
        {
            IDataAccess myDataAccess = DataAccessHelper.CreateObject(); // create a data access object using the helper
            string OrderList = myDataAccess.GetAll(FileNames.orders.ToString() + ".txt"); // read all store data from the file "stores.txt" as a single string 
            string[] Orders = OrderList.Split('-'); //split the string into individual store entries using as a delimiter
            List<OrderModel> listOrders = new List<OrderModel>(); // Initialize an empty list to hold the final store models
            OrderModel oOrderModel; // Declare a temporary variable to hold each store model during iteration
            foreach (string myOrder in Orders) // Loop through each store entry
            {
                if (string.IsNullOrEmpty(myOrder)) // Skip if the store entry is null or empty
                    continue;
                string[] OrderFileds = myOrder.Split('#'); // Split store data into fields using '#' as a separator
                oOrderModel = new OrderModel(); // Create a new StoreModel object
                oOrderModel.OrderId = Convert.ToInt32(OrderFileds[0]); // Parse and assign the Store ID from the first field
                oOrderModel.OrderDate = Convert.ToDateTime(OrderFileds[1]); // Assign the Store Name from the second field
                oOrderModel.OrderItem.ItemId = Convert.ToInt32(OrderFileds[2]);
                oOrderModel.OrderStore.StoreId = Convert.ToInt32(OrderFileds[3]);

                listOrders.Add(oOrderModel); // Add the populated StoreModel object to the list

            }
            return listOrders;
        }
    }
}
