using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sales.Data;
using Sales.Models;

namespace Sales.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly SalesDbContext sdbc;

        public OrderDetailsController(SalesDbContext sdbc)
        {
            this.sdbc = sdbc;
        }
        public IActionResult OrderDetailsIndex()
        {
            IEnumerable<SelectListItem> Customer = sdbc.Customers.Select(u => new SelectListItem
           {
                Text = u.CName,
               Value = u.CId.ToString()
            });
            ViewBag.Customer = Customer;

            IEnumerable<SelectListItem> Order =  sdbc.Orders.Select(u => new SelectListItem
            {
                Text = u.OId.ToString(),
                Value = u.OId.ToString()
            });
            ViewBag.Order = Order;

            IEnumerable<SelectListItem> Product = sdbc.Products.Select(u => new SelectListItem
            {
                Text = u.PName,
                Value = u.PId.ToString()
            });
            ViewBag.Product = Product;

            return View();
        }
        

        public JsonResult OrderDetailsList()
        {
            var data = sdbc.OrderDetails.ToList();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult AddOrderDetails(OrderDetails orderdetails)
        {
            var ordet = new OrderDetails()
            {
                CId = orderdetails.CId,
                PId = orderdetails.PId,
                OId = orderdetails.OId,
                qantity= orderdetails.qantity,
                price = orderdetails.price,
                TotalPrice = orderdetails.TotalPrice
            };
            sdbc.OrderDetails.Add(ordet);
            sdbc.SaveChanges();
            return new JsonResult("Data is Saved");
        }

        public JsonResult Delete(int id)
        {
            var data = sdbc.OrderDetails.Where(e => e.ODId == id).SingleOrDefault();
            sdbc.OrderDetails.Remove(data);
            sdbc.SaveChanges();
            return new JsonResult("Data deleted");
        }

        public JsonResult Edit(int id)
        {
            var data = sdbc.OrderDetails.Where(e => e.ODId == id).SingleOrDefault();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult Update(OrderDetails orderdetails)
        {
            sdbc.OrderDetails.Update(orderdetails);
            sdbc.SaveChanges();
            return new JsonResult("Record Updated!");
        }
    }
}
