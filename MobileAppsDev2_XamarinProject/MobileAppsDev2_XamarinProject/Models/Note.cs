using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobileAppsDev2_XamarinProject.Models
{
    class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string title { get; set; }

        public string note { get; set; }

        public Note()
        {

        }//Note
    }
}
