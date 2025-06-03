using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_6
{
    internal class Program
    {
        const float navigation_tax = 12;
        const float social_tax = 13;
        static void Main(string[] args)
        {
            MobileDevice device = new MobileDevice("user", "pass");
            while (true)
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();
                try
                {
                    if (device.login(username, password))
                    {
                        device.Is_active = true;
                        Console.WriteLine("Login successful!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect username or password. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Access blocked: {ex.Message}");
                    return;
                }
            }
            while (true)
            {
                Console.WriteLine("\n   ~~~Choose an option~~~");
                Console.WriteLine("1. Download a new app");
                Console.WriteLine("2. View most popular navigation app");
                Console.WriteLine("3. Navigate using an app");
                Console.WriteLine("4. Display device information");
                Console.WriteLine("5. Sort apps");
                Console.WriteLine("6. Turn off device");
                Console.Write("Your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        DownloadNewApp(device);
                        break;
                    case "2":
                        ShowPopularNavigationApp(device);
                        break;
                    case "3":
                        NavigateWithApp(device);
                        break;
                    case "4":
                        Console.WriteLine(device.ToString());
                        break;
                    case "5":
                        Array.Sort(device.Apps);
                        Console.WriteLine("Apps sorted successfully.");
                        break;
                    case "6":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void DownloadNewApp(MobileDevice device)
        {
            Console.Write("Would you like to download a Navigation app (1) or a Social app (2)? ");
            string app_type = Console.ReadLine();
            Console.Write("Enter app name: ");
            string app_name = Console.ReadLine();
            Console.Write("Enter download price: ");
            double price = double.Parse(Console.ReadLine());
            try
            {
                if (app_type == "1")
                {
                    Console.Write("Enter current address: ");
                    string currentAddress = Console.ReadLine();
                    Console.Write("Choose vehicle type (1 - Private car, 2 - Motorcycle, 3 - Taxi): ");
                    int vehicleChoice = int.Parse(Console.ReadLine());
                    Vehicle vehicle = (Vehicle)vehicleChoice;

                    NavigationManager manager = new NavigationManager(currentAddress, vehicle);
                    Navigation navigate_app = new Navigation(app_name, price, manager);
                    navigate_app.AddVAT(navigation_tax);
                    device.AddApp(navigate_app);
                }
                else if (app_type == "2")
                {
                    Console.Write("Enter rating (1-5): ");
                    int rating = int.Parse(Console.ReadLine());
                    Console.Write("Is this app for organizations? (true/false): ");
                    bool isForOrg = bool.Parse(Console.ReadLine());

                    Social socialApp = new Social(app_name, price, rating, isForOrg);
                    socialApp.AddVAT(social_tax);
                    device.AddApp(socialApp);
                }
                else
                {
                    Console.WriteLine("Invalid app type.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while downloading app: {ex.Message}");
            }
        }
        static void ShowPopularNavigationApp(MobileDevice device)
        {
            Navigation popular_app = device.PopularNavigationApp();
            if (popular_app != null)
            {
                Console.WriteLine("Most popular navigation app:");
                Console.WriteLine(popular_app.ToString());
            }
            else
            {
                Console.WriteLine("No navigation apps found on the device.");
            }
        }
        static void NavigateWithApp(MobileDevice device)
        {
            Console.WriteLine("Available navigation apps:");
            device.showListAppNavigation();

            Console.Write("Enter the name of the app you want to navigate with: ");
            string appName = Console.ReadLine();

            foreach (AppSystem app in device.Apps)
            {
                if (app is Navigation navApp && navApp.App_name == appName)
                {
                    Console.WriteLine($"Current location: {navApp.Manager.Current_address}");
                    navApp.Manager.ShowRecentLocations();
                    Console.Write("Enter new destination address: ");
                    string newAddress = Console.ReadLine();
                    navApp.Manager.AddAddress(newAddress);
                    Console.WriteLine("Safe travels!");
                    return;
                }
            }
            Console.WriteLine("App not found.");
        }
    }
}
