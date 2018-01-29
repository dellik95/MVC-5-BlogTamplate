using System.Data.Entity;
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
                Genres = _applicationDbContext.Genres.ToList(),
                Heading = "Create new Gig"
            };

            return View("GigForm",viewModel);
        }


        [Authorize]
        public ActionResult Edit(int id)
        {
            var currentUserId = User.Identity.GetUserId();

            var gig = _applicationDbContext.Gigs.Single(g => g.ArtistId == currentUserId && g.Id == id);
            var viewModel = new GigsFormViewModel
            {
                Heading = "Edit a Gig",
                Id = gig.Id,
                Genres = _applicationDbContext.Genres.ToList(),
                Date = gig.DateTime.ToString("d MMM yyyy"),
                Time = gig.DateTime.ToString("HH:mm"),
                Genre =gig.GenreId,
                Vanue = gig.Vanue
            };

            return View("GigForm",viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigsFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _applicationDbContext.Genres.ToList();
                return View("GigForm", viewModel);
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

            return RedirectToAction("Mine", "Gigs");
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GigsFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _applicationDbContext.Genres.ToList();
                return View("GigForm", viewModel);
            }

            var currentUserId = User.Identity.GetUserId();

            var gig = _applicationDbContext.Gigs.Single(g => g.Id == viewModel.Id && g.ArtistId == currentUserId);


            gig.Vanue = viewModel.Vanue;
            gig.DateTime = viewModel.GetDateTime();
            gig.GenreId = viewModel.Genre;

            _applicationDbContext.SaveChanges();

            return RedirectToAction("Mine", "Gigs");
        }

        public ActionResult Attempting()
        {
            var currentUser = User.Identity.GetUserId();

            var gigs = _applicationDbContext.Attendances
                .Where(a => a.AttendeeId == currentUser)
                .Select(a => a.Gig)
                .Include(x => x.Artist)
                .Include(g => g.Genre)
                .ToList();


            var gigsViewModel = new GigsViewModel
            {
                Gigs = gigs,
                ShowAction = User.Identity.IsAuthenticated,
                Heading = "Gigs I`m Attempting"
            };
            return View("Gigs", gigsViewModel);
        }


        [Authorize]
        public ActionResult Mine()
        {
            var currentUserId = User.Identity.GetUserId();

            var mineGigs = _applicationDbContext.Gigs
                .Where(g => g.ArtistId == currentUserId && !g.IsCanceled)
                .Include(i => i.Genre)
                .ToList();

            return View("Mine",mineGigs);
        }
    }
}