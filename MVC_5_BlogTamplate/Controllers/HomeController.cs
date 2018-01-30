using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MVC_5_BlogTamplate.Models;
using MVC_5_BlogTamplate.ViewModel;

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
                .Include(g => g.Genre)
                .Where(g=>!g.IsCanceled).ToList();


            var viewModel = new GigsViewModel
            {
                Gigs = upcomingGigs,
                ShowAction = User.Identity.IsAuthenticated,
                Heading = "All Gigs"
            };


            return View("Gigs", viewModel);
        }

       

        
    }
}