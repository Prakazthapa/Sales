using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sales.Data;
using Sales.Models;

namespace Sales.Controllers
{
    public class CustomerController : Controller
    {
        private readonly SalesDbContext sdbc;

        public CustomerController(SalesDbContext sdbc)
        {
            this.sdbc = sdbc;
        }
        public IActionResult CustomerIndex()
        {
            return View();
        }

        public JsonResult getProvince()
        {
            List<Province> data = sdbc.Province.ToList();
            return Json(data);
        }

        public JsonResult getDistrict(int? id)
        {
            List<District> data = sdbc.District.Where(u => u.ProvinceId == id).ToList();
            return Json(data);
        }

        public JsonResult getLocalbody(int? id)
        {
            List<LocalBody>? data = sdbc.LocalBody.Where(u => u.DistrictId == id).ToList();
            return Json(data);
        }

        public IActionResult CustomerList()
        {
            var data = sdbc.Customers.ToList();
            return Json(data);
        }

        public IActionResult SearchCustomerList(string searchString)
        {
            var data = sdbc.Customers.ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                data = data.Where(u => u.CName.Contains(searchString)).ToList();
            }
            return Json(data);
        }


        [HttpPost]
        public JsonResult AddCustomer(Customer customer)
        {
            if(ModelState.IsValid) { }
            var cust = new Customer()
            {
                CName = customer.CName,
                ProvinceId = customer.ProvinceId,
                DistrictId = customer.DistrictId,
                LocalBodyId = customer.LocalBodyId,
                wardno = customer.wardno,
                MobileNumber = customer.MobileNumber,
                Email = customer.Email
                
            };
            sdbc.Customers.Add(cust);
            sdbc.SaveChanges();
            return new JsonResult("Data is Saved");
        }

        public JsonResult Delete(int id)
        {
            var data = sdbc.Customers.Where(e => e.CId == id).SingleOrDefault();
            sdbc.Customers.Remove(data);
            sdbc.SaveChanges();
            return new JsonResult("Data deleted");
        }

        public JsonResult Edit(int id)
        {
            var data = sdbc.Customers.Where(e => e.CId == id).SingleOrDefault();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult Update(Customer customer)
        {
            sdbc.Customers.Update(customer);
            sdbc.SaveChanges();
            return new JsonResult("Record Updated!");
        }
    }
}
