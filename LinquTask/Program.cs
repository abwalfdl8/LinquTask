using LinquTask.Data;
using LinquTask.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;

namespace LinquTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context = new();

            ////1 - List all customers' first and last names along with their email addresses. 
            //var q1 = context.Customers.Select(c => new {c.FirstName ,c.LastName ,c.Email});


            // foreach (var item in q1)
            // {
            //     Console.WriteLine($"FullName: {item.FirstName} {item.LastName} , Email: {item.Email}");
            // }


            ////2 - Retrieve all orders processed by a specific staff member(e.g., staff_id = 3). 
            //var q2 = context.Orders.Where(o => o.StaffId == 3);
            //foreach (var item in q2)
            //{
            //    Console.WriteLine($"OrderId: {item.OrderId} - StaffId:{item.StaffId} - Orderdate: {item.OrderDate} ");
            //}


            ////3 - Get all products that belong to a category named "Mountain Bikes".
            //var q3 = context.Products.Include(p => p.Category).Where(p => p.Category.CategoryName == "Mountain Bikes");

            //foreach (var item in q3)
            //{
            //    Console.WriteLine($"ProductName:{item.ProductName}  CategoryName:{item.Category.CategoryName}");
            //}


            ////4-Count the total number of orders per store. 

            //var orderCountPerStore = context.Orders.GroupBy(o => o.StoreId)
            //    .Select(g =>new {StoreId=g.Key,orderCount=g.Count()});

            //foreach (var item in orderCountPerStore)
            //{
            //    Console.WriteLine($"Store:{item.StoreId} Orders:{item.orderCount}");
            //}


            ////5- List all orders that have not been shipped yet (shipped_date is null). 

            //var notShippedOrders = context.Orders.Where(o => o.ShippedDate == null);
            //foreach (var item in notShippedOrders)
            //{
            //    Console.WriteLine($"OrderId:{item.OrderId} ShippedDate:{item.ShippedDate}");
            //}


            //6- Display each customer’s full name and the number of orders they have placed. 

            var customerOrders = context.Orders.Include(o=>o.Customer).Where()

             foreach (var item in customerOrders)
            {
                Console.WriteLine($"Customer: {item.}, Orders: {item.Orders}");
            }








        }
    }
}
