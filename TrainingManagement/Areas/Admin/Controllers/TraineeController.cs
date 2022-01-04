using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingManagement.Models;

namespace TrainingManagement.Areas.Admin.Controllers
{
    public class TraineeController : Controller
    {
        TrainingManagementEntities2 TrainingManagementEntities = new TrainingManagementEntities2();
        User user = new User();
        // GET: Admin/Trainee
        public ActionResult Index()
        {
            if (user.ISLOGIN == false || user.ROLE != 2)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                return View(TrainingManagementEntities.Trainees.ToList());
            }
            
        }

        //CREATE
        [HttpGet]
        public ActionResult Create()
        {
            if (user.ISLOGIN == false || user.ROLE != 2)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(Trainee objtrainee)
        {
            try
            {
                objtrainee.RoleId = 4;
                TrainingManagementEntities.Trainees.Add(objtrainee);
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
            if (user.ISLOGIN == false || user.ROLE != 2)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                return View(TrainingManagementEntities.Trainees.Where(n => n.TraineeId == id).FirstOrDefault());
            }
            
        }

        [HttpPost]
        public ActionResult Delete(int id, Trainee objtrainee)
        {
            try
            {
                objtrainee = TrainingManagementEntities.Trainees.Where(n => n.TraineeId == id).FirstOrDefault();
                TrainingManagementEntities.Trainees.Remove(objtrainee);
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
            if (user.ISLOGIN == false || user.ROLE != 2)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                return View(TrainingManagementEntities.Trainees.Where(n => n.TraineeId == id).FirstOrDefault());
            }
            
        }

        //EDIT
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (user.ISLOGIN == false || user.ROLE != 2)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                return View(TrainingManagementEntities.Trainees.Where(n => n.TraineeId == id).FirstOrDefault());
            }
            
        }

        [HttpPost]
        public ActionResult Edit(int id, Trainee objtrainee)
        {
            try
            {
                objtrainee.RoleId = 4;
                TrainingManagementEntities.Entry(objtrainee).State = EntityState.Modified;
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