using LinquTask.Data;
using LinquTask.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LinquTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context = new();

            ////1 - List all customers' first and last names along with their email addresses. 
            //var q1 = context.Customers.Select(c => new { c.FirstName, c.LastName, c.Email });


            //foreach (var item in q1)
            //{
            //    Console.WriteLine($"FullName: {item.FirstName} {item.LastName} , Email: {item.Email}");
            //}


//            //2 - Retrieve all orders processed by a specific staff member(e.g., staff_id = 3). 
//            var q2 = context.Orders.Where(o => o.StaffId == 3);
//            foreach (var item in q2)
//            {
//                Console.WriteLine($"OrderId: {item.OrderId} - StaffId:{item.StaffId} - Orderdate: {item.OrderDate} ");
//            }


//            //3 - Get all products that belong to a category named "Mountain Bikes".
//            var q3 = context.Products.Include(p => p.Category).Where(p => p.Category.CategoryName == "Mountain Bikes");

//            foreach (var item in q3)
//            {
//                Console.WriteLine($"ProductName:{item.ProductName}  CategoryName:{item.Category.CategoryName}");
//            }


//            //4-Count the total number of orders per store. 

//            var orderCountPerStore = context.Orders.GroupBy(o => o.StoreId)
//                .Select(g => new { StoreId = g.Key, orderCount = g.Count() });

//            foreach (var item in orderCountPerStore)
//            {
//                Console.WriteLine($"Store:{item.StoreId} Orders:{item.orderCount}");
//            }


//            //5- List all orders that have not been shipped yet (shipped_date is null). 

//            var notShippedOrders = context.Orders.Where(o => o.ShippedDate == null);
//            foreach (var item in notShippedOrders)
//            {
//                Console.WriteLine($"OrderId:{item.OrderId} ShippedDate:{item.ShippedDate}");
//            }


//            //6- Display each customer’s full name and the number of orders they have placed. 

//            var customerOrders = context.Orders
//                 .GroupBy(o => o.CustomerId)
//                      .Select(g => new
//                      {
//                          CustomerId = g.Key,
//                          OrderCount = g.Count()
//                      })
//                    .Join(context.Customers,
//                    o => o.CustomerId,
//                    c => c.CustomerId,
//                    (o, c) => new
//                    {
//                        FullName = c.FirstName + " " + c.LastName,
//                        Orders = o.OrderCount
//                    })
//                    .ToList();


//            foreach (var item in customerOrders)
//            {
//                Console.WriteLine($"Customer: {item.FullName}, Orders: {item.Orders}");
//            }


//            //7 - List all products that have never been ordered(not found in order_items).

//            var unorderedProducts = context.Products
//              .Where(p => !context.OrderItems.Any(oi => oi.ProductId == p.ProductId))
//               .ToList();

//            foreach (var products in unorderedProducts)
//            {
//                Console.WriteLine($"Unordered Product: {products.ProductName}");
//            }


//            //8- Display products that have a quantity of less than 5 in any store stock.


//            var lowStockProducts = context.Products
//             .Where(p => context.Stocks
//                 .Any(s => s.ProductId == p.ProductId && s.Quantity < 5))
//                .ToList();

//            foreach (var p in lowStockProducts)
//            {
//                Console.WriteLine($"Product: {p.ProductName} has low stock in at least one store.");
//            }


//            //9- Retrieve the first product from the products table.

//            var firstProduct = context.Products.FirstOrDefault();

//            if (firstProduct != null)
//            {
//                Console.WriteLine($"First product: {firstProduct.ProductName}");
//            }
//            else
//            {
//                Console.WriteLine("No products found.");
//            }


//            //10- Retrieve all products from the products table with a certain model year.




//            var productsByYear = context.Products
//                .Where(p => p.ModelYear == 2019)
//                .ToList();

//            foreach (var products in productsByYear)
//            {
//                Console.WriteLine($"Product: {products.ProductName}, Year: {products.ModelYear}");
//            }


