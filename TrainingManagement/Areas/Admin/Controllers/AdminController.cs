using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingManagement.Models;

namespace TrainingManagement.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        TrainingManagementEntities2 TrainingManagementEntities = new TrainingManagementEntities2();
        User user = new User();
        // GET: Admin/Admin
   
        public ActionResult Index()
        {
            if(user.ISLOGIN == false || user.ROLE != 1)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                return View(TrainingManagementEntities.Administrators.ToList());
            }
            
        }

        //CREATE
        [HttpGet]
        public ActionResult Create()
        {
            if (user.ISLOGIN == false || user.ROLE != 1)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult Create(Administrator objadmin)
        {
            
            try
            {
                objadmin.RoleId = 1;
                TrainingManagementEntities.Administrators.Add(objadmin);
                TrainingManagementEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }

        }

        //DELETE
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (user.ISLOGIN == false || user.ROLE != 1)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                return View(TrainingManagementEntities.Administrators.Where(n => n.AdminId == id).FirstOrDefault());
            }
            
        }

        [HttpPost]
        public ActionResult Delete(int id, Administrator objadmin)
        {
            try
            {
                objadmin = TrainingManagementEntities.Administrators.Where(n => n.AdminId == id).FirstOrDefault();
                TrainingManagementEntities.Administrators.Remove(objadmin);
                TrainingManagementEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        //DETAILS
        public ActionResult Details(int id)
        {
            if (user.ISLOGIN == false || user.ROLE != 1)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                return View(TrainingManagementEntities.Administrators.Where(n => n.AdminId == id).FirstOrDefault());
            }
            
        }

        //EDIT
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (user.ISLOGIN == false || user.ROLE != 1)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                return View(TrainingManagementEntities.Administrators.Where(n => n.AdminId == id).FirstOrDefault());
            }
            
        }

        [HttpPost]
        public ActionResult Edit(int id, Administrator objadmin)
        {
            try
            {
                objadmin.RoleId = 1;
                TrainingManagementEntities.Entry(objadmin).State = EntityState.Modified;
                TrainingManagementEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        
    }
}