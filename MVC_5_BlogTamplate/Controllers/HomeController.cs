using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_5_BlogTamplate.Models;

namespace MVC_5_BlogTamplate.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public HomeController()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var upcomingGigs = _applicationDbContext.Gigs
                .Include(x => x.Artist)
                .Where(g => g.DateTime < DateTime.Now).ToList();

            return View(upcomingGigs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}