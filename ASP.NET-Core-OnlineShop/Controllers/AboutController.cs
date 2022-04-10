using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ASP.NET_Core_OnlineShop.Controllers
{
    public class AboutController:Controller
    {
       public IActionResult AboutUs()
       {
           return View();
       }
    }
}
