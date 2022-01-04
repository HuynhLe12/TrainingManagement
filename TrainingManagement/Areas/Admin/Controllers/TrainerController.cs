using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingManagement.Models;
using System.Data.Entity;

namespace TrainingManagement.Areas.Admin.Controllers
{
    public class TrainerController : Controller
    {
        TrainingManagementEntities2 TrainingManagementEntities = new TrainingManagementEntities2();
        User user = new User();
        // GET: Admin/Trainer
        public ActionResult Index()
        {
            if (user.ISLOGIN == false || user.ROLE != 2)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                return View(TrainingManagementEntities.Trainers.ToList());
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
        public ActionResult Create(Trainer objtrainer)
        {
            try
            {
                objtrainer.RoleId = 3;
                TrainingManagementEntities.Trainers.Add(objtrainer);
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
                return View(TrainingManagementEntities.Trainers.Where(n => n.TrainerId == id).FirstOrDefault());
            }
            
        }

        [HttpPost]
        public ActionResult Delete(int id, Trainer objtrainer)
        {
            try
            {
                objtrainer = TrainingManagementEntities.Trainers.Where(n => n.TrainerId == id).FirstOrDefault();
                TrainingManagementEntities.Trainers.Remove(objtrainer);
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
                return View(TrainingManagementEntities.Trainers.Where(n => n.TrainerId == id).FirstOrDefault());
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
                return View(TrainingManagementEntities.Trainers.Where(n => n.TrainerId == id).FirstOrDefault());
            }
            
        }

        [HttpPost]
        public ActionResult Edit(int id, Trainer objtrainer)
        {
            try
            {
                objtrainer.RoleId = 3;
                TrainingManagementEntities.Entry(objtrainer).State = EntityState.Modified;
                TrainingManagementEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult ChooseRole()
        {
            Role role = new Role();
            role.RoleCollection = TrainingManagementEntities.Roles.ToList<Role>();
            return PartialView(role);
        }
    }

   
}