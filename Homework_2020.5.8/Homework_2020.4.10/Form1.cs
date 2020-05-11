using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Homework_2020._3._20;

namespace Homework_2020._5._8
{
    public partial class Form1 : Form
    {
        Shop myShop;

        public Form1()
        {
            InitializeComponent();

            myShop = new Shop();
            Item apple = new Item("Apple", 3, 500);
            Item computer = new Item("Computer", 3000, 104);
            Item banana = new Item("Banana", 2, 9000);
            Item cellPhone = new Item("Cell Phone", 8000, 40);
            Item bottle = new Item("Bottle", 10, 300);
            Item milk = new Item("Milk", 5, 4000);
            Item toiletPaper = new Item("Toilet Paper", 1, 50000);
            Item mask = new Item("Mask", 1, 4000);
            Item pencil = new Item("Pencil", 0.3, 5000);
            Item book = new Item("Book", 2, 4000);
            Item shirt = new Item("Shirt", 20, 360);

            myShop.AddItem(apple);
            myShop.AddItem(computer);
            myShop.AddItem(banana);
            myShop.AddItem(cellPhone);
            myShop.AddItem(bottle);
            myShop.AddItem(milk);
            myShop.AddItem(toiletPaper);
            myShop.AddItem(mask);
            myShop.AddItem(pencil);
            myShop.AddItem(book);
            myShop.AddItem(shirt);

            myShop.OrderService.AddOrder("zhong yuan");

            myShop.Sell("Apple", 3, myShop.OrderService.Orders[0]);
            myShop.Sell("Milk", 3, myShop.OrderService.Orders[0]);

            myShop.OrderService.AddOrder("zhang qianshu");
            myShop.Sell("Book", 1, myShop.OrderService.Orders[1]);
            myShop.Sell("shirt", 1, myShop.OrderService.Orders[1]);

            myShop.OrderService.AddOrder("meng suhua");
            myShop.Sell("Cell phone", 1, myShop.OrderService.Orders[2]);
            myShop.Sell("computer", 2, myShop.OrderService.Orders[2]);
            myShop.Sell("shirt", 3, myShop.OrderService.Orders[2]);
            myShop.Sell("toilet paper", 13, myShop.OrderService.Orders[2]);

            // 初始数据载入数据库
            using (var db = new OrderContext(true)) 
            {
                db.Shops.Add(myShop);

                db.SaveChanges();
            }

            waysComboBox.Items.Add("通过订单名检索");
            waysComboBox.Items.Add("通过商品名检索");
            waysComboBox.Items.Add("通过顾客名检索");

            orderBindingSource.DataSource = myShop.OrderService.Orders;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void BtnPurchase_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.items = myShop.Items;
            form2.myShop = this.myShop;

            form2.ShowDialog();
            orderBindingSource.ResetBindings(false);

            messageLabel.Text = "状态：添加订单成功";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Order thisOrder = (Order)orderBindingSource.Current;
            myShop.OrderService.DeleteOrder(thisOrder.OrderNumber);

            orderBindingSource.ResetBindings(true);

            // 从数据库中删除
            using (var db = new OrderContext(false)) 
            {
                var order = db.Orders.Include("Items").FirstOrDefault(p => p.OrderNumber == thisOrder.OrderNumber);
                
                if (order != null)
                {
                    db.Entry(order).State = System.Data.Entity.EntityState.Deleted;

                    db.SaveChanges();
                }
            }

            messageLabel.Text = "状态：删除订单成功";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ordersSaveFileDialog.Filter = "XML文件|*.xml";
            ordersSaveFileDialog.DefaultExt = "xml";
            ordersSaveFileDialog.AddExtension = true;

            if(ordersSaveFileDialog.ShowDialog()==DialogResult.OK)
            {
                myShop.OrderService.Export(ordersSaveFileDialog.FileName);
            }

            messageLabel.Text = "状态：导出成功";
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ordersOpenFileDialog.Title = "导入订单";
            ordersOpenFileDialog.Filter = "XML文件|*.xml";

            ordersOpenFileDialog.FileName = "";
            ordersOpenFileDialog.DefaultExt = "xml";

            if(ordersOpenFileDialog.ShowDialog()==DialogResult.OK)
            {
                myShop.OrderService.Import(ordersOpenFileDialog.FileName);

                orderBindingSource.DataSource = myShop.OrderService.Orders;
                orderBindingSource.ResetBindings(true);
            }

            messageLabel.Text = "状态：导入成功";
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = myShop.OrderService.Orders;
            orderBindingSource.ResetBindings(true);

            messageLabel.Text = "状态：正常";
        }

        // 由于bingdingSource绑定内存，故未实现对数据库直接进行查询，仍然是在内存中查询，但原理相同
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int sign = waysComboBox.SelectedIndex;

            string keyWords = keyWordsTextBox.Text;

            try
            {
                var selectedOrders = myShop.OrderService.FindOrder(keyWords, sign);

                List<Order> resultOrders = new List<Order>();
                foreach(var order in selectedOrders)
                {
                    resultOrders.Add(order);
                }

                orderBindingSource.DataSource = resultOrders;

                messageLabel.Text = "状态：正常";
            }
            catch(OrderNotExist)
            {
                messageLabel.Text = "状态：您查询的订单不存在";
            }
            catch(CustomerNotExistException)
            {
                messageLabel.Text = "状态：不存在该顾客的订单";
            }
            catch(OrderItemNotExist)
            {
                messageLabel.Text = "状态：没有订单中有该物品";
            }
            catch(InvalidSearchException)
            {
                messageLabel.Text = "状态：未选择检索方式";
            }
        }
    }
}
