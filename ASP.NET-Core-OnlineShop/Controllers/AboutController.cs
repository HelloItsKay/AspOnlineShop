using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ASP.NET_Core_OnlineShop.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    public class AboutController:Controller
    {
       public IActionResult AboutUs()
       {
           return View();
       }
    }
}
