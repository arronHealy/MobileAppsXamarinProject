using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobileAppsDev2_XamarinProject
{
    public class Note
    {
        //set sql primary key and increment value
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        //note title
        public string title { get; set; }

        //note content
        public string note { get; set; }


        public Note()
        {
            
        }
    }
}
