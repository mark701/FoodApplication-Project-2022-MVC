using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodApplication.Models
{
    public class InsertionOrder
    {
        public string date { get; set; }
        public int price { get; set; }
        public string P_name { get; set; }
        public string p_image { get; set; }
        public string U_ID { get; set; }
        public int P_ID { get; set; }
    }
}