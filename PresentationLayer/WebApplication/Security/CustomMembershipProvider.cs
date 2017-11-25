using Gradebook.PresentationLayer.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gradebook.PresentationLayer.WebApplication.Models.ViewModels;
using System.Web.Security;

namespace Gradebook.PresentationLayer.WebApplication.Security
{
    public static class CustomMembershipProvider
    {
        public static bool ValidateUser(string username, string password)
        {
            //UserModel user = new UserModel();
            //UserModel userObj = _manager.GetByCredentials(username, Helpers.GetMD5Hash(password));
            //if (userObj != null)
            //    return true;

            //return false;
            return true;
        }

        internal static bool IsInRole(string roleName)
        {
            //foreach (var role in GetRolesForUser(username))
            //{
            //    if (role == roleName)
            //    {
            //        return true;
            //    }
            //}

            //return false;

            return true;
        }

        public static UserModel CurrentUser()
        {
            return new UserModel();
        }
    }
}