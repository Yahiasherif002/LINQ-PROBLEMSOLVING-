﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using static D10.ListGenerators;

namespace D10
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Where- Filteration
            //var result = ProductList.Where(P => P.UnitsInStock == 0);


            //result = from P in ProductList
            //         where P.UnitsInStock == 0
            //         select P;


            //Console.WriteLine(result);


            //result = ProductList.Where(p => (p.UnitsInStock == 0) && (p.Category == "Meat/Poultry"));


            //result = result.Where(R => R.ProductID < 30);


            ////Indexed Where
            //result = ProductList.Where((p, i) => p.UnitsInStock != 0 && i <= 10);

            //indexed where only works in Fluent syntax not in query Expression

            //foreach (var unit in result) { Console.WriteLine(unit); }
            #endregion

            #region Select - Transformation operator
            // transform every element in input sequence to a new o/p sequence of new or same data type

            //var result2 = ProductList.Select(p => p.ProductName); //product=>string

            //var result3 = ProductList.Where(P => P.UnitsInStock == 0) // product=>anonymus type
            //    .Select(P => new { P.ProductID, P.ProductName });

            //var discountedlist = ProductList.Select((p) => new Product()// product=>product
            //{

            //    ProductID=p.ProductID,
            //    ProductName=p.ProductName,
            //    Category=p.Category,
            //    UnitsInStock=p.UnitsInStock,
            //    UnitPrice=0.5m*p.UnitPrice
            //}).Where((n,i)=>i<25);

            //var discountedlist2 = ProductList.Select(p => new { id = p.ProductID, name = p.ProductName, price_after_discount = p.UnitPrice * 0.4m });

            //foreach(var unit in discountedlist2) { Console.WriteLine(unit); };
            #endregion

            /*
             Use ListGenerators.cs & Customers.xml
                1. Find all products that are out of stock.
                2. Find all products that are in stock and cost more than 3.00 per unit.
                3. Returns digits whose name is shorter than their value.
             */

            #region 1- Find all products that are out of stock.
            //var outOfStock = ProductList.Where(p => p.UnitsInStock == 0).Select(x=>new {id= x.ProductID , name=x.ProductName});

            //foreach(var item in outOfStock)
            //{
            //    Console.Write($"{item}|");
            //}
            #endregion

            #region 2. Find all products that are in stock and cost more than 3.00 per unit.
            //var inStock = ProductList.Where(p => (p.UnitsInStock != 0) && (p.UnitPrice > 3.00m)).Select(P=>new { P.ProductID, P.ProductName, P.UnitPrice });
            //foreach(var item in inStock)
            //{
            //    Console.WriteLine($"{item}|");
            //}


            #endregion

            #region 3. Returns digits whose name is shorter than their value.

            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            //var result = Arr.Where((d,i) => d.Length < i);

            //foreach (var item in result)
            //{
            //    Console.WriteLine($"{item}|");
            //}

            #endregion


            //1.Get first Product out of Stock
            //2.Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            //3.Retrieve the second number greater than 5

            #region 1.Get first Product out of Stock

            //var outOfStockFirst = ProductList.First(p => p.UnitsInStock == 0);

            //Console.WriteLine(outOfStockFirst);

            // foreach (var unit in outOfStockFirst) { Console.WriteLine(unit); }

            #endregion

            #region 2.Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            //var result = ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
            //Console.WriteLine(result);


            #endregion

            #region 3.Retrieve the second number greater than 5
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var res = Arr.Where(p => p > 5).Where((p,i)=>i==1);
            //foreach (int i in res) { Console.WriteLine(i); }

            //var result = Arr.Where(num => num > 5).
            //                Skip(1).
            //                FirstOrDefault();


            //Console.WriteLine($"Num is : {result}");

            #endregion

            #region   LINQ - Set Operators
            /*
                 Use ListGenerators.cs & Customers.xml
                   1. Find the unique Category names from Product List
                   2. Produce a Sequence containing the unique first letter from both product and customer names.
                   3. Create one sequence that contains the common first letter from both product and customer names.
                   4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.
                   5. Create one sequence that contains the last Three Characters in each names of all customers and products, including any duplicates
                */

            #region 1. Find the unique Category names from Product List

            //var UName = ProductList.Select(y => y.ProductName).Distinct();

            //foreach (var u in UName) { Console.WriteLine(u); };
            #endregion

            #region 2. Produce a Sequence containing the unique first letter from both product and customer names.

            //var uniqueFirstLetters = ProductList.Select(p => p.ProductName.FirstOrDefault())
            //                         .Concat(CustomerList.Select(c => c.CompanyName.FirstOrDefault()))
            //                         .Distinct();

            //foreach (var letter in uniqueFirstLetters)
            //{
            //    Console.WriteLine(letter);
            //}

            #endregion

            #region 3. Create one sequence that contains the common first letter from both product and customer names.


            //var commonFirstLetters = ProductList.Select(p => p.ProductName.FirstOrDefault())
            //                         .Intersect(CustomerList.Select(c => c.CompanyName.FirstOrDefault()))
            //                         .Distinct();

            //foreach (var letter in commonFirstLetters)
            //{
            //    Console.WriteLine(letter);
            //}



            #endregion

            #region 4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.

            //var notCommonLetter = ProductList.Select(p => p.ProductName.FirstOrDefault())
            //                      .Except(CustomerList.Select(c => c.CompanyName.FirstOrDefault()))
            //                      .Distinct();

            //foreach (var c in notCommonLetter) { Console.WriteLine(c); };

            #endregion

            #region 5. Create one sequence that contains the last Three Characters in each names of all customers and products, including any duplicates

            //var lastThree = ProductList.Select(p => p.ProductName.Substring(Math.Max(0, p.ProductName.Length - 3)))
            //                          .Concat(CustomerList.Select(c => c.CompanyName.Substring(Math.Max(0, c.CompanyName.Length - 3))));

            //foreach(var item in lastThree) { Console.WriteLine(item); }
            #endregion
            #endregion



            //LINQ - Aggregate Operators

            //    1.Uses Count to get the number of odd numbers in the array
            //    int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //                Use ListGenerators.cs & Customers.xml
            //    2.Return a list of customers and how many orders each has.
            //    3.Return a list of categories and how many products each has
            //    4.Get the total of the numbers in an array.
            //    int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //                
            //    6.Get the total units in stock for each product category.
            //   
            //    8.Get the cheapest price among each category's products
            //    9.Get the products with the cheapest price in each category(Use Let)
            //   
            //    11.Get the most expensive price among each category's products.
            //    12.Get the products with the most expensive price in each category.
            //   
            //    14.Get the average price of each category's products.


            #region 1.Uses Count to get the number of odd numbers in the array

            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var count = Arr.Count(A => A % 2 != 0);
            //Console.WriteLine(count);

            #endregion


            #region  2.Return a list of customers and how many orders each has.


            //var customers = CustomerList.Select(c => new { Name = c.CompanyName, NoOfOrders = c.Orders.Count() });

            //foreach (var customer in customers) { Console.WriteLine(customer); }
            #endregion

            #region 3.Return a list of categories and how many products each has

            //var categories = ProductList.GroupBy(p=>p.Category)
            //                             .Select(Group => new {category=Group.Key , noOfProducts=Group.Count()})
            //                             .ToList();
            //foreach (var category in categories) { Console.WriteLine(   category); }

            #endregion

            #region 4.Get the total of the numbers in an array.
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //int count = Arr.Count();
            //Console.WriteLine(count);
            #endregion

            #region 6.Get the total units in stock for each product category.
            //var productInStock = ProductList.GroupBy(p => p.Category ) 
            //                              .Select(Group => new { category = Group.Key, noOfUnitInStock = Group.Sum(p => p.UnitsInStock) });

            //var _productInStock = from product in ProductList
            //                      group product by product.Category into G
            //                      select new
            //                      {
            //                          category = G.Key,
            //                          UnitInStock = G.Sum(p => p.UnitsInStock)
            //                      };

            //foreach (var product in _productInStock) { Console.WriteLine(product); }

            #endregion

            #region 8.Get the cheapest price among each category's products
            //var cheapest = ProductList
            //                           .GroupBy(p => p.Category)
            //                           .Select(Group => new { Name = Group.Key, cheapestPrice = Group.Min(p => p.UnitPrice) });
            //foreach (var group in cheapest) { Console.WriteLine(group); }

            #endregion

            #region 9.Get the products with the cheapest price in each category(Use Let)
            //var cheapest = from product in ProductList
            //               group product by product.Category into groupedProducts
            //               let cheapestPrice = groupedProducts.Min(p => p.UnitPrice)
            //               select new { Category = groupedProducts.Key, Products = groupedProducts.Where(p => p.UnitPrice == cheapestPrice), CheapestPrice = cheapestPrice };

            //foreach (var product in cheapest)
            //{


            //    foreach (var cheapestProduct in product.Products)
            //    {
            //        Console.WriteLine($"  Product: {cheapestProduct.ProductName}, Price: {cheapestProduct.UnitPrice}");
            //    }
            //}

            #endregion

            #region 11.Get the most expensive price among each category's products.
            //var ex = from product in ProductList
            //         group product by product.Category into groupedproduct
            //         let mostEx = groupedproduct.Max(c => c.UnitPrice)
            //         select new { Category = groupedproduct.Key, product = mostEx };
            //foreach (var item in ex) { Console.WriteLine(item); }
            #endregion

            #region 12.Get the products with the most expensive price in each category.

            //var pex = from product in ProductList
            //          group product by product.Category into groupedproduct
            //          let maxPrice = groupedproduct.Max(p => p.UnitPrice)
            //          select new { Category = groupedproduct.Key, Products = groupedproduct.Where(p => p.UnitPrice == maxPrice), Price = maxPrice };

            //foreach (var product in pex)
            //{
            //    Console.WriteLine($"Category: {product.Category}, Max Price: {product.Price}");

            //    foreach (var maxPriceProduct in product.Products)
            //    {
            //        Console.WriteLine($"  Product: {maxPriceProduct.ProductName}, Price: {maxPriceProduct.UnitPrice}");
            //    }
            //}


            #endregion

            #region 14.Get the average price of each category's products.

            var average = from products in ProductList
                          group products by products.Category into g
                          let averagePrice = g.Average(a => a.UnitPrice)
                          select new { category = g.Key, averagePrice = averagePrice.ToString("C") };
            foreach (var product in average) { Console.WriteLine(product); }

            #endregion

        }


    }
}
