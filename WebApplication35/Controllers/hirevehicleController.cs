using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication35.Models;
using WebApplication35.Models.viewModel;

namespace WebApplication35.Controllers
{
    public class hirevehicleController : Controller
    {
        AllgemeindbEntities db = new AllgemeindbEntities();
            public ActionResult getvehicle()
            {
                var veh = db.tblVehicels.ToList();
                List<vehicleViewModel> vm = new List<vehicleViewModel>();
                foreach (var item in veh)
                {
                    vm.Add(new vehicleViewModel() { vehicleid = item.VehicleId, vehicleNumber = item.VehicleNumber, vehiclePrice = item.vehiclePrice, vehicletype = item.Vehicletype, photo = item.vehiclePhoto });

                }

                return View(vm);
             
           }
        [HttpGet]
        [Authorize(Roles ="Customer")]
        public ActionResult hirevehicle(int id)
        {
            tblVehicel tbl = db.tblVehicels.Where(u => u.VehicleId == id).FirstOrDefault();
            vehicleViewModel vm = new vehicleViewModel();
            vm.vehicleid = tbl.VehicleId;
            vm.vehicleNumber = 0;
            vm.vehiclePrice = tbl.vehiclePrice;
            vm.photo = tbl.vehiclePhoto;
            vm.vehicletype = tbl.Vehicletype;
            return View(vm);
        }
        [HttpPost]
        public ActionResult hirevehicle(vehicleViewModel vm)
        {
            tblVehicel tbl = db.tblVehicels.Where(u => u.VehicleId == vm.vehicleid).FirstOrDefault();
            tbl.VehicleId = vm.vehicleid;
            tbl.vehiclePrice = vm.vehiclePrice;
            tbl.vehiclePhoto = vm.photo;
            if (vm.vehicleNumber>0)
            {
               
                int vehiclenumb=tbl.VehicleNumber.Value - vm.vehicleNumber.Value;
                tbl.VehicleNumber = vehiclenumb;
                
            }
            else
            {
                tbl.VehicleNumber = tbl.VehicleNumber;
            }
            
            db.SaveChanges();
          
            return RedirectToAction("getvehicle","hirevehicle");
        }
        [HttpGet]
        public  ActionResult hiredriver()
        {
           
          
            return View();
        }
        //[HttpPost]
        //public ActionResult hiredriver(hiredriverviewmodel vm)
        //{
        //    tbldriver tb = new tbldriver();
        //    var userid = @Session["username"].ToString();
        //    tblCustomer tbl = db.tblCustomers.Where(u => u.FirstName == userid).FirstOrDefault();
            
        //    var customerid = tbl.Userid;
        //    if (customerid==0)
        //    {
        //        tb.drivertype = "special";
        //        tb.hiredate = vm.hiredate;
        //        tb.cutomerid = customerid;
        //        tb.salary = vm.salary;
        //        db.tbldrivers.Add(tb);
        //        db.SaveChanges();
        //    }
        //    else
        //    {
        //        ViewBag.message = "driver is booked";
        //    }
            
           
           


        //    return View();
        //}


 


       

    }
}