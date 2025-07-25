using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBl.Bl;
using StoreBl.Models;
namespace StoreAppCSharp
{
    public class UiHelper
    {
        public static void MainOptions()
        {
            //Console.Clear();
            Console.WriteLine("Welcome to our store");
            Console.WriteLine("To manage stores press 1");
            Console.WriteLine("To manage items press 2");
            Console.WriteLine("To manage orders press 3");
            Console.WriteLine("To manage reports press 4");
            Console.WriteLine("To close the app press 0");
        }

        public static void StoreOptions()
        {
            string sStoreOption = string.Empty;
            while(sStoreOption!="0")
            {
                
                Console.WriteLine("Welcome to manage stores data");
                Console.WriteLine("To add stores press 1");
                Console.WriteLine("To get all stores press 2");
                Console.WriteLine("To delete stores press 3");
                Console.WriteLine("To go back press 0");
                sStoreOption = Console.ReadLine();
                ClsItem oClsStore = new ClsItem();
                switch (sStoreOption)
                {
                    case "1":
                       
                            StoreModel oStoreModel = new StoreModel();
                            Console.Clear();
                            //Console.WriteLine("Please enter store id");
                            //int nStoreId = 0;
                            //bool bCanConverted = int.TryParse(Console.ReadLine(), out nStoreId);
                            //if(bCanConverted)
                            //    oStoreModel.StoreId = nStoreId;
                            //else
                            //{
                            //    Console.WriteLine("Please enter store name");
                            //     break;
                            //}

                            Console.WriteLine("Please enter store name");
                            oStoreModel.StoreName = Console.ReadLine();


                            oClsStore.Add(oStoreModel);
                      
                      
                        break;
                    case "2":
                        Console.Clear();
                        List<StoreModel> lstStores = oClsStore.GetAll();
                        Console.WriteLine("*************************************");
                        foreach (var store in lstStores)
                        {
                            Console.WriteLine(string.Format("store id {0} store name {1}", store.StoreId, store.StoreName));
                            Console.WriteLine("--------------------------------------");
                        }
                        Console.WriteLine("*************************************");
                        
                        break;
                    case "3":
                        Console.WriteLine("Please enter store id");
                        int nStoreId = 0;
                        bool bCanConverted = int.TryParse(Console.ReadLine(), out nStoreId);
                        if (bCanConverted)
                        {
                           bool isDeleted = oClsStore.Delete(nStoreId);
                            if(!isDeleted)
                            {
                                Console.WriteLine("Id not found in the file");
                            }
                        }
                        else
                            Console.WriteLine("Please enter vaild id");
                        break;
                }
            }
            
        }

        public static void ShowAllStores(List<StoreModel> lstStores)
        {
            Console.WriteLine("*************************************");
            foreach (var store in lstStores)
            {
                Console.WriteLine(string.Format("store id {0} store name {1}", store.StoreId, store.StoreName));
                Console.WriteLine("--------------------------------------");
            }
            Console.WriteLine("*************************************");
        }

