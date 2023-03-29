using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
       
        public ActionResult Employees()
        {
            string connString = @"Data Source=SILVIA\SQLEXPRESS;Initial Catalog=Zero_hunger;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            string query = "Select * from Employee";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Employee> e = new List<Employee>();
            while (reader.Read())
            {
                Employee e1 = new Employee()
                {
                    name = reader.GetString(reader.GetOrdinal("Name")),
                    employeeID = reader.GetString(reader.GetOrdinal("EmployeeID")),
                    password = reader.GetString(reader.GetOrdinal("Password")),
                    phone = reader.GetString(reader.GetOrdinal("Phone")),

                };
                e.Add(e1);
            }
            conn.Close();
            return View(e);
        }
        public ActionResult Resturants()
        {
            string connString = @"Data Source=SILVIA\SQLEXPRESS;Initial Catalog=Zero_hunger;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            string query = "Select * from Resturant";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Resturant> r = new List<Resturant>();
            while (reader.Read())
            {
                Resturant r1 = new Resturant()
                {
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    ResturantID = reader.GetString(reader.GetOrdinal("ResturantID")),
                    Password = reader.GetString(reader.GetOrdinal("Password")),
                    Address = reader.GetString(reader.GetOrdinal("Address")),
                    Phone = reader.GetString(reader.GetOrdinal("Phone")),
                   
                };
                r.Add(r1);
            }
            conn.Close();
            return View(r);
           
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
            conn.Close();
            return View(r);
        }
        public ActionResult Profile()
        {
            string connString = @"Data Source=SILVIA\SQLEXPRESS;Initial Catalog=Zero_hunger;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            string query = "Select * from Admin";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Admin a1 = new Admin();
            while (reader.Read())
            {
                string Assigned = reader.GetString(reader.GetOrdinal("AdminID"));
                string id = Session["id"].ToString();

                if (Assigned == id)
                {
                    a1.adminID = reader.GetString(reader.GetOrdinal("AdminID"));
                    a1.name = reader.GetString(reader.GetOrdinal("Name"));
                    
                }
            }
            conn.Close();
            return View(a1);

        }

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }

             
        [HttpPost]
        public ActionResult CreateEmployee(Employee e)
        {
            string connString = @"Data Source=SILVIA\SQLEXPRESS;Initial Catalog=Zero_hunger;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            string query = String.Format("Insert into Employee values ('{0}', '{1}', '{2}','{3}')", e.name, e.employeeID, e.password, e.phone);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            conn.Close();
            return View();
        }


        public ActionResult Logout()
        {
            return RedirectToAction("Login", "Home");
        }

      
}
}