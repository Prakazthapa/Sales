using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sales.Data;
using Sales.Models;
using System.Collections.Generic;

namespace Sales.Controllers
{
    public class OrderController : Controller
    {
        private readonly SalesDbContext sdbc;

        public OrderController(SalesDbContext sdbc)
        {
            this.sdbc = sdbc;
        }
        public IActionResult OrderIndex()
        {
            IEnumerable<SelectListItem> Customer = sdbc.Customers.Select(u => new SelectListItem
            {
                Text = u.CName,
                Value = u.CId.ToString()
            });
            ViewBag.Customer = Customer;

            IEnumerable<SelectListItem> Product = sdbc.Products.Select(u => new SelectListItem
            {
                Text = u.PName,
                Value = u.PId.ToString()
            });
            ViewBag.Product = Product;

            //IEnumerable<SelectListItem> SerialNumber = sdbc.SerialNumbers.Select(u => new SelectListItem
            //{
            //    Text = u.Serialno,
            //    Value = u.SerialNumberId.ToString()
            //});
            //ViewBag.SerialNumber = SerialNumber;
            return View();
        }


        public JsonResult serid(int? id) 
        {
            List<SerialNumber> data= sdbc.SerialNumbers.Where(u=>u.PId==id).ToList();
            return Json(data);
        }

        public JsonResult OrderList()
        {
            var data = sdbc.Orders.ToList();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult AddOrder(Order order)
        {
            try
            {
                List<SerialNumber> data= sdbc.SerialNumbers.Where(u => u.PId == order.PId && u.stock=="Y").ToList();    
                if (order.Quantity>data.Count())
                {
                    throw new Exception("Error not enough Item in stock");
                }
                var ord = new Order()
                {
                    CId = order.CId,
                    PId = order.PId,
                    //SerialNumberId = order.SerialNumberId,
                    ODateTime = order.ODateTime,
                    Quantity = order.Quantity,
                    TotalAmount = order.Quantity * sdbc.Products.FirstOrDefault(u => u.PId == order.PId).price

                };
                sdbc.Orders.Add(ord);
                sdbc.SaveChanges();

                for (int i = 0; i < order.Quantity; i++)
                {
                    data[i].stock = "N";
                    data[i].OId = ord.OId;
                    sdbc.SerialNumbers.Update(data[i]);
                }

                sdbc.SaveChanges();
            }

            catch (Exception ex) 
            {
                return new JsonResult(new {
                    success=false,
                    message=ex.Message
                });
            }

            return new JsonResult(new
            {
                success = true,
                message = "Data Saved"
            }) ;
        }


        public JsonResult Delete(int id)
        {

            var data = sdbc.Orders.Where(e => e.OId == id).SingleOrDefault();
            List<SerialNumber> data1 = sdbc.SerialNumbers.Where(u => u.OId == data.OId && u.stock == "N").ToList();
            foreach (SerialNumber serialNumber in data1)
            {
                serialNumber.OId = null;
                serialNumber.stock= "Y";
                sdbc.SerialNumbers.Update(serialNumber);
            }
            sdbc.Orders.Remove(data);
            sdbc.SaveChanges();
            return new JsonResult("Data deleted");
        }

        public JsonResult Edit(int id)
        {
            var data = sdbc.Orders.Where(e => e.OId == id).SingleOrDefault();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult Update(Order order)
        {
            sdbc.Orders.Update(order);
            sdbc.SaveChanges();
            return new JsonResult("Record Updated!");
        }

        


    }
}
