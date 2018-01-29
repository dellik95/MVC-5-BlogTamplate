using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using MVC_5_BlogTamplate.Models;

namespace MVC_5_BlogTamplate.Controllers.api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GigsController()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var currentUserId = User.Identity.GetUserId();

            var gig = _applicationDbContext.Gigs
                .Single(g => g.Id == id && g.ArtistId == currentUserId);

            if (gig.IsCanceled) return NotFound();

            gig.IsCanceled = true;
            _applicationDbContext.SaveChanges();

            return Ok();
        }
    }
}