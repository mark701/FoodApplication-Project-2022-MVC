using FoodApplication.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodApplication.Models
{
    public class Food
    {

        public string P_ID { get; set; }
        public string P_Name { get; set; }
        public HttpPostedFileBase P_image { get; set; }
        public int P_price { get; set; }

        public virtual ICollection<Hisory> Hisories { get; set; }
    }
}