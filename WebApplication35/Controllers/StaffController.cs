using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication35.Models;
using WebApplication35.Models.viewModel;

namespace WebApplication35.Controllers
{
    public class StaffController : Controller
    {
        AllgemeindbEntities db = new AllgemeindbEntities();
        // GET: Staff
        [Authorize(Roles ="Admin")]
        public ActionResult Indexstaff()
        {

            var st = db.tblstaffs.ToList();
            List<staffViewModell> lst = new List<staffViewModell>();


            foreach (var item in st)
            {
                lst.Add(new staffViewModell() { staffid = item.staff_id, Name = item.Name, date = item.hiredate.Value, salary = item.salary, post = item.post });

            }

            return View(lst);
        }
        [HttpGet]
        public ActionResult addstaff()
        {
           
            return View();
        }
     
        [HttpPost]
        public ActionResult addstaff(staffViewModell vm)
        {

            tblstaff tb = new tblstaff();
            tb.Name = vm.Name;
            tb.salary = vm.salary;
            tb.post = vm.post;
            tb.hiredate = vm.date;
            tbluserRole tr = new tbluserRole();
            tr.Roleid = 1;
            tbluser tbl = new tbluser();
            tbl.username = vm.Name;
            tbl.Password = "password";
            tr.Userid = tbl.Userid;
            db.tblusers.Add(tbl);
            

            db.tbluserRoles.Add(tr);
            db.tblstaffs.Add(tb);
         
            db.SaveChanges();

            return RedirectToAction("indexstaff", "staff");

        }

        [HttpGet]
       public ActionResult delete(int id)
        {
            tblstaff tb = db.tblstaffs.Where(u => u.staff_id == id).FirstOrDefault();
            staffViewModell st = new staffViewModell();
            st.staffid = tb.staff_id;
            st.Name = tb.Name;
            st.post = tb.post;
            st.date = tb.hiredate.Value;
            st.salary = tb.salary;

            return View(st);
           
        }
        [HttpPost,ActionName("delete")]
        public ActionResult deletePost(int id)
        {
            tblstaff tb = db.tblstaffs.Where(u => u.staff_id == id).FirstOrDefault();
            db.tblstaffs.Remove(tb);
            db.SaveChanges();

            return RedirectToAction("indexstaff","staff");

        }

        [HttpGet]
        public ActionResult edit(int id)
        {

           
            tblstaff tb = db.tblstaffs.Where(u => u.staff_id == id).FirstOrDefault();
            staffViewModell sm = new staffViewModell();
            sm.staffid = tb.staff_id;
            sm.Name = tb.Name;
            sm.post = tb.post;
            sm.salary = tb.salary;
            sm.date = tb.hiredate.Value;
            ViewBag.message = "edit sucess";
            return View(sm);

        }
        [HttpPost]
        public ActionResult edit(staffViewModell vm)
        {
            tblstaff tb = db.tblstaffs.Where(u => u.staff_id == vm.staffid).FirstOrDefault();
            tb.staff_id = vm.staffid;
            tb.Name = vm.Name;
            tb.post = vm.post;
            tb.salary = vm.salary;
            tb.hiredate = vm.date;
            
            db.SaveChanges();
            return RedirectToAction("indexstaff", "staff");

        }






    }
}