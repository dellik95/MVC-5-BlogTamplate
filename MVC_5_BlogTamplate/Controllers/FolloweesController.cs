using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MVC_5_BlogTamplate.Models;

namespace MVC_5_BlogTamplate.Controllers
{
    public class FolloweesController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FolloweesController()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Following()
        {
            var currentUserId = User.Identity.GetUserId();

            var followQuery = _applicationDbContext.Followings
                .Where(f => f.FollowerId == currentUserId)
                .Include(f => f.Followee)
                .ToList();

            return View(followQuery);
        }
    }
}