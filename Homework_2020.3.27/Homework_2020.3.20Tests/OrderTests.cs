using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework_2020._3._20;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2020._3._20.Tests
{
    [TestClass()]
    public class OrderTests
    {
        Order order;
        Item book = new Item("book", 10, 100);
        Item car = new Item("car", 100000, 5);
        Item milk = new Item("milk", 5, 1000);
        Item plane = new Item("plane", 10000000, 3);

        [TestInitialize()]
        public void OrderInitialize()
        {
            order = new Order();

            order.AddOrderItem(book, 3);
            order.AddOrderItem(car, 1);
            order.AddOrderItem(milk, 5);
        }


        [TestMethod()]
        public void ContainsTest()
        { 
            Assert.IsTrue(order.Contains("book"));
        }

        [TestMethod()]
        public void FindIndexOfOrderItemTest()
        {
            Assert.IsTrue(order.FindIndexOfOrderItem("car") == 1);
        }

        [TestMethod()]
        public void AddOrderItemTest()
        {
            order.AddOrderItem(plane, 1);     // 添加订单内没有的物品

            Assert.IsTrue(order.OrderItemAmount == 4);

            order.AddOrderItem(book, 5);    // 添加订单内已存在的，订单中物品数目不变，物品数目增加
            Assert.IsTrue(order.OrderItemAmount == 4);

            int bookIndex = order.FindIndexOfOrderItem("book");
            Assert.IsTrue(order.items[bookIndex].Quantity == 8);
        }

        [TestMethod()]
        public void RemoveOrderItemTest()
        {
            order.RemoveOrderItem("car");
            Assert.IsTrue(order.OrderItemAmount == 2);
            Assert.IsFalse(order.Contains("car"));
        }

        [TestCleanup()]
        public void RecoverNumbers()
        {
            book.Quantity = 100;
            car.Quantity = 5;
            milk.Quantity = 1000;
            plane.Quantity = 3;

            NumberManager.customerNumber = "000000";
            NumberManager.itemNumber = "000";
            NumberManager.orderNumber = "00000000";
        }
    }
}