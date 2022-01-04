using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingManagement.Models
{
    public class LoginModel
    {
        TrainingManagementEntities2 TrainingManagementEntities = new TrainingManagementEntities2();

        [Display(Name = "Username")]
        public string Username { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }

        public bool IsValid(LoginModel model)
        {
            try
            {
                if (Convert.ToBoolean(TrainingManagementEntities.Administrators.First(x => x.Username == model.Username && x.Password == model.Password).AdminId))
                {
                    SetAdminSession(TrainingManagementEntities.Administrators.First(x => x.Username == model.Username && x.Password == model.Password).AdminId);
                    return true;
                }
            }
            catch (Exception) { }
            try
            {
                if (Convert.ToBoolean(TrainingManagementEntities.Trainees.First(x => x.Username == model.Username && x.Password == model.Password).TraineeId))
                {
                    SetTeacherSession(TrainingManagementEntities.Trainees.First(x => x.Username == model.Username && x.Password == model.Password).TraineeId);
                    return true;
                }
            }
            catch (Exception) { }
            try
            {
                if (Convert.ToBoolean(TrainingManagementEntities.StaffTrainers.First(x => x.Username == model.Username && x.Password == model.Password).StaffId))
                {
                    SetStaffSession(TrainingManagementEntities.StaffTrainers.First(x => x.Username == model.Username && x.Password == model.Password).StaffId);
                    return true;
                }
            }
            catch (Exception) { }try
            {
                if (Convert.ToBoolean(TrainingManagementEntities.Trainers.First(x => x.Username == model.Username && x.Password == model.Password).TrainerId))
                {
                    SetTrainerSession(TrainingManagementEntities.Trainers.First(x => x.Username == model.Username && x.Password == model.Password).TrainerId);
                    return true;
                }
            }
            catch (Exception) { }
            return false;
        }
        public void SetAdminSession(int userID)
        {
            Administrator user = TrainingManagementEntities.Administrators.SingleOrDefault(x => x.AdminId == userID);
            HttpContext.Current.Session.Add(Models.UserSession.ISLOGIN, true);
            HttpContext.Current.Session.Add(Models.UserSession.ID, user.AdminId);
            HttpContext.Current.Session.Add(Models.UserSession.ROLE, user.RoleId);
            HttpContext.Current.Session.Add(Models.UserSession.USERNAME, user.Username);
            HttpContext.Current.Session.Add(Models.UserSession.EMAIL, user.Email);
            HttpContext.Current.Session.Add(Models.UserSession.NAME, user.Name);
        }
        public void SetTeacherSession(int userID)
        {
            Trainee user = TrainingManagementEntities.Trainees.SingleOrDefault(x => x.TraineeId == userID);
            HttpContext.Current.Session.Add(Models.UserSession.ISLOGIN, true);
            HttpContext.Current.Session.Add(Models.UserSession.ID, user.TraineeId);
            HttpContext.Current.Session.Add(Models.UserSession.ROLE, user.RoleId);
            HttpContext.Current.Session.Add(Models.UserSession.USERNAME, user.Username);
            HttpContext.Current.Session.Add(Models.UserSession.EMAIL, user.Email);
            HttpContext.Current.Session.Add(Models.UserSession.NAME, user.Name);
        }
        public void SetStaffSession(int userID)
        {
            StaffTrainer user = TrainingManagementEntities.StaffTrainers.SingleOrDefault(x => x.StaffId == userID);
            HttpContext.Current.Session.Add(Models.UserSession.ISLOGIN, true);
            HttpContext.Current.Session.Add(Models.UserSession.ID, user.StaffId);
            HttpContext.Current.Session.Add(Models.UserSession.ROLE, user.RoleId);
            HttpContext.Current.Session.Add(Models.UserSession.USERNAME, user.Username);
            HttpContext.Current.Session.Add(Models.UserSession.EMAIL, user.Email);
            HttpContext.Current.Session.Add(Models.UserSession.NAME, user.Name);
        }public void SetTrainerSession(int userID)
        {
            Trainer user = TrainingManagementEntities.Trainers.SingleOrDefault(x => x.TrainerId == userID);
            HttpContext.Current.Session.Add(Models.UserSession.ISLOGIN, true);
            HttpContext.Current.Session.Add(Models.UserSession.ID, user.TrainerId);
            HttpContext.Current.Session.Add(Models.UserSession.ROLE, user.RoleId);
            HttpContext.Current.Session.Add(Models.UserSession.USERNAME, user.Username);
            HttpContext.Current.Session.Add(Models.UserSession.EMAIL, user.Email);
            HttpContext.Current.Session.Add(Models.UserSession.NAME, user.Name);
        }
    }
}