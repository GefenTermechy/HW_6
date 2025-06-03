using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HW_6
{
    internal class MobileDevice
    {
        static int total_apps;
        string user_name, password;
        bool is_active;
        int login_try, apps_number;
        AppSystem[] apps;
        public MobileDevice(string user_name, string password)
        {
            User_name = user_name;
            Password = password;
            apps = new AppSystem[0];
            apps_number = ++total_apps;
        }
        public string User_name
        {
            get => user_name;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("User name cannot be Null.");
                }
                foreach (char tav in value)
                {
                    if (!(char.IsLetter(tav)))
                    {
                        throw new ArgumentException("User name must contain letters only.");
                    }
                }
                user_name = value;
            }
        }
        public string Password { get => password; set => password = value; }
        public bool Is_active { get => is_active; set => is_active = value; }
        public int Apps_number { get => apps_number; set => apps_number = value; }
        internal AppSystem[] Apps { get => apps; set => apps = value; }
        public int Login_try { get => login_try; set => login_try = value; }

        public void AddApp(AppSystem newapp)
        {
            foreach (AppSystem app in apps)
            {
                if (app.App_name == newapp.App_name)
                {
                    throw new ArgumentException("This app already exist.");
                }
            }
            Array.Resize(ref apps, apps.Length + 1);
            apps[apps.Length - 1] = newapp;
        }
        public void showListAppNavigation()
        {
            foreach (AppSystem app in apps)
            {
                if (app is Navigation navigation_app)
                    Console.WriteLine($"App Name: {navigation_app.App_name}\nApp Serial Number: {navigation_app.Serial_num}");
            }
        }
        public override string ToString()
        {
            string name_apps = null;
            foreach(AppSystem app in apps)
            {
                name_apps += app;
            }
            return $"User Name: {user_name}\nPassword: {password}\nActive: {is_active}\nTotal Apps: {apps_number}\nLogin Attempts: {Login_try}\nApps Name: {name_apps}";
        }
        public Navigation PopularNavigationApp()
        {
            Navigation popular_app = null;
            foreach (AppSystem app in apps) 
            { 
                if(app is Navigation navigation_app)
                {
                    if(popular_app == null || navigation_app.Manager.Destination_address.Length > popular_app.Manager.Destination_address.Length)
                    {
                        popular_app = (Navigation)navigation_app;
                    }
                }
            }
            return popular_app ;
        }
        public bool login(string user_name, string password)
        {
            login_try++;
            if(user_name == User_name && password == Password)
                return true;
            if (login_try > 8)
            {
                throw new Exception("You reached the max attempts to login. Your device is BLOCKED.");
            }
            if (login_try > 2)
            {
                Thread.Sleep(15000);
            }
            return false;
        }
    }
}
