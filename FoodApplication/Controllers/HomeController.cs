
using FoodApplication.Database;
using FoodApplication.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodApplication.Controllers
{
    public class HomeController : Controller
    {


        private readonly FoodDataBaseEntities foodDB;
        dynamic mymodel = new ExpandoObject();

        public HomeController()
        {

            foodDB = new FoodDataBaseEntities();

        }

        public ActionResult Index()
        {

            if (!DataUser.user.IsLogin)
            {

            }

            //DataUser.user = user;




            List<Product> homeFood = foodDB.Products.ToList();
            /*var Sproduct = database.Products.Where(name => name.P_ID == "0xC1" && name.P_price==12);*/
            /*var Sproduct2 = database.Products.Find("0xc1");*/
            mymodel.Product = homeFood;
            //mymodel.UserData = user;

            //Session["User"] = user;
            //ViewBag.Userdata = user;
            ViewBag.HomeFood = homeFood;
            ViewBag.Userdata = DataUser.user;
            /*var allfoodModel = mapper.Map<List <Food>>(allFood);*/

            return View(ViewBag);
        }


    }
}