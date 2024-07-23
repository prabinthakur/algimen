using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication35.Models;
using WebApplication35.Models.viewModel;

namespace WebApplication35.Controllers
{
	
	public class AccountController : Controller
    {
		// GET: Account

	
		public ActionResult Login()
        {
			return View();
        }
		[HttpPost]
		public ActionResult Login(LoginViewModel l, string ReturnUrl = "")
		{
            AllgemeindbEntities db = new AllgemeindbEntities();
			{
				var user = db.tblusers.Where(a => a.username == l.username && a.Password == l.Password).FirstOrDefault();
				if (user != null)
				{
					Session.Add("username", user.username);
					FormsAuthentication.SetAuthCookie(l.username, false);
					if (Url.IsLocalUrl(ReturnUrl))
					{
						return Redirect(ReturnUrl);

					}
					else
					{
						return RedirectToAction("Index", "Home");

					}


				}
				else
				{
					ModelState.AddModelError("", "Invalid user");
				}
			}


			return View();
		}
		[Authorize]
		public ActionResult logout()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("login", "Account");
		}


	}
}