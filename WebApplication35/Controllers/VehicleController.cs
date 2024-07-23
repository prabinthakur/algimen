using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication35.Models;
using WebApplication35.Models.viewModel;

namespace WebApplication35.Controllers
{
    public class VehicleController : Controller
    {
        AllgemeindbEntities db = new AllgemeindbEntities();
        // GET: Vehicle
        public ActionResult Index()
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
        public ActionResult addVehicel()
        {

            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult addVehicel(vehicleViewModel vm)
        {
            tblVehicel tb = new tblVehicel();
            tb.Vehicletype = vm.vehicletype;
            tb.VehicleNumber = vm.vehicleNumber;
            tb.vehiclePrice = vm.vehiclePrice;
            HttpPostedFileBase fileBase = Request.Files["photo"];
            if (fileBase != null)
            {
                tb.vehiclePhoto = fileBase.FileName;
                fileBase.SaveAs(Server.MapPath("~/photo/" + fileBase.FileName));

            }
            db.tblVehicels.Add(tb);
            db.SaveChanges();


            return View();
        }

        [HttpGet]
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


            tblVehicel tb = db.tblVehicels.Where(u => u.VehicleId == vm.vehicleid).FirstOrDefault();
            tb.VehicleId = vm.vehicleid;
            tb.vehiclePrice = vm.vehiclePrice;
            tb.vehiclePhoto = vm.photo;
            int oldveh = 0;
            if (vm.vehicleNumber > 0)
            {
                oldveh = tb.VehicleNumber.Value;
                tb.VehicleNumber = oldveh - vm.vehicleNumber;

            }
            else
            {
                tb.VehicleNumber = vm.vehicleNumber;
            }
            tb.Vehicletype = vm.vehicletype;


           
            db.SaveChanges();
            return View();
        }







    }
}