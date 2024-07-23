using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication35.Models;
using WebApplication35.Models.viewModel;

namespace WebApplication35.Controllers
{
    public class bookcabController : Controller
    {

        AllgemeindbEntities db = new AllgemeindbEntities();
        // GET: bookcab
        public ActionResult Index()
        {
            var book = db.tblbooks.ToList();
            List<bookcabViewModel> vm = new List<bookcabViewModel>();
            foreach (var item in book)
            {
                vm.Add(item: new bookcabViewModel() { username = item.username, bookid = item.bookid, pickup = item.pickup, drop = item.drop, bookdate = item.bookdate.Value,confirmation=item.confiramtion });
            }

            return View(vm);
        }
        [HttpGet]
      
        public ActionResult Bookcab()
        {
            var olduser = @Session["username"].ToString();
            tblbook um = db.tblbooks.Where(u => u.username == olduser).FirstOrDefault();
            if (um.confiramtion == "accepted")
            {
                return RedirectToAction("msg", "bookcab");
            }
            else
            {
                return View();
            }


        }
        [Authorize(Roles ="Customer")]
        public ActionResult Bookcab(bookcabViewModel vm)
        {
            var olduser = @Session["username"].ToString();
            tblbook um = db.tblbooks.Where(u => u.username == olduser).FirstOrDefault();
            if (um.confiramtion=="accepted")
            {
                return RedirectToAction("msg", "bookcab");
            }
            else
            {
                tblbook tb = new tblbook();
                tb.username = vm.username;
                tb.bookdate = vm.bookdate;
                tb.confiramtion = "";
                tb.pickup = vm.pickup;
                tb.drop = vm.drop;
                db.tblbooks.Add(tb);
                db.SaveChanges();
                ViewBag.message = "waiting for confirmaition";
            }
            return View();
           
          
            
        }
        [HttpGet]
        public ActionResult msg()
        {
            var user = @Session["username"].ToString();
            tblbook tb = db.tblbooks.Where(u => u.username ==user).FirstOrDefault();
            bookcabViewModel vm = new bookcabViewModel();
            if (tb.confiramtion=="accepted")
            {
            
                vm.confirmation = tb.confiramtion;
                vm.bookdate = tb.bookdate.Value;
                vm.drop = tb.drop;
                vm.pickup = tb.pickup;
                vm.username = tb.username;

            }
           
            
           
            return View(vm);
        }














        [HttpGet]
        [Authorize(Roles = "Driver")]
        public ActionResult Driver_confirmation(int id)
        {
            
            tblbook tb = db.tblbooks.Where(u => u.bookid == id).FirstOrDefault();
            bookcabViewModel vm = new bookcabViewModel();
            vm.bookid = tb.bookid;
            vm.confirmation ="0";
            vm.bookdate = tb.bookdate.Value;
            vm.drop = tb.drop;
            vm.pickup = tb.pickup;
            
            ViewBag.option = db.tblconfirmations.ToList();
            //List<tblconfirmation> lst = db.tblconfirmations.ToList();
            //List<SelectListItem> sem = new List<SelectListItem>();
            //foreach (var item in lst)
            //{
            //    sem.Add(new SelectListItem() { Text = item.confirmation, Value = item.confirmationid.ToString() });
            //}
            //SelectListItem itm = new SelectListItem();
            //itm.Text = "choose confirmattion";
            //itm.Value = "";
            //sem.Insert(0, itm);



            return View(vm);
        }


        public ActionResult Driver_confirmation(bookcabViewModel vm)
        {

            tblbook tb = db.tblbooks.Where(u => u.bookid == vm.bookid).FirstOrDefault();
            tb.bookid = vm.bookid;
            tb.bookdate = vm.bookdate;
           string conformation= vm.confirmationid.ToString();
            if (vm.confirmationid==1)
            {
                tb.confiramtion = "accepted";

            }
            else
            {
                tb.confiramtion = "rejected";
            }
            tb.drop = vm.drop;
            tb.pickup = vm.pickup;
            tb.username = vm.username;


            ViewBag.option = db.tblconfirmations.ToList();

            db.SaveChanges();



            return View();
        }





    }
}