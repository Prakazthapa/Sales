using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sales.Data;
using Sales.Models;

namespace Sales.Controllers
{
    public class SerialNumberController : Controller
    {
        private readonly SalesDbContext sdbc;

        public SerialNumberController(SalesDbContext sdbc)
        {
            this.sdbc = sdbc;
        }
        public IActionResult SerialNumberIndex()
        {
            IEnumerable<SelectListItem> Product = sdbc.Products.Select(u => new SelectListItem
            {
                Text = u.PName,
                Value = u.PId.ToString()
            });
            ViewBag.Product = Product;
            return View();
        }
        //public JsonResult SerialNumberList()
        //{
        //    var data = sdbc.SerialNumbers.ToList();
        //    return new JsonResult(data);
        //}

        public IActionResult SerialNumberList()
        {
            var data = sdbc.SerialNumbers.ToList();
            return Json(data);
        }

        public IActionResult SearchSerialNumberList(string searchString)
        {
            var data = sdbc.SerialNumbers.ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                data = data.Where(u => u.Serialno.Contains(searchString)).ToList();
            }
            return Json(data);
        }

        [HttpPost]
        public JsonResult AddSerialNumber(SerialNumber serialNumber)
        {
            if (ModelState.IsValid) {
                serialNumber.stock = "Y";

                if (!sdbc.SerialNumbers.Any( s=> s.Serialno == serialNumber.Serialno))
                {
                    sdbc.SerialNumbers.Add(serialNumber);
                    sdbc.SaveChanges();
                };

            }
            return new JsonResult("Data is Saved");
        }

        public JsonResult Delete(int id)
        {
            var data = sdbc.SerialNumbers.Where(e => e.SerialNumberId == id).SingleOrDefault();
            sdbc.SerialNumbers.Remove(data);
            sdbc.SaveChanges();
            return new JsonResult("Data deleted");
        }

        public JsonResult Edit(int id)
        {
            var data = sdbc.SerialNumbers.Where(e => e.SerialNumberId == id).SingleOrDefault();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult Update(SerialNumber serialNumber)
        {
            sdbc.SerialNumbers.Update(serialNumber);
            sdbc.SaveChanges();
            return new JsonResult("Record Updated!");
        }
    }
}
