using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodApplication.Models
{
    public class DataUser
    {
        public static User user;

        public static void Iinit()
        {
            user = new User();


        }
    }
}