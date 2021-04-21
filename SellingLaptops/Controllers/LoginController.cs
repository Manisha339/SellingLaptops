using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellingLaptops.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
