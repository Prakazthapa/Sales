using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Sales.Data;
using Sales.Models;

namespace Sales.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult ProductIndex()
        {
            return View();
        }
        private readonly SalesDbContext sdbc;

        public ProductController(SalesDbContext sdbc)
        {
            this.sdbc = sdbc;
        }

        //public JsonResult ProductList()
        //{
        //    var data = sdbc.Products.ToList();
        //    return new JsonResult(data);
        //}
        public IActionResult ProductList()
        {
            var data = sdbc.Products.ToList();
            return Json(data);
        }

        public IActionResult SearchProductList(string searchString)
        {
            var data = sdbc.Products.ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                data = data.Where(u => u.PName.Contains(searchString)).ToList();
            }
            return Json(data);
        }

        [HttpPost]
        public JsonResult AddProduct(Product product)
        {
            try
            {
                if (ModelState.IsValid) {
                    var prod = new Product()
                    {
                        PName = product.PName,
                        PDescription = product.PDescription,
                        price = product.price

                    };
                    sdbc.Products.Add(prod);
                    sdbc.SaveChanges();
                    return new JsonResult("Data is Saved");
                }
                else
                {
                    return new JsonResult("Invalid model state");
                }

            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx && (sqlEx.Number == 2601 || sqlEx.Number == 2627))
                {
                    
                    return new JsonResult("Product name already exists!!!");
                }
                else
                {
                    
                    return new JsonResult("An error occurred. Please try again later.");
                }
            }
            catch (Exception ex)
            {
              
                return new JsonResult("An error occurred. Please try again later.");
            }
        
        }

        public JsonResult Delete(int id)
        {
            var data = sdbc.Products.Where(e => e.PId == id).SingleOrDefault();
            sdbc.Products.Remove(data);
            sdbc.SaveChanges();
            return new JsonResult("Data deleted");
        }

        public JsonResult Edit(int id)
        {
            var data = sdbc.Products.Where(e => e.PId == id).SingleOrDefault();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult Update(Product product)
        {
            sdbc.Products.Update(product);
            sdbc.SaveChanges();
            return new JsonResult("Record Updated!");
        }
    }
}
