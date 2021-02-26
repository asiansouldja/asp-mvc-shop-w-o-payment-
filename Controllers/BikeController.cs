using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Microsoft.Owin.Logging;
using Microsoft.Extensions.Logging;
using Shop.Models;

namespace Shop.Controllers
{
    public class BikeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        SqlConnection connection = new SqlConnection();
        SqlDataReader dr;
        SqlCommand command = new SqlCommand();
        public List<Product> products = new List<Product>();
        public ActionResult BikeSh()
        {
            DisplayData();
            return View(products);
        }

        public ActionResult BikeProp(int id)
        {
            Product product = db.products.Find(id);
            return View(product);
        }

        public BikeController()
        {
            connection.ConnectionString = Shop.Properties.Resources.conString;
        }

        private void DisplayData()
        {
            if (products.Count > 0)
            {
                products.Clear();
            }
            try
            {
                
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT TOP (1000) [Id], [Name],[Price],[img],[Description],[categoryId] FROM [shopDB].[dbo].[Products] WHERE categoryID = 'Bike'";
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    products.Add(new Product()
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
            catch (Exception ex)
            {

                throw ex; 
            }
        }
    }
}