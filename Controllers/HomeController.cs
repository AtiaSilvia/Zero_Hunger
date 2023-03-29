using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string ID, string Password)
        {

            if (ID[0] == 'E')
            {
                string connString = @"Data Source=SILVIA\SQLEXPRESS;Initial Catalog=Zero_hunger;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connString);
                string query = "Select * from Employee";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetString(reader.GetOrdinal("EmployeeId")) == ID)
                    {

                        Session["id"] = ID;
                        return RedirectToAction("Requests", "Employee");
                    }
                }
                conn.Close();

            }

            if (ID[0] == 'A')
            {
                string connString = @"Data Source=SILVIA\SQLEXPRESS;Initial Catalog=Zero_hunger;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connString);
                string query = "Select * from Admin";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetString(reader.GetOrdinal("AdminId")) == ID)
                    {

                        Session["id"] = ID;
                        return RedirectToAction("Employees", "Admin");
                    }
                }
                conn.Close();
            }

            if (ID[0] == 'R')
            {
                string connString = @"Data Source=SILVIA\SQLEXPRESS;Initial Catalog=Zero_hunger;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connString);
                string query = "Select * from Resturant";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetString(reader.GetOrdinal("ResturantId")) == ID)
                    {

                        Session["id"] = ID;
                        return RedirectToAction("Requests", "Resturant");
                    }
                }
                conn.Close();
            }

            return View();

        }
    }
 }
