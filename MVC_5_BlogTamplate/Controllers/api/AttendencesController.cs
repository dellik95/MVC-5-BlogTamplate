using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using MVC_5_BlogTamplate.Dto;
using MVC_5_BlogTamplate.Models;

namespace MVC_5_BlogTamplate.Controllers.api
{
    [Authorize]
    public class AttendencesController : ApiController
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AttendencesController()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendenceDto dto)
        {
            var currentUser = User.Identity.GetUserId();

            if (_applicationDbContext.Attendances
                .Any(a =>
                    a.AttendeeId == currentUser && a.GigId == dto.GigId))
                return BadRequest();
            var attendence = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = currentUser
            };

            _applicationDbContext.Attendances.Add(attendence);
            _applicationDbContext.SaveChanges();

            return Ok();
        }
    }
}