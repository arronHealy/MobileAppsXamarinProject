using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAppsDev2_XamarinProject
{
    public class Contact
    {
        //SQLite variable for primary key and set auto increment
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        //contact name
        public string name { get; set; }

        //contact phone number
        public string phoneNumber { get; set; }

        //contact email
        public string email { get; set; }

        //contact address
        public string address { get; set; }

        
        public Contact()
        {

        }
    }
}
