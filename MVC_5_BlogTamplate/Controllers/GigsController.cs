using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MVC_5_BlogTamplate.Models;
using MVC_5_BlogTamplate.ViewModel;

namespace MVC_5_BlogTamplate.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GigsController()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigsFormViewModel
            {
                Genres = _applicationDbContext.Genres.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigsFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _applicationDbContext.Genres.ToList();
                return View("Create", viewModel);
            }
            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Vanue = viewModel.Vanue
            };

            _applicationDbContext.Gigs.Add(gig);
            _applicationDbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}