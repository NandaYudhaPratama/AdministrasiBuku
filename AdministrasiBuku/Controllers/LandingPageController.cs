using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AdministrasiBuku.Controllers
{
    /// <summary>
    /// controller landing page
    /// </summary>
    public class LandingPageController : Controller
    {
        /// <summary>
        /// Menampilkan halaman Landing Page
        /// </summary>
        /// <returns>View dari .cshtml</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}