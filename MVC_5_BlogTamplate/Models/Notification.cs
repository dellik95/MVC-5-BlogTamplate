using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_5_BlogTamplate.Models
{
    public class Notification
    {
        public int Id { get; private set; }

        public DateTime DateTime { get; set;}

        public NotificationType NotificationType { get; set;}

        public DateTime? OriginalDateTime { get; private set; }

        public string OriginalVenue { get; private set; }

        [Required] public Gig Gig { get; set;}

        public Notification()
        {
        }

      private  Notification(NotificationType type, Gig gig)
        {
            if (gig == null) throw new ArgumentNullException("gig");

            Gig = gig;
            DateTime = DateTime.Now;
            NotificationType = type;
        }

        public static Notification GigCreated(Gig gig)
        {
            return  new  Notification(NotificationType.GigCreated,gig);
        }

        public static Notification GigUpdated(Gig gig, DateTime dateTime, string Vanue)
        {
            var notification = new Notification(NotificationType.GigUpdated, gig)
            {
                OriginalDateTime = dateTime,
                OriginalVenue = Vanue
            };
            return notification;
        }

        public static Notification GigCaneled(Gig gig)
        {
            return  new Notification(NotificationType.GigCanceled,gig);
        }
    }
}