using System;
using System.Collections.Generic;
using System.Data;

using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodApplication.Database;
using FoodApplication.Models;

namespace FoodApplication.Controllers
{
    public class AlterController : Controller
    {
        private readonly FoodDataBaseEntities AlterDB;

        // GET: Alter
        public AlterController()
        {

            AlterDB = new FoodDataBaseEntities(); // make  object from database

        }
        public ActionResult AlterUserData()
        {
            ViewBag.Userdata = DataUser.user; //make seion time  to use it in view of this action
            if (DataUser.user.IsLogin)
            {

                return View();

            }
            else return RedirectToAction("../Coustmer/SignIN");

        }
        [HttpPost]
        public ActionResult AlterUserData(ViewUser EditUser)
        {
            //update data view
            DataUser.user.U_email = EditUser.U_email != null ? EditUser.U_email : DataUser.user.U_email;
            DataUser.user.U_Name = EditUser.U_Name != null ? EditUser.U_Name : DataUser.user.U_Name;
            DataUser.user.U_password = EditUser.U_password != null ? EditUser.U_password : DataUser.user.U_password;
            DataUser.user.U_Manger = EditUser.U_Manger != null ? EditUser.U_Manger : DataUser.user.U_Manger;
            DataUser.user.U_image = EditUser.U_image != null ? checkImageData(EditUser.U_image, DataUser.user.U_image) : DataUser.user.U_image;
            //update data on view


            UpdateUserData(); //insert new data of user database








            ViewBag.Userdata = DataUser.user; //make seion time  to use it in view of this action


            return View();
        }
        public string checkImageData(HttpPostedFileBase NewImage, string oldImage)  //update image if  he add new image  and delete old image
        {

            if (NewImage != null)
            {
                if (oldImage != null)
                {
                    var filePath = Server.MapPath("~/Assets/Images/Customer/" + oldImage);
                    FileInfo file = new FileInfo(filePath);

                    file.Delete();

                }
                string path = Path.Combine(Server.MapPath("~/Assets/Images/Customer"), Path.GetFileName(NewImage.FileName));
                NewImage.SaveAs(path);

            }
            return NewImage.FileName;


        }
        public void UpdateUserData()
        {
            if (ModelState.IsValid)
            {
                Coustmer updatedata = new Coustmer()
                {
                    U_Name = DataUser.user.U_Name,
                    U_email = DataUser.user.U_email,
                    U_image = DataUser.user.U_image,
                    U_Manger = DataUser.user.U_Manger,
                    U_password = DataUser.user.U_password,
                    U_ID=DataUser.user.U_ID
                };

                AlterDB.Entry(updatedata).State = EntityState.Modified;
                AlterDB.SaveChanges();
            }
        }


    }
}