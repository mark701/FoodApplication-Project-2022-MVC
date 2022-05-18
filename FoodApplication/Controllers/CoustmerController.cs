
using FoodApplication.Database;
using FoodApplication.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodApplication.Controllers
{
    public class CoustmerController : Controller
    {
        // GET: Coustmer
        Coustmer GetUserData;
        //User userData;

        private readonly FoodDataBaseEntities UserDB;
        dynamic mymodel = new ExpandoObject();
        public CoustmerController()
        {

            UserDB = new FoodDataBaseEntities();

        }

        // GET: Coustmer

        public ActionResult SignIN()
        {
            ViewBag.Userdata = DataUser.user;
            if (DataUser.user.IsLogin)
            {
                return Content("already login");
            }



            return View();
        }
        // POST: SignUP/Create
        [HttpPost]
        public ActionResult SignIN(ViewUser model)
        {


            try
            {

                GetUserData = new Coustmer();

                GetUserData = UserDB.Coustmers.Where(e => e.U_email == model.U_email).SingleOrDefault(); //serach by email in data of user

                if (GetUserData != null && GetUserData.U_password == model.U_password)//check if user and password is in data base
                {

                    SetData();//add data to view session
                    ViewBag.Userdata = DataUser.user;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Content("wrong password or email  ");

                }



            }
            catch
            {
                return Content("something wrong happen");
            }
        }
        public void SetData()
        {


            DataUser.user.IsLogin = true;
            DataUser.user.U_email = GetUserData.U_email;
            DataUser.user.U_Name = GetUserData.U_Name;
            DataUser.user.U_ID = GetUserData.U_ID;
            DataUser.user.U_Manger = GetUserData.U_Manger;
            DataUser.user.U_image = GetUserData.U_image;
            DataUser.user.U_password = GetUserData.U_password;




            //ViewData["UserVerify"] = userData;
            //ViewBag.UserVerify = userData;


        }


        // GET: SignUP/Create
        public ActionResult SignUP()
        {
            ViewBag.Userdata = DataUser.user;
            if (DataUser.user.IsLogin)
            {
                return Content("already login");
            }

            return View();
        }

        // POST: SignUP/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUP(ViewUser viewUser)
        {

            try
            {


                if (ModelState.IsValid)
                {
                    if (!UserDB.Coustmers.Any(e => e.U_email == viewUser.U_email))
                    {
                        //userData = new User();
                        //userData.U_image = UploadIMageFile(viewUser.U_image);
                        //userData.U_Name = viewUser.U_Name;
                        //userData.U_email = viewUser.U_email;
                        //userData.U_password = viewUser.U_password;
                        //userData.U_Manger = viewUser.U_Manger;


                        insertCoustmerData(viewUser);

                    }
                    else return Content("email already used");







                }
                // TODO: Add insert logic here
                return RedirectToAction("../Home/Index");
            }
            catch
            {
                return View("something wrong happen");
            }
        }
        public void insertCoustmerData(ViewUser userData)
        {
            GetUserData = new Coustmer()
            {
                U_email = userData.U_email,
                U_Name = userData.U_Name,
                U_password = userData.U_password,
                U_image = UploadIMageFile(userData.U_image),
                U_Manger = userData.U_Manger,
            };




            UserDB.Coustmers.Add(GetUserData);
            UserDB.SaveChanges();



        }
        public string UploadIMageFile(HttpPostedFileBase image)
        {
            //string uniqueFileName = null;
            //if (model.U_image != null)
            //{
            //    string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "assets/images/customer");
            //    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.U_image.FileName;
            //    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            //    using (var fileStream = new FileStream(filePath, FileMode.Create))
            //    {
            //        model.U_image.CopyTo(fileStream);
            //    }
            //}
            //return uniqueFileName;

            if (image != null)
            {
                string path = Path.Combine(Server.MapPath("~/Assets/Images/Customer"), Path.GetFileName(image.FileName));
                image.SaveAs(path);
                return image.FileName;

            }
            return null;


        }
        public ActionResult Logout()
        {
            if (DataUser.user.IsLogin)
            {

                DeleteDataUser();
            }



            return RedirectToAction("../Home/Index");
        }
        public void DeleteDataUser()
        {
            DataUser.user.U_email = null;
            DataUser.user.U_image = null;
            DataUser.user.Hisories = null;
            DataUser.user.U_ID = 0;
            DataUser.user.U_Manger = null;
            DataUser.user.U_Name = null;
            DataUser.user.U_password = null;
            DataUser.user.IsLogin = false;

        }

    }
}