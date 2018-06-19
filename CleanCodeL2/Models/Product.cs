using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCodeL2.Models
{
    public class Product : IComparable<Product>
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public string Section { get; set; }

        public int CompareTo(Product other)
        {
            if (Id == other.Id)
            {
                return 0;
            }
            int x = ProductName.CompareTo(other.ProductName);
            if (x == 0)
                return Section.CompareTo(other.Section);
            return x;
        }
    }
}
