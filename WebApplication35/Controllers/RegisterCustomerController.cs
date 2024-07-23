using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication35.Models;
using WebApplication35.Models.viewModel;

namespace WebApplication35.Controllers
{
    public class RegisterCustomerController : Controller
    {
        AllgemeindbEntities db = new AllgemeindbEntities();

        // GET: RegisterCustomer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult addCusomer()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult addCusomer(Reg_CustViewModel vm)
        {
            if (ModelState.IsValid)
            {
                tblCustomer tb = new tblCustomer();
                tb.FirstName = vm.FirstName;
                tb.LastName = vm.LastName;
                tb.Gender = vm.Gender;
                tb.Email = vm.Email;
                tb.phoneno = vm.phoneno;

                tbluser eb = new tbluser();
                eb.Password = vm.password;
                eb.username = vm.password;
                tbluserRole tr = new tbluserRole();
                tr.Roleid = 2;
                tr.Userid = tb.Userid;
               
                db.tbluserRoles.Add(tr);

                
                db.tblusers.Add(eb);
                db.tblCustomers.Add(tb);
                db.SaveChanges();
            }
          


            return View();
        }
    }
}