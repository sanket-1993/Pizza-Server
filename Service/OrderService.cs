

using Contract;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using NLog;

namespace Repository
{
    public class OrderService: IOrderService
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        public int PlaceOrder(Order order)
        {
            logger.Info("inside OrderService/PlaceOrder");
            int result = 0;
            try
            {
                if (order != null)
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    var orderList = new List<Order>();
                    var maxID = 1;
                    if (File.Exists(path + @"\Database\" + "Order.json"))
                    {
                        string Json = File.ReadAllText(path + @"\Database\" + "Order.json");
                        orderList = JsonConvert.DeserializeObject<List<Order>>(Json);
                        if(orderList.AnyOrNotNull())
                        {
                            maxID = orderList.Max(x => x.ID);
                            maxID = maxID+1;
                        }
                        File.Delete(path + @"\Database\" + "Order.json");
                    }
                    order.ID = maxID;
                    orderList.Add(order);
                    string json = JsonConvert.SerializeObject(orderList.ToArray());
                    File.WriteAllText(path + @"\Database\" + "Order.json", json);
                    result = maxID;
                    //Notify.SendEMail(); To do : we can send notification to user
                }

                return result;

            }
            catch (Exception ex)
            {
                logger.Error("Exception in Order/OrderService: {0} \r\n {1}", ex.ToString(), ex.StackTrace);
                throw ex;
            }
        }
    }
}
