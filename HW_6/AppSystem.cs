using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_6
{
    internal abstract class AppSystem : IComparable<AppSystem>
    {
        private static uint serial;
        uint serial_num;
        string app_name;
        double download_price;
        DateTime download_date;
        public AppSystem(string app_name, double download_price)
        {
            App_name = app_name;
            Download_price = download_price;
            download_date = DateTime.Now;
            serial_num = ++Serial;
        }
        public static uint Serial { get => serial; set => serial = value; }
        public string App_name
        {
            get => app_name;
            set
            {
                if (value == null)
                    throw new ArgumentNullException("App name cannot be empty or null.");
                app_name = value;
            }
        }
        public double Download_price
        {
            get => download_price;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Price cannot be a negative number.");
                download_price = value;
            }
        }

        public uint Serial_num { get => serial_num; }

        public override string ToString()
        {
            return $"\nApp Name: {App_name}\nApp Serial: {Serial}\nApp Price: {Download_price}\nDownload Date: {download_date}";
        }
        public abstract string AppSystemPurpose();
        public int CompareTo(AppSystem other)
        {
            return app_name.CompareTo(other.app_name);
        }
    }
}
