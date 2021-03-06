﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using orderManage;

namespace orderManage
{
    public class Order
    {
        public int orderNum { get; set; }
        public string client { get; set; }
        public string address { get; set; }
        public DateTime orderTime { get; set; }
        public double sumPrice
        {
            get
            {
                double sumPrice = 0;
                foreach (OrderItem item in orderItemList)
                {
                    sumPrice += item.tradeNum * item.tradeUnitPrice;
                }
                return sumPrice;
            }
        }

        public List<OrderItem> orderItemList = new List<OrderItem>();
        public List<OrderItem> OrderItemList
        {
            get { return orderItemList; }
        }

        public bool AddOrderItem(string Name,int Num,double unitprice)
        {
            OrderItem odi = new OrderItem(Name, Num, unitprice);
            bool isRepeat = false;
            foreach (OrderItem item in orderItemList)
            {
                if (odi.Equals(item))
                {
                    isRepeat = true;
                }
                else
                {
                    isRepeat = false;
                }
            }
            if (!isRepeat)
            {
                orderItemList.Add(odi);
                return true;
            }
            else
            {
                throw new OrderItemRepeatException(Name);
            }
        }

        public Order()
        {
            this.client = null;
            this.address = null;
            orderTime = DateTime.Now;
        }
        public Order(int orderNum,string client, string address)
        {
            this.client = client;
            this.address = address;
            orderTime = DateTime.Now;
            this.orderNum = orderNum;
        }

        public override bool Equals(object obj)
        {
            Order order = obj as Order;
            return order != null && order.client == client;
        }

        public override int GetHashCode()
        {
            return orderNum;
        }

        public override string ToString()
        {
            string result = "";
            result += "----------------------------------\n";
            result += "Order Number:" + orderNum + "\n";
            result += "Customer:" + client + "\n";
            result += "----------------------------------\n";
            result += "Item Name         Price        Quantity\n";
            foreach (OrderItem item in orderItemList)
            {
                result += item;
            }
            result += "----------------------------------\n";
            result += "Total Price:" + this.sumPrice + "\n";
            result += "----------------------------------\n";

            return result;
        }
    }
}
