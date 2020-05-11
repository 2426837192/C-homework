using Homework_2020._3._20;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2020._5._8
{
    class OrderContext:DbContext
    {
        public OrderContext(bool ifInitilize):base("OrderDataBase")
        {
            if(ifInitilize==true)
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<OrderContext>());
            }
            else
            {
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OrderContext>());
            }
        }

        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .HasOptional<Order>(s => s.Order)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
        */

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderService> OrderServices { get; set; }
    }
}
