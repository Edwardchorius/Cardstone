using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Cardstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cardstone.Web.Controllers.HomeControllers
{
    public class SignedInHomeController : Controller
    {
        public IActionResult SignedInIndex()
        {
            return View();
        }

        public IActionResult SignedInAbout()
        {
            ViewData["Message"] = "Your Signed In  application description page.";

            return View();
        }

        public IActionResult SignedInContact()
        {
            ViewData["Message"] = "Your Signed In contact page.";

            return View();
        }

        public IActionResult SignedInPrivacy()
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