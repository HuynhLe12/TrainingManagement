using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingManagement.Models;

namespace TrainingManagement.Areas.Admin.Controllers
{
    public class CourseController : Controller
    {
        TrainingManagementEntities2 TrainingManagementEntities = new TrainingManagementEntities2();
        // GET: Admin/Course
        public ActionResult Index()
        {
            return View(TrainingManagementEntities.Courses.ToList());
        }

        //CREATE
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course objcourse)
        {
            try
            {
                objcourse.CreateDate = DateTime.Now;
                TrainingManagementEntities.Courses.Add(objcourse);
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
            return View(TrainingManagementEntities.Courses.Where(n => n.CourseId == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Delete(int id, Course objcourse)
        {
            try
            {
                objcourse = TrainingManagementEntities.Courses.Where(n => n.CourseId == id).FirstOrDefault();
                TrainingManagementEntities.Courses.Remove(objcourse);
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
            return View(TrainingManagementEntities.Courses.Where(n => n.CourseId == id).FirstOrDefault());
        }

        //EDIT
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(TrainingManagementEntities.Courses.Where(n => n.CourseId == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(int id, Course objcourse)
        {
            try
            {
                objcourse.UpdateDate = DateTime.Now;
                TrainingManagementEntities.Entry(objcourse).State = EntityState.Modified;
                TrainingManagementEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }


        //CHOOSE CATEGORIES
        public ActionResult ChooseCate()
        {
            Category cate = new Category();
            cate.CateCollection = TrainingManagementEntities.Categories.ToList<Category>();
            return PartialView(cate);
        }

        public ActionResult ViewStudent(int id)
        {
            return View(TrainingManagementEntities.Trainee_Course.Where(n => n.CourseId == id).ToList());
        }

        //ADD STUDENT
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(int id, Trainee_Course objcourse)
        {
            try
            {
                objcourse.CreateDate = DateTime.Now;
                TrainingManagementEntities.Trainee_Course.Add(objcourse);
                TrainingManagementEntities.SaveChanges();
                return RedirectToAction("ViewStudent", new { id });
            }
            catch
            {
                return RedirectToAction("ViewStudent", new { id });
            }

        }

        //Delete student
        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            return View(TrainingManagementEntities.Trainee_Course.Where(n => n.TraineeId == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult DeleteStudent(int id, Trainee_Course objcourse)
        {
            try
            {
                objcourse = TrainingManagementEntities.Trainee_Course.Where(n => n.TraineeId == id).FirstOrDefault();
                TrainingManagementEntities.Trainee_Course.Remove(objcourse);
                TrainingManagementEntities.SaveChanges();
                return RedirectToAction("ViewStudent", new {id});
            }
            catch
            {
                return RedirectToAction("ViewStudent");
            }
        }
    }
}