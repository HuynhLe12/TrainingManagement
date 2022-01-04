using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingManagement.Models;

namespace TrainingManagement.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        TrainingManagementEntities2 TrainingManagementEntities = new TrainingManagementEntities2();
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(TrainingManagementEntities.Categories.ToList());
        }

        //CREATE
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category objcategory)
        {
            try
            {
                objcategory.CreateDate = DateTime.Now;
                objcategory.UpdateDate = DateTime.Now;
                TrainingManagementEntities.Categories.Add(objcategory);
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
            return View(TrainingManagementEntities.Categories.Where(n => n.CateId == id).FirstOrDefault()) ;
        }

        [HttpPost]
        public ActionResult Delete(int id, Category objcategory)
        {
            try
            {
                objcategory = TrainingManagementEntities.Categories.Where(n => n.CateId == id).FirstOrDefault();
                TrainingManagementEntities.Categories.Remove(objcategory);
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
            return View(TrainingManagementEntities.Categories.Where(n=>n.CateId == id).FirstOrDefault());
        }

        //EDIT
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(TrainingManagementEntities.Categories.Where(n => n.CateId == id).FirstOrDefault()) ;
        }

        [HttpPost]
        public ActionResult Edit(int id, Category objcategory)
        {
            try
            {
                objcategory.UpdateDate = DateTime.Now;
                TrainingManagementEntities.Entry(objcategory).State = EntityState.Modified;
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