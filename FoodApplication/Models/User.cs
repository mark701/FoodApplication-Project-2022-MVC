using FoodApplication.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodApplication.Models
{
    public class User
    {



        public string U_Name { get; set; }
        public int U_ID { get; set; }
        public string U_email { get; set; }
        public string U_image { get; set; }
        public string U_password { get; set; }
        public string U_Manger { get; set; }
        public bool IsLogin { get; set; } = false;










        public virtual ICollection<Hisory> Hisories { get; set; }
    }
}