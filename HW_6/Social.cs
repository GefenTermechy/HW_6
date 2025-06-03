using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_6
{
    internal class Social : AppSystem, IAppable
    {
        int rating;
        bool is_for_organization;
        public Social(string app_name, double download_price, int rating, bool is_for_organization) : base(app_name, download_price)
        {
            Rating = rating;
            Is_for_organization = is_for_organization;
        }

        public int Rating 
        {
            get => rating;
            set
            {
                if(value < 1 || value > 5)
                {
                    throw new ArgumentException("The rating must be between 1-5");
                }
                rating = value;
            }
        }
        public bool Is_for_organization { get => is_for_organization; set => is_for_organization = value; }
        public void AddVAT(float vat)
        {
            Download_price += Download_price * (vat / 100);
        }
        public override string AppSystemPurpose()
        {
            return "Far away and talking close";
        }
    }
}
