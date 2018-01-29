using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using MVC_5_BlogTamplate.Dto;
using MVC_5_BlogTamplate.Models;

namespace MVC_5_BlogTamplate.Controllers.api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public NotificationsController()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        public List<NotificationDto> GetNewNotification()
        {
            var currentUserId = User.Identity.GetUserId();

            var notification = _applicationDbContext.UserNotifications
                .Where(us => us.UserId == currentUserId && !us.IsRead)
                .Select(un => un.Notification)
                .Include(un => un.Gig.Artist)
                .ToList();


            return notification.Select(Mapper.Map<Notification, NotificationDto>).ToList();
        }
    }
}