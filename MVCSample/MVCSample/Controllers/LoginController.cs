using MVCSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSample.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login1(UILogin login)
        {
            string userName = login.UserName;
            string password = login.Password;
            if(userName=="Praveen"&&password=="Test12$")
            {
                return Redirect("/Employee/DatatableDemo");
            }
            else
            {
                return Redirect("/Login?status=InvalidUser");
            }
           
        }
        public ActionResult logOut()
        {
            return Redirect("/Login?status=LogOut");
        }
	}
}