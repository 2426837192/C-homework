using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2020._3._20
{
    // 商店类
    class Order
    {
        public string OrderNumber { get; set; }
        public Customer customer;
        public List<OrderItem> items = new List<OrderItem>();
        int orderItemAmount = 0;
        public int OrderItemAmount { get => orderItemAmount; }
        public double TotalPrice
        {
            get
            {
                double totalPrice = 0;
                foreach(OrderItem item in items)
                {
                    totalPrice += item.UnitPrice * item.Quantity;
                }

                return totalPrice;
            }
        }

        public Order(Customer customer)
        {
            OrderNumber = NumberManager.GetOrderNumber();
            this.customer = customer;
        }

        // 通过某一物品的名字，判断是否在明细里
        public bool Contains(string itemName)
        {
            foreach(OrderItem item in items)
            {
                if (item.Description == itemName) 
                    return true;
            }
            return false;
        }

        // 根据商品名称查询在商品明细中的索引
        public int FindIndexOfOrderItem(string description)
        {
            int i = 0;
            foreach(OrderItem item in items)
            {
                if (item.Description == description)
                    return i;
            }

            throw new OrderItemNotExist(description);
        }

        public void AddOrderItem(Item item,int purchaseQuantity)
        {
            // 如果该件物品已在消费明细中存在，就只是在该条明细后添加数量
            if(Contains(item.Description))
            {
                int itemIndex = FindIndexOfOrderItem(item.Description);
                items[itemIndex].Quantity += purchaseQuantity;
            }
            // 否则新加入一条消费明细
            else
            {
                items.Add(new OrderItem(item, purchaseQuantity));
                orderItemAmount++;
            }
        }

        public void RemoveOrderItem(string description)
        {
            items.RemoveAt(FindIndexOfOrderItem(description));
            orderItemAmount--;
        }

        public override string ToString()
        {
            string result = "-----------------------------\n";
            result += "-----------------------------\n";
            result += "OrderNumber: " + OrderNumber + "\n";
            result += "Customer: " + customer + "\n";
            result += "-----------------------------\n";
            result += "Item NO.  Description  Quantity  UnitPrice\n";
            foreach (OrderItem orderItem in items)
            {
                result += orderItem;
            }
            result += "-----------------------------\n";
            result += "Item Amount" + this.OrderItemAmount + "\n";
            result += "Total Price: $" + this.TotalPrice + "\n";
            result += "-----------------------------\n";
            result += "-----------------------------\n";

            return result;
        }

        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null &&
                   OrderNumber == order.OrderNumber;
        }

        public override int GetHashCode()
        {
            return -247030458 + EqualityComparer<string>.Default.GetHashCode(OrderNumber);
        }
    }
}
