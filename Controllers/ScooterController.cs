using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Shop.Models;
using System.Net;

namespace Shop.Controllers
{
    public class ScooterController : Controller
    {
        SqlConnection connection = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataReader dr;
        private ApplicationDbContext db = new ApplicationDbContext();



        public List<Product> productsScooter = new List<Product>();
        public ActionResult ScooterSh()
        {
            DisplayData();
            return View(productsScooter);
        }
        public ActionResult ScooterProp(int id)
        {
            Product productScooter = db.products.Find(id);
            return View(productScooter);
        }

        public ScooterController()
        {
            connection.ConnectionString = Shop.Properties.Resources.conString;
        }
        private void DisplayData()
        {
            if(productsScooter.Count > 0)
            {
                productsScooter.Clear();
            }
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT TOP (1000) [Id],[Name],[Price],[img],[Description],[categoryId] FROM [shopDB].[dbo].[Products] WHERE categoryID = 'Scooter'";
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    productsScooter.Add(new Product
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        Price = Convert.ToInt32(dr["Price"]),
                        img = dr["img"].ToString(),
                        Description = dr["Description"].ToString()

                    });
                    
                }
                connection.Close();
            }
            catch (Exception ex )
            {

                throw ex;
            }

        }
    }
}