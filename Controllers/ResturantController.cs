using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class ResturantController : Controller
    {
        // GET: Resturant
        public ActionResult CreateRequest()
        {

            return View();
        }
        public ActionResult Requests()
        {
            string connString = @"Data Source=SILVIA\SQLEXPRESS;Initial Catalog=Zero_hunger;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            string query = "Select * from FoodRequest";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Request> r = new List<Request>();
            while (reader.Read())
            {
                string Assigned = reader.GetString(reader.GetOrdinal("ResturantID"));
                string id = Session["id"].ToString();

                if (Assigned == id)
                {
                    Request r1 = new Request()
                    {
                        FoodName = reader.GetString(reader.GetOrdinal("FoodName")),
                        FoodRequestID = reader.GetString(reader.GetOrdinal("FoodRequestID")),
                        Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                        PostStatus = reader.GetString(reader.GetOrdinal("PostStatus")),
                        Location = reader.GetString(reader.GetOrdinal("Location")),
                        AssingedEmployee = reader.GetString(reader.GetOrdinal("AssingedEmployee")),
                        ResturantID = reader.GetString(reader.GetOrdinal("ResturantID")),

                    };
                    r.Add(r1);
                }
            }
            conn.Close();
            return View(r);
        }
        public ActionResult Profile()
        {
            string connString = @"Data Source=SILVIA\SQLEXPRESS;Initial Catalog=Zero_hunger;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            string query = "Select * from Resturant";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Resturant e1 = new Resturant();
            while (reader.Read())
            {
                string Assigned = reader.GetString(reader.GetOrdinal("ResturantID"));
                string id = Session["id"].ToString();

                if (Assigned == id)
                {
                    e1.Name = reader.GetString(reader.GetOrdinal("Name"));
                    e1.ResturantID = reader.GetString(reader.GetOrdinal("ResturantID"));
                    e1.Address = reader.GetString(reader.GetOrdinal("Address"));
                    e1.Phone = reader.GetString(reader.GetOrdinal("Phone"));

                }
            }
            conn.Close();
            return View(e1);

        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login", "Home");
        }
    }
}