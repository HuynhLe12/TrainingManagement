using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingManagement.Models
{
    public class User
    {
        public bool ISLOGIN { get; set; } /*= false;*/
        public int ID { get; set; }
        public int ROLE { get; set; }
        public string USERNAME { get; set; }
        public string EMAIL { get; set; }
        public string NAME { get; set; }

        public User()
        {
            try
            {
                if((HttpContext.Current.Session[UserSession.ISLOGIN]) != null)
                {
                    ISLOGIN = (bool)HttpContext.Current.Session[UserSession.ISLOGIN];
                    ID = (int)HttpContext.Current.Session[UserSession.ID];
                    ROLE = (int)HttpContext.Current.Session[UserSession.ROLE];
                    USERNAME = (string)HttpContext.Current.Session[UserSession.USERNAME];
                    EMAIL = (string)HttpContext.Current.Session[UserSession.EMAIL];
                    NAME = (string)HttpContext.Current.Session[UserSession.NAME];
                }
                else
                {
                    ISLOGIN = false;
                    ID = 0;
                    ROLE = 0;
                    USERNAME = null;
                    EMAIL = null;
                    NAME = null;
                }
                
            }
            catch (Exception) { }

        }
        public bool IsLogin()
        {
            try
            {
                if (ISLOGIN)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void Reset()
        {
            HttpContext.Current.Session.Clear();
        }
        public bool IsAdmin()
        {
            try
            {
                if (ISLOGIN && ROLE == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }public bool IsStaff()
        {
            try
            {
                if (ISLOGIN && ROLE == 2)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool IsTrainee()
        {
            try
            {
                if (ISLOGIN && ROLE == 4)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool IsTrainer()
        {
            try
            {
                if (ISLOGIN && ROLE == 3)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}