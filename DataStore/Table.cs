using DuncanSafeApp2024.Models;
using System.Collections.Generic;

namespace DuncanSafeApp2024.DataStore
{
    public static class Table
    {
        public static IList<Product> Products;
        private static int productCount = 0;
        public static int ProductCount { get { return ++productCount; } }

        public static IList<WatchListEntry> WatchListEntries;
        private static int watchListEntryCount = 0;
        public static int WatchListEntryCount { get { return ++watchListEntryCount; } }

        public static void Initialize()
        {
            Products = new List<Product>
            {
                new Product(ProductCount, "Outback", "Coconut Shrimp", 15.00d, 3),
                new Product(ProductCount, "Outback", "Steak", 22.00d, 21),
                new Product(ProductCount, "Five Guys", "Hamburger", 10.00d, 1),
                new Product(ProductCount, "McDonald's", "Chicken McGriddle", 3.00d, 25),
                new Product(ProductCount, "Wendy's", "Bacon Double Stack", 3.00d, 2),
                new Product(ProductCount, "Wawa", "Coffee", 2.12d, 3),
            };
            WatchListEntries = new List<WatchListEntry>
            {
                new WatchListEntry(WatchListEntryCount, "Five Guys", "Hamburger"),
                new WatchListEntry(WatchListEntryCount, "Apple", "MacBook"),
                new WatchListEntry(WatchListEntryCount, "Outback", "Bloomin Onion"),
            };
        }

    }
}