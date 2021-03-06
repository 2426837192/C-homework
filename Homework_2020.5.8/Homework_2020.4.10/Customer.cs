﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2020._3._20
{
    // 顾客类
    public class Customer
    {
        [Key]
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }

        public List<Order> Orders { get; set; }

        public Customer(string name)
        {
            CustomerNumber = NumberManager.GetCustomerNumber();
            CustomerName = name.ToUpper();
        }

        public Customer()
        {
            CustomerNumber = NumberManager.GetCustomerNumber();
            CustomerName = "Unknown";
        }

        public override bool Equals(object obj)
        {
            var customer = obj as Customer;
            return customer != null &&
                   CustomerNumber == customer.CustomerNumber;
        }

        public override int GetHashCode()
        {
            return 276478820 + EqualityComparer<string>.Default.GetHashCode(CustomerNumber);
        }

        public override string ToString()
        {
            return CustomerNumber + ", " + CustomerName ;
        }
    }
}
