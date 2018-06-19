using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCodeL2.Models
{
    public class FakeApiRequestSend : IApiRequestSend<Product>
    {
        List<Product> products = new List<Product>()
        {
            new Product { Id = 0, Price = 12, ProductName = "Chair", Section = "A", Weight = 91},
            new Product { Id = 1, Price = 32, ProductName = "Table", Section = "B", Weight = 57},
            new Product { Id = 2, Price = 40, ProductName = "Lamp", Section = "B", Weight = 5}
        };

        public void AddEntity(Product product)
        {
            products.Add(product);
        }

        public void DeleteEntity(Product product)
        {
            if (products.Contains(product))
            {
                products.Remove(product);
            }
            else
            {
                throw new Exception("that product doesn't exist");
            }
        }

        public IEnumerable<Product> GetAllData()
        {
            return products;
        }

        public void ModifyEntity(int id, Product product)
        {
            if (products.Exists(p => p.Id == id))
            {
                var productToDelete = products.Where(p => p.Id == id).Single();
                products.Remove(productToDelete);
                products.Add(product);
            }
            else
            {
                throw new Exception("that product doesn't exist");
            }
        }

        public IEnumerable<Product> GetProductsInSection(string section)
        {
            return products.Where(p => p.Section == section);
        }

        public Product GetMostExpensiveProduct()
        {
            var highestPrice = products.Max(p => p.Price);
            var product = products.Where(p => p.Price == highestPrice).SingleOrDefault();
            
            return product;
        }
    }
}
