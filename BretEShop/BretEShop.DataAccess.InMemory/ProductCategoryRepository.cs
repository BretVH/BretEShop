﻿using BretEShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace BretEShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories = new List<ProductCategory>();

        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }

        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);
        }

        public void Update(ProductCategory p)
        {
            ProductCategory productCategoryToUpdate = Find(p.Id);

            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = p;
            }
        }

        public ProductCategory Find(String Id)
        {
            ProductCategory productCategory = productCategories.Find(x => x.Id == Id);

            if (productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Could not find productCategory!");
            }
        }

        public IQueryable<ProductCategory> GetProductCategories()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory productCategoryToDelete = Find(Id);

            if (productCategoryToDelete != null)
            {
                productCategories.Remove(productCategoryToDelete);
            }

        }
    }
}
