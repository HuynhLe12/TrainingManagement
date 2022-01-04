using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingManagement.Models;

namespace TrainingManagement.Areas.Admin.Controllers
{
    public class StaffTrainerController : Controller
    {
        TrainingManagementEntities2 TrainingManagementEntities = new TrainingManagementEntities2();
        User user = new User();
        // GET: Admin/StaffTrainer
        public ActionResult Index()
        {
            if (user.ISLOGIN == false || user.ROLE != 1)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                return View(TrainingManagementEntities.StaffTrainers.ToList());
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
        public ActionResult Create(StaffTrainer objstaff)
        {
            try
            {
                objstaff.RoleId = 2;
                TrainingManagementEntities.StaffTrainers.Add(objstaff);
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
                return View(TrainingManagementEntities.StaffTrainers.Where(n => n.StaffId == id).FirstOrDefault());
            }
            
        }

        [HttpPost]
        public ActionResult Delete(int id, StaffTrainer objstaff)
        {
            try
            {
                objstaff = TrainingManagementEntities.StaffTrainers.Where(n => n.StaffId == id).FirstOrDefault();
                TrainingManagementEntities.StaffTrainers.Remove(objstaff);
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
                return View(TrainingManagementEntities.StaffTrainers.Where(n => n.StaffId == id).FirstOrDefault());
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
                return View(TrainingManagementEntities.StaffTrainers.Where(n => n.StaffId == id).FirstOrDefault());
            }
            
        }

        [HttpPost]
        public ActionResult Edit(int id, StaffTrainer objstaff)
        {
            try
            {
                objstaff.RoleId = 2;
                TrainingManagementEntities.Entry(objstaff).State = EntityState.Modified;
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