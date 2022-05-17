
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
    public class MenuController : Controller
    {
        // GET: Menu
        private readonly FoodDataBaseEntities foodDB;
        dynamic mymodel = new ExpandoObject();
        public MenuController()
        {
            foodDB = new FoodDataBaseEntities();
        }
        public ActionResult MenuFood()
        {



            List<Product> allFood = foodDB.Products.ToList();
            /*var Sproduct = database.Products.Where(name => name.P_ID == "0xC1" && name.P_price==12);*/
            /*var Sproduct2 = database.Products.Find("0xc1");*/
            //mymodel.Product = allFood;


            /*var allfoodModel = mapper.Map<List <Food>>(allFood);*/

            ViewBag.MenuFood = allFood;
            ViewBag.UserData = DataUser.user;
            return View(ViewBag);
        }
    }
}