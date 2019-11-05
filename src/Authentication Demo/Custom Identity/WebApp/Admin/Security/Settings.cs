using System;
using System.Collections.Generic;
using static System.Configuration.ConfigurationManager;
using System.Linq;
using System.Web;
//in the using statement, direct it to the class, allows us to just call the AppSettings
//helps keep things cleaner
namespace WebApp.Admin.Security
{

    public static class Settings
    {
        #region Security Roles
        public static string AdminRole => AppSettings["adminRole"];
        /*The above is the same as typing:
         * public static string AdminRole
         * {
         *      get {return ConfigurationManager.AppSettings["adminRole"];}
         * }
         */
        public static string UserRole => AppSettings["userRole"];

        public static IEnumerable<string> DefaultSecurityRoles => new List<string> { AdminRole, UserRole };
        #endregion

        #region Startup User
        public static string AdminUserName => AppSettings["adminUserName"];
        public static string AdminPassword => AppSettings["adminPassword"];
        public static string AdminEmail => AppSettings["adminEmail"];
        public static string TempPassword => AppSettings["temporaryuserPassword"];
        #endregion
    }
}