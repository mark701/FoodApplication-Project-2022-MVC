using FoodApplication.Database;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodApplication.Models;
using System.Data.SqlClient;

namespace FoodApplication.Controllers
{
    public class BuyController : Controller
    {
        // GET: Buy
        private readonly FoodDataBaseEntities BuyFoodDB;
        //private readonly IMapper mapper;
        //dynamic mymodel = new ExpandoObject();

        Product OrderBuy;
        public BuyController()
        {


            //mapper = AutoMapConfig.Mapper;
            BuyFoodDB = new FoodDataBaseEntities();

        }
        [HttpGet]
        public ActionResult BuyFood(string id)
        {
            ViewBag.Userdata = DataUser.user;

            if (DataUser.user.IsLogin)
            {
                if (id != null)
                {

                    OrderBuy = BuyFoodDB.Products.Find(int.Parse(id));

                    ViewBag.order = OrderBuy;
                    ViewBag.productID = int.Parse(id);

                }
                return View();
            }
            else return RedirectToAction("../Coustmer/SignIN");





        }
        [HttpPost]
        public ActionResult SumbitOrder(CreditCard card, string P_ID)//bug in insert  database
        {
            ViewBag.Userdata = DataUser.user;
            if (card != null)
            {
                GetDataOrder(P_ID);

            }


            return RedirectToAction("../Home/Index");





        }
        public void GetDataOrder(string P_ID) //bug in insert  database
        {
            OrderBuy = BuyFoodDB.Products.Find(int.Parse(P_ID));

            string timeDate = DateTime.Now.ToShortTimeString();
            Hisory insertionOrder = new Hisory()
            {
                date = timeDate,
                price = OrderBuy.P_price,
                p_image = OrderBuy.P_image,
                P_name = OrderBuy.P_Name,
                P_ID = OrderBuy.P_ID,
                U_ID = DataUser.user.U_ID,




            };
            BuyFoodDB.Hisories.Add(insertionOrder);
            BuyFoodDB.SaveChanges();

            //InsertDataOrder(insertionOrder);


        }
        //public void InsertDataOrder(Hisory dataOrder)
        //{
        //    SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=FoodDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
        //    SqlCommand cmd = new SqlCommand("sp_Employee_Add", con);


        //}




    }
}