        public static void OrderOptions()
        {
            string sItemOption = string.Empty;
            while (sItemOption != "0")
            {

                Console.WriteLine("Welcome to manage items data");
                Console.WriteLine("To add items press 1");
                Console.WriteLine("To get all items press 2");
                Console.WriteLine("To delete items press 3");
                Console.WriteLine("To go back press 0");
                sItemOption = Console.ReadLine();
                ClsOrders oClsOrders = new ClsOrders();
                int nItemId = 0;
                bool bCanConverted = false;
                switch (sItemOption)
                {
                    case "1":

                        OrderModel oOrderModel = new OrderModel();
                        Console.Clear();
         

                        Console.WriteLine("Please enter item id");
                        bCanConverted = int.TryParse(Console.ReadLine(), out nItemId);
                        if (bCanConverted)
                            oOrderModel.OrderItem.ItemId = nItemId;
                        else
                            Console.WriteLine("Please enter a valid item id");

                        Console.WriteLine("Please enter store id");
                        int nStoreId = 0;
                        bCanConverted = int.TryParse(Console.ReadLine(),out nStoreId);
                        if (bCanConverted)
                            oOrderModel.OrderStore.StoreId = nStoreId;
                        else
                            Console.WriteLine("Please enter a valid store id");

                        oOrderModel.OrderDate = DateTime.Now;
                        oClsOrders.Add(oOrderModel);


                        break;
                    case "2":
                        Console.Clear();
                        List<OrderModel> lstOrders = oClsOrders.GetAll();
                        Console.WriteLine("*************************************");
                        foreach (var order in lstOrders)
                        {
                            Console.WriteLine(string.Format("Order id {0} Order date  {1} item id {2} Store id {3}", order.OrderId, order.OrderDate, order.OrderItem.ItemId, order.OrderStore.StoreId));
                            Console.WriteLine("--------------------------------------");
                        }
                        Console.WriteLine("*************************************");

                        break;
                    case "3":
                        Console.WriteLine("Please enter Order id");
                         int nOrderId = 0;
                        bool bIsConverted = int.TryParse(Console.ReadLine(), out nOrderId);
                        if (bIsConverted)
                        {
                            bool isDeleted = oClsOrders.Delete(nOrderId);
                            if (!isDeleted)
                            {
                                Console.WriteLine("Id not found in the file");
                            }
                        }
                        else
                            Console.WriteLine("Please enter vaild id");
                        break;
                }
            }

        }


        public static void ItemOptions()
        {
            string sOrderOption = string.Empty;
            while (sOrderOption != "0")
            {

                Console.WriteLine("Welcome to manage Orders data");
                Console.WriteLine("To add Orders press 1");
                Console.WriteLine("To get all Orders press 2");
                Console.WriteLine("To delete Orders press 3");
                Console.WriteLine("To go back press 0");
                sOrderOption = Console.ReadLine();
                ClsOrders oClsOrder = new ClsOrders();
                int nOrderId = 0;
                bool bCanConverted = false;
                switch (sOrderOption)
                {
                    case "1":

                        OrderModel oOrderModel = new OrderModel();
                        Console.Clear();


                        Console.WriteLine("Please enter item id");
                        bCanConverted = int.TryParse(Console.ReadLine(), out nOrderId);
                        if(bCanConverted)
                             oOrderModel.OrderItem.ItemId = nOrderId;
                        else
                            Console.WriteLine("Please enter a valid item id");

                        Console.WriteLine("Please enter store id");
                        int nStoreId = 0;
                        bCanConverted = int.TryParse(Console.ReadLine(), out nStoreId);
                        if (bCanConverted)
                            oOrderModel.OrderStore.StoreId = nStoreId;
                        else
                            Console.WriteLine("Please enter a valid price");

                        oOrderModel.OrderDate = DateTime.Now;

                        oClsOrder.Add(oOrderModel);


                        break;
                    case "2":
                        Console.Clear();
                        List<OrderModel> lstIOrders = oClsOrder.GetAll();
                        Console.WriteLine("*************************************");
                        foreach (var order in lstIOrders)
                        {
                            Console.WriteLine(string.Format("Order id {0} Order Date {1} item id {2} Store Id {3}", order.OrderId, order.OrderDate, order.OrderItem.ItemId, order.OrderStore.StoreId));
                            Console.WriteLine("--------------------------------------");
                        }
                        Console.WriteLine("*************************************");

                        break;
                    case "3":
                        Console.WriteLine("Please enter item id");
                        nOrderId = 0;
                        bool bIsConverted = int.TryParse(Console.ReadLine(), out nOrderId);
                        if (bIsConverted)
                        {
                            bool isDeleted = oClsOrder.Delete(nOrderId);
                            if (!isDeleted)
                            {
                                Console.WriteLine("Id not found in the file");
                            }
                        }
                        else
                            Console.WriteLine("Please enter vaild id");
                        break;
                }
            }

        }
    }
}
