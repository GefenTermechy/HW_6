using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_6
{
    enum Vehicle
    {
        private_car=1, motorcycle, taxi
    }
    internal class NavigationManager
    {
        string current_address;
        string[] destination_address;
        int address_num;
        Vehicle _vehicle;
        public NavigationManager(string current_address, Vehicle _vehicle)
        {
            Current_address = current_address;
            Vehicle = _vehicle;
            destination_address = new string[0];
            address_num = 0;
        }

        public string Current_address { get => current_address; set => current_address = value; }
        public string[] Destination_address { get => destination_address; set => destination_address = value; }
        public int Address_num { get => address_num; set => address_num = value; }
        internal Vehicle Vehicle { get => _vehicle; set => _vehicle = value; }
        public override string ToString()
        {
            return $"Current Address: {Current_address}\nDestination Address: {Destination_address[0]}\nVehicle Type: {Vehicle}\nNumber Of Addresses {address_num}";
        }
        public void ShowRecentLocations()
        {
            foreach (string address in destination_address)
            {
                Console.WriteLine($"Last Adrresses: {address}");
            }
        }
        public void AddAddress(string address)
        {
            if (!destination_address.Contains(address))
            {
                Array.Resize(ref destination_address, destination_address.Length +1 );
                destination_address[destination_address.Length - 1] = address ;
            }
        }
    }
}