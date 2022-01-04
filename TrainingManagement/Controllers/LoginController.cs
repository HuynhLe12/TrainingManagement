using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingManagement.Models;

namespace TrainingManagement.Controllers
{
    public class LoginController : Controller
    {
        TrainingManagementEntities2 TrainingManagementEntities = new TrainingManagementEntities2();
        // GET: Login
        User user;
        public ActionResult Index()
        {
            if (Session[UserSession.ISLOGIN] != null && (bool)Session[UserSession.ISLOGIN])
            {
                if ((int)Session[UserSession.ROLE] == 1)
                    return RedirectToAction("Index", "Home", new { area = "Admin"});
                if ((int)Session[UserSession.ROLE] == 2)
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                if ((int)Session[UserSession.ROLE] == 3)
                    return RedirectToAction("Index", "Home");
                if ((int)Session[UserSession.ROLE] == 4)
                    return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsValid(model))
                {
                    user = new User();
                    //add session
                    Session["FullName"] = user.NAME;
                    Session["Email"] = user.EMAIL;
                    Session["idUser"] = user.ID;
                    Session["Role"] = user.ROLE;
                    
                    if (user.IsAdmin())
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    if (user.IsStaff())
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    if (user.IsTrainee())
                        return RedirectToAction("Index", "Home");
                    if (user.IsTrainer())
                        return RedirectToAction("Index", "Home");
                }
                else
                    ViewBag.error = "Username or password incorrect";
            }
            else
                ViewBag.error = "Error, Please! try again";
            return View();
        }

        
        public ActionResult Logout()
        {
            user = new User();
            if (user.IsAdmin())
            {
                user.Reset();
                Session.Clear();
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else if (user.IsTrainee())
            {
                user.Reset();
                Session.Clear();
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else if (user.IsStaff())
            {
                user.Reset();
                Session.Clear();
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else if (user.IsTrainer())
            {
                user.Reset();
                Session.Clear();
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return View("Error");
            }

            /*user.Reset();
            Session.Clear();
            return RedirectToAction("Index", "Home");*/
        }
    }
}