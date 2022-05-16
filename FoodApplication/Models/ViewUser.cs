using FoodApplication.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodApplication.Models
{
    public class ViewUser
    {
        public string U_Name { get; set; }
        public int U_ID { get; set; }
        public string U_email { get; set; }
        public string U_password { get; set; }
        public string U_Manger { get; set; }
        public virtual ICollection<Hisory> Hisories { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]

        public HttpPostedFileBase U_image { get; set; }

    }
}