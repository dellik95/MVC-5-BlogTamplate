using System.Linq;
using System.Web.Http;
using AutoMapper.Mappers;
using Microsoft.AspNet.Identity;
using MVC_5_BlogTamplate.Dto;
using MVC_5_BlogTamplate.Models;

namespace MVC_5_BlogTamplate.Controllers.api
{
    [Authorize]
    public class FollowingController : ApiController
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FollowingController()
        {
            _applicationDbContext = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var currentUser = User.Identity.GetUserId();


            bool isFollow =
                _applicationDbContext.Followings.Any(f =>
                    f.FolloweeId == currentUser && f.FolloweeId == dto.FolloweeId);


            if (isFollow) return BadRequest();

            var following = new Following
            {
                FolloweeId = dto.FolloweeId,
                FollowerId = currentUser
            };

            _applicationDbContext.Followings.Add(following);
            _applicationDbContext.SaveChanges();

            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult Unfollow(string id)
        {
            var currentUserId = User.Identity.GetUserId();

            var follow =
                _applicationDbContext.Followings.SingleOrDefault(f =>
                    f.FolloweeId == id && f.FollowerId == currentUserId);

            if (follow != null)
            {
                _applicationDbContext.Followings.Remove(follow);
                _applicationDbContext.SaveChanges();
                return Ok(id);
            }

            return BadRequest();
        }
    }
}