using BretEShop.Core.Contracts;
using BretEShop.Core.Models;
using BretEShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bret.DataAccess.Web.Controllers
{
    public class HomeController : Controller
    {

        IRepository<Product> context;
        IRepository<ProductCategory> productCategoriesContext;
        public HomeController(IRepository<Product> context, IRepository<ProductCategory> productCategoriesContext)
        {
            this.context = context;
            this.productCategoriesContext = productCategoriesContext;
        }
        public ActionResult Index(string Category = null)
        {
            List<Product> products;
            List<ProductCategory> categories = productCategoriesContext.GetItems().ToList();

            if (Category == null)
            {
                products = context.GetItems().ToList();
            }
            else
            {
                products = context.GetItems().Where(p => p.Category == Category).ToList();
            }

            ProductListViewModel model = new ProductListViewModel();
            model.Products = products;
            model.ProductCategories = categories;
            
            return View(model);
        }

        public ActionResult Details(string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
                return HttpNotFound();
            return View(product);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}