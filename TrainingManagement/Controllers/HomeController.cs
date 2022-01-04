using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingManagement.Models;

namespace TrainingManagement.Controllers
{
    public class HomeController : Controller
    {
        TrainingManagementEntities2 TrainingManagementEntities = new TrainingManagementEntities2();
        User user = new User();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Get List Category
        public ActionResult ListCate()
        {
            Category cate = new Category();
            cate.CateCollection = TrainingManagementEntities.Categories.ToList<Category>();
            return PartialView(cate);
        }

        //Get List Course by Trainee
        public ActionResult ListCourseTrainee()
        {
            Trainee_Course trainee = new Trainee_Course();
            if (user.ISLOGIN == true)
            {  
                int traineeId = (int)(Session["idUser"]);
                trainee.TraineeCollection = TrainingManagementEntities.Trainee_Course.Where(n => n.TraineeId == traineeId).ToList<Trainee_Course>();
                return PartialView(trainee);
            }
            else
            {
                return PartialView(trainee);
            }
            
        }


        public ActionResult ListCourseTrainer()
        {
            Course trainer = new Course();
            if (user.ISLOGIN == true)
            {
                int trainerId = (int)(Session["idUser"]);
                trainer.TrainerCollection = TrainingManagementEntities.Courses.Where(n => n.TrainerId == trainerId).ToList<Course>();
                return PartialView(trainer);
            }
            else
            {
                return PartialView(trainer);
            }

        }
    }
}