using System;
using System.ComponentModel.DataAnnotations;
using MVC_5_BlogTamplate.Models;

namespace MVC_5_BlogTamplate.Dto
{
    public class NotificationDto
    {

        public DateTime DateTime { get; set;}

        public NotificationType NotificationType { get; set;}

        public DateTime? OriginalDateTime { get;  set; }

        public string OriginalVenue { get;  set; }

        public GigDto Gig { get; set;}

    }
}