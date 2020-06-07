using BretEShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace BretEShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products = new List<Product>();

        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if(products == null)
            {
                products = new List<Product>();
            }
        }

        public void Commit()
        {
            cache["products"] = products;
        }

        public void Insert(Product p)
        {
            products.Add(p);
        }

        public void Update(Product p)
        {
            Product productToUpdate = Find(p.Id);

            if(productToUpdate != null)
            {
                productToUpdate = p;
            }
        }

        public Product Find(String Id)
        {
            Product product = products.Find(x => x.Id == Id);

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Could not find product!");
            }
        }

        public IQueryable<Product> GetProducts()
        {
            return products.AsQueryable();
        }

        public void Delete(string Id)
        {
            Product productToDelete = Find(Id);

            if(productToDelete != null)
            {
                products.Remove(productToDelete);
            }

        }
    }
}
