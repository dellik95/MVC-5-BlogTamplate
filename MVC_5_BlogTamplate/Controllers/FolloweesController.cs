using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MVC_5_BlogTamplate.Models;

namespace MVC_5_BlogTamplate.Controllers
{
    [System.Web.Mvc.Authorize]
    public class FolloweesController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FolloweesController()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        
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