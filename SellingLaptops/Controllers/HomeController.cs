using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Models;
using SellingLaptops.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SellingLaptops.Controllers
{
    public class HomeController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<Details> details = new List<Details>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            con.ConnectionString = SellingLaptops.Properties.Resources.ConnectionString;
        }

        public IActionResult Index()
        {
            FetchData();
            return View(details);
        }
        private void FetchData()
        {
            if (details.Count > 0)
            {
                details.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) [ID],[ProductName],[ImgUrl],[Price],[Description] FROM [SellingLaptops].[dbo].[LaptopModel]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    details.Add(new Details()
                    {
                        ID = (int)dr["ID"],
                        ProductName = dr["ProductName"].ToString(),
                        ImgUrl = dr["ImgUrl"].ToString(),
                        Price = (int)dr["Price"],
                        Description = dr["Description"].ToString(),
                    });
                    
                }
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex ;
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
