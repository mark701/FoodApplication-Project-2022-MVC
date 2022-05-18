using FoodApplication.Database;
using FoodApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace FoodApplication.Controllers
{
    public class AlterFoodController : Controller
    {
        private readonly FoodDataBaseEntities FoodDB;
        Product alterProduct;
        public AlterFoodController()
        {


            //mapper = AutoMapConfig.Mapper;
            FoodDB = new FoodDataBaseEntities(); // make  object from database

        }
        // GET: AlterFood
        [HttpGet]

        public ActionResult DeleteFood(string id) //get data of food to delete it
        {
            if (id != null && DataUser.user.U_Manger == "admin")
            {
                alterProduct = FoodDB.Products.Find(int.Parse(id)); //search in databae  to get the food
                FoodDB.Products.Remove(alterProduct); //delete food data form database
                AlterFoodImage(alterProduct.P_image, null); // delete image of food from its folder
                FoodDB.SaveChanges();
            }
            return RedirectToAction("../Home/Index");
        }
        public void AlterFoodImage([Optional] string OldDataImage, [Optional] HttpPostedFileBase newDataimage) //update image if  he add new image  and delete old image
        {
            if (newDataimage != null)
            {
                if (OldDataImage != null)
                {
                    var filePath = Server.MapPath("~/Assets/Images/Food/" + OldDataImage);
                    FileInfo file = new FileInfo(filePath);
                    file.Delete();

                }
                string path = Path.Combine(Server.MapPath("~/Assets/Images/Food"), Path.GetFileName(newDataimage.FileName));
                newDataimage.SaveAs(path);

            }

            if (OldDataImage != null)
            {
                var filePath = Server.MapPath("~/Assets/Images/Food/" + OldDataImage);
                FileInfo file = new FileInfo(filePath);
                file.Delete();

            }



        }
        public ActionResult AddFood()
        {
            ViewBag.Userdata = DataUser.user;
            if (DataUser.user.U_Manger == "admin" && DataUser.user.IsLogin) //check if  login and  he is admin user
            {
                return View();
            }
            else return RedirectToAction("../Home/Index");

        }

        [HttpPost]
        public ActionResult AddFood(Food food) //add food data that he insert in view
        {
            Product addFood = new Product()
            {
                P_price = food.P_price,
                P_Name = food.P_Name,
                P_image = food.P_image.FileName,
            };
            AlterFoodImage(null, food.P_image); //add image of  food in its folder
            FoodDB.Products.Add(addFood);
            FoodDB.SaveChanges();
            ViewBag.Userdata = DataUser.user; //make sseion  to user
            return View();
        }
        [HttpGet]
        public ActionResult EditFood(string id) 
        {
            ViewBag.Userdata = DataUser.user;
            Product editFood = new Product();

            if (DataUser.user.IsLogin && DataUser.user.U_Manger == "admin")
            {
                if (id != null)
                {

                    editFood = FoodDB.Products.Find(int.Parse(id)); 
                    ViewBag.EditFood = editFood;





                }
                return View(editFood);
            }
            else return RedirectToAction("../Coustmer/SignIN");



        }
        [HttpPost]
        public ActionResult EditFood(Food editFood)
        {

            Product alterFood = new Product();
            alterFood = FoodDB.Products.Find(int.Parse(editFood.P_ID));  //get food data to edit it

            //check view data if he  take  any input  by  null
            alterFood.P_Name = editFood.P_Name != null ? editFood.P_Name : alterFood.P_Name;
            alterFood.P_price = editFood.P_price != null ? editFood.P_price : alterFood.P_price;
            alterFood.P_image = editFood.P_image != null ? EditFoodImage(alterFood.P_image, editFood.P_image) : alterFood.P_image;
            //check view data if he  take  any input  by  null

            FoodDB.Entry(alterFood).State = EntityState.Modified; //update data of  food
            FoodDB.SaveChanges();
            ViewBag.Userdata = DataUser.user;


            return RedirectToAction("../Home/Index");
        }
        public string EditFoodImage([Optional] string OldDataImage, [Optional] HttpPostedFileBase newDataimage) //update image if  he add new image  and delete old image
        {
            if (newDataimage != null)
            {
                if (OldDataImage != null)
                {
                    var filePath = Server.MapPath("~/Assets/Images/Food/" + OldDataImage);
                    FileInfo file = new FileInfo(filePath);
                    file.Delete();

                }
                string path = Path.Combine(Server.MapPath("~/Assets/Images/Food"), Path.GetFileName(newDataimage.FileName));
                newDataimage.SaveAs(path);
                return newDataimage.FileName;
            }
            return OldDataImage;
        }
    }
}