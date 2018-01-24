using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

            if (_applicationDbContext.Followings.Any(f => f.FolloweeId == currentUser && f.FolloweeId == dto.FolloweeId))
            {
                return BadRequest();
            }

            var following = new Following()
            {
                FolloweeId = dto.FolloweeId,
                FollowerId = currentUser
            };

            _applicationDbContext.Followings.Add(following);
            _applicationDbContext.SaveChanges();

            return Ok();
        }

    }
}
