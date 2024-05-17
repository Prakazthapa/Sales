using Microsoft.AspNetCore.Mvc;
using Sales.Data;
using Sales.Models;

namespace Sales.Controllers
{
    public class TestController : Controller
    {

        private readonly SalesDbContext _db;
       
        public TestController(SalesDbContext db)
        {
            _db = db;
        }

        public IActionResult AutocompleteTest()
        {
            return View();
        }
        public JsonResult getProvince()
        {
            List<Province> data = _db.Province.ToList();
            return Json(data);
        }

        public JsonResult getDistrict(int? id)
        {
            List<District> data = _db.District.Where(u => u.ProvinceId == id).ToList();
            return Json(data);
        }

        public JsonResult getLocalbody(int? id)
        {
            //List<LocalBody>? data = _db.LocalBody.Where(u => u.DistrictId == id).ToList();
            LocalBody data= (_db.LocalBody.FirstOrDefault(u => u.DistrictId == id));
            IEnumerable<LocalBody> data2 = _db.LocalBody.ToList().Where(u=>u.DistrictId==id);
            return Json(new
            {
                lia= data
            });
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