//            // 11 - Display each product with the number of times it was ordered. 
//            var productOrderCounts = context.Products
//                .Select(p => new
//                {
//                    ProductName = p.ProductName,
//                    OrderCount = context.OrderItems.Count(oi => oi.ProductId == p.ProductId)
//                });

//            foreach (var item in productOrderCounts)
//            {
//                Console.WriteLine($"Product: {item.ProductName}, Ordered: {item.OrderCount} times");
//            }



//            // 12 - Count the number of products in a specific category.

//            string targetCategoryName = "Mountain Bikes";

//            int count = context.Products
//                .Where(p => p.Category.CategoryName == targetCategoryName)
//                .Count();

//            Console.WriteLine($"Number of products in '{targetCategoryName}' category: {count}");



//            //13- Calculate the average list price of products.

//            var averagePrice = context.Products
//               .Average(p => p.ListPrice);

//            Console.WriteLine($"Average List Price: {averagePrice:C}");


//            //14- Retrieve a specific product from the products table by ID. 

//            var product = context.Products.Find(5);

//            if (product != null)
//            {
//                Console.WriteLine($"Product found: {product.ProductName}, Price: {product.ListPrice}");
//            }
//            else
//            {
//                Console.WriteLine("Product not found.");
//            }


//            //15- List all products that were ordered with a quantity greater than 3 in any order. 

//            var productsOrderedMoreThan3 = context.Products
//               .Where(p => context.OrderItems
//                 .Any(oi => oi.ProductId == p.ProductId && oi.Quantity > 3))
//                 .ToList();

//            foreach (var products in productsOrderedMoreThan3)
//            {
//                Console.WriteLine($"Product: {product.ProductName}");
//            }


//            //16- Display each staff member’s name and how many orders they processed. 

//            var staffOrders = from s in context.Staffs
//                              join o in context.Orders
//                              on s.StaffId equals o.StaffId into staffGroup
//                              select new
//                              {
//                                  FullName = s.FirstName + " " + s.LastName,
//                                  OrderCount = staffGroup.Count()
//                              };

//            foreach (var s in staffOrders)
//            {
//                Console.WriteLine($"Staff: {s.FullName}, Orders Processed: {s.OrderCount}");
//            }



//            //17 - List active staff members only(active = true) along with their phone numbers.


//                var activeStaff = context.Staffs
//               .Where(s => s.Active == 1)
//               .ToList();

//            foreach (var staff in activeStaff)
//            {
//                Console.WriteLine($"Name: {staff.FirstName}, Phone: {staff.Phone}");
//            }


//            //18- List all products with their brand name and category name.

//            var productsWithDetails = from p in context.Products
//                                      join b in context.Brands on p.BrandId equals b.BrandId
//                                      join c in context.Categories on p.CategoryId equals c.CategoryId
//                                      select new
//                                      {
//                                          ProductName = p.ProductName,
//                                          BrandName = b.BrandName,
//                                          CategoryName = c.CategoryName
//                                      };

//            foreach (var item in productsWithDetails)
//            {
//                Console.WriteLine($"Product: {item.ProductName}, Brand: {item.BrandName}, Category: {item.CategoryName}");
//            }


//            //19- Retrieve orders that are completed. 

//            var completedOrders = context.Orders
//             .Where(o => o.OrderStatus == 1)
//               .ToList();

//            foreach (var order in completedOrders)
//            {
//                Console.WriteLine($"Order ID: {order.OrderId} is completed.");
//            }




//            //20- List each product with the total quantity sold (sum of quantity from order_items).

//            var productSales = context.Products
//             .GroupJoin(context.OrderItems,
//               product => product.ProductId,
//               orderItem => orderItem.ProductId,
//               (product, orderItems) => new
//               {
//                   ProductName = product.ProductName,
//                   TotalQuantitySold = orderItems.Sum(oi => oi.Quantity)
//               })
//        .ToList();

//            foreach (var item in productSales)
//            {
//                Console.WriteLine($"Product: {item.ProductName}, Total Sold: {item.TotalQuantitySold}");
//            }









//        }
//    }
//}
