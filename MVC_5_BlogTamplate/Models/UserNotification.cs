using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_5_BlogTamplate.Models
{
    public class UserNotification
    {
        [Key] [Column(Order = 1)] public string UserId { get; private set; }

        [Key] [Column(Order = 2)] public int NotificationId { get; set; }

        public ApplicationUser User { get; set; }

        public Notification Notification { get; set; }

        public bool IsRead { get; set; }

        public UserNotification(ApplicationUser user, Notification notification)
        {
            User = user ?? throw new ArgumentNullException();
            Notification = notification ?? throw new ArgumentNullException();
        }


        protected UserNotification()
        {
        }

        public void Read()
        {
            this.IsRead = true;
        }
    }
}