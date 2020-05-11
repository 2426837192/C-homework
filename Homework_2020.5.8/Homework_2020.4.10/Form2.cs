using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Homework_2020._3._20;

namespace Homework_2020._5._8
{
    public partial class Form2 : Form
    {
        public List<Item> items;
        public Shop myShop;
        public Order newOrder;

        public Form2()
        {
            InitializeComponent();
            newOrder = new Order();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach(Item item in items)
            {
                itemComboBox.Items.Add(item.Description);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                messageLabel.Text = "状态：正常";
                string purchaseItem = (string)itemComboBox.SelectedItem;
                int purchaseAmount = int.Parse(purchaseAmountTextBox.Text);

                myShop.Sell(purchaseItem, purchaseAmount, newOrder);
            }
            catch(NotInShopException)
            {
                messageLabel.Text = "状态：该物品不在仓库中！";
            }
            catch(SoldOutException)
            {
                messageLabel.Text = "状态：商品库存不足！";
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            newOrder.Customer.CustomerName = customerNameTextBox.Text.ToUpper();

            myShop.OrderService.Orders.Add(newOrder);

            // 将新订单添加到数据库中
            using (var db = new OrderContext(false)) 
            {
                newOrder.OrderServiceNumber = myShop.OrderService.OrderServiceNumber;

                db.Orders.Add(newOrder);
                db.SaveChanges();
            }
            this.Close();
        }
    }
}
