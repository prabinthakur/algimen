using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication35.Models;
using WebApplication35.Models.viewModel;

namespace WebApplication35.Controllers
{
    public class DriverController : Controller
    {

        AllgemeindbEntities db = new AllgemeindbEntities();

        // GET: Driver
        public ActionResult Index()
        {
            var driver = db.tbldriverlists.ToList();
            List<DriverViewMOodel> vm = new List<DriverViewMOodel>();
            foreach (var item in driver)
            {

                vm.Add(new DriverViewMOodel() { driverid = item.driverid, drivername = item.drivername, experience = item.experience.Value, salary = item.salary.Value, type = item.type });
            }



            return View(vm);
        }



        // GET: Driver/Create
        public ActionResult Create()
        {
            ViewBag.message = "driver added";
            return View();
        }

        // POST: Driver/Create
        [HttpPost]
        public ActionResult Create(DriverViewMOodel vm)
        {
            try
            {
                tbldriverlist tb = new tbldriverlist();
                tb.drivername = vm.drivername;
                tb.type = vm.type;
                tb.salary = vm.salary;
                tb.experience = vm.experience;
                db.tbldriverlists.Add(tb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult hiredriver()
        {

            var userid = @Session["username"].ToString();
            ViewBag.message = "driver hired by:userid";
            

            return View();
        }
        [HttpPost]
        public ActionResult hiredriver(hiredriverviewmodel vm)
        {
            tbldriver tb = new tbldriver();
            var userid = @Session["username"].ToString();
            tblCustomer tbl = db.tblCustomers.Where(u => u.FirstName == userid).FirstOrDefault();
            var customerid = tbl.Userid;

                tb.drivertype = "special";
                tb.hiredate = vm.hiredate;
                tb.cutomerid = customerid;
            tb.driverid = Convert.ToInt32(@TempData["userid"]);
                tb.salary = vm.salary;

            db.tbldrivers.Add(tb);
               db.SaveChanges();
            
               
            

            return View();
        }
        [HttpGet]
        public ActionResult driverid(int id)
        {

            tbldriverlist tb = db.tbldriverlists.Where(u => u.driverid == id).FirstOrDefault();

            TempData["userid"] = tb.driverid;
            TempData.Keep();

            return RedirectToAction("hiredriver", "driver");
        }
        public ActionResult driverid(tbldriverlist uv)
        {

            tbldriverlist tb = db.tbldriverlists.Where(u => u.driverid == uv.driverid).FirstOrDefault();

            TempData["userid"] = tb.driverid;
            TempData.Keep();
            return RedirectToAction("hiredriver", "driver");

        }


    }
}
