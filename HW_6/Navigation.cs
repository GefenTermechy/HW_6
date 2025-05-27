using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_6
{
    internal class Navigation : AppSystem, IAppable
    {
        NavigationManager manager;
        public Navigation(string app_name, double download_price, NavigationManager manager) : base(app_name, download_price) 
        {
            this.manager = manager;
        }
        public override string AppSystemPurpose()
        {
            return "Catch The Road-Choose The Best Way";
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public void AddVAT(float vat)
        {
            download_price += download_price * (12 / 100);
        }
    }
}
