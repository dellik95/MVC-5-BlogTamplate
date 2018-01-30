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

        public ActionResult Index(string query = null)
        {
            var upcomingGigs = _applicationDbContext.Gigs
                .Include(x => x.Artist)
                .Include(g => g.Genre)
                .Where(g => !g.IsCanceled);

            if (!string.IsNullOrWhiteSpace(query))
            {
                upcomingGigs = upcomingGigs
                    .Where(g =>
                        g.Artist.Name.Contains(query)||
                        g.Genre.Name.Contains(query)||
                        g.Vanue.Contains(query));
            }



            var viewModel = new GigsViewModel
            {
                SearchTerm = query,
                Gigs = upcomingGigs,
                ShowAction = User.Identity.IsAuthenticated,
                Heading = "All Gigs"
            };


            return View("Gigs", viewModel);
        }




    }
}