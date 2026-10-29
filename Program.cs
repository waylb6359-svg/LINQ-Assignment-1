using static LINQ_Assignment_1.Source;
namespace LINQ_Assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Q1: 

            var seafood = ProductList.Where(p => p.Category == "Seafood");
            foreach (var p in seafood)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C2}");
            #endregion

            #region Q2:

            var names = ProductList.Select(p => p.ProductName);
            foreach (var name in names)
                Console.WriteLine(name);
            #endregion

            #region Q3:

            var sortedByPrice = ProductList.OrderBy(p => p.UnitPrice);
            foreach (var p in sortedByPrice)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C2}");
            #endregion

            #region Q4:

            var between = ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
            foreach (var p in between)
                Console.WriteLine(p);
            #endregion

            #region Q5: 

            var condiments = ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Spices & Condiments");
            foreach (var p in condiments)
                Console.WriteLine(p);
            #endregion

            #region Q6: 
            
            var projected = ProductList.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });
            foreach (var item in projected)
                Console.WriteLine($"{item.Name} | {item.Price:C2} | {item.StockStatus}");
            #endregion

            #region Q7: 

            var withIndex = ProductList.Select((p, index) => $"{index + 1}. {p.ProductName}");
            foreach (var item in withIndex)
                Console.WriteLine(item);
            #endregion

            #region Q8: 

            var sortedTwoLevels = ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            foreach (var p in sortedTwoLevels)
                Console.WriteLine($"{p.Category} | {p.ProductName} | {p.UnitPrice:C2}");
            #endregion

            #region Q9: 

            var beverages = ProductList.Where(p => p.Category == "Beverages").OrderByDescending(p => p.UnitsInStock);
            foreach (var p in beverages)
                Console.WriteLine($"{p.ProductName} - Stock: {p.UnitsInStock}");
            #endregion

            #region Q10: 

            var recentOrders = from c in CustomerList
                               from o in c.Orders
                               where o.OrderDate.Year >= 1997
                               select new { c.CustomerID, o.OrderDate };
            foreach (var item in recentOrders)
                Console.WriteLine($"{item.CustomerID} - {item.OrderDate:d}");
            #endregion

            #region Q11: 

            var numbered = ProductList.Select((p, i) => new { Position = i + 1, p.ProductName });
            foreach (var item in numbered)
                Console.WriteLine($"{item.Position} - {item.ProductName}");
            #endregion

            #region Q12:

            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var sortedWords = Arr.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            foreach (var w in sortedWords)
                Console.WriteLine(w);

            #endregion


            #region Q13:


            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var reversedI = digits.Where(d => d[1] == 'i').Reverse();
            foreach (var d in reversedI)
                Console.WriteLine(d);
            #endregion




        }
    }
}
