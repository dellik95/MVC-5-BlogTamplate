using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MVC_5_BlogTamplate.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public ApplicationUser Artist { get; set; }

        public bool IsCanceled { get; private set; }

        [Required] public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        [Required] [StringLength(255)] public string Vanue { get; set; }

        public Genre Genre { get; set; }

        [Required] public byte GenreId { get; set; }

        public ICollection<Attendance> Attendences { get; private set; }

        public Gig()
        {
            Attendences = new Collection<Attendance>();
        }

        public void Cancel()
        {
            IsCanceled = true;

            var notification = Notification.GigCaneled(this);


            foreach (var attendee in Attendences.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        public void Notify(DateTime dateTime, string viewModelVanue, byte viewModelGenre)
        {
            var notification = Notification.GigUpdated(this, dateTime, viewModelVanue);

            Vanue = viewModelVanue;
            DateTime = dateTime;
            GenreId = viewModelGenre;

            foreach (var attendence in Attendences.Select(a=>a.Attendee))
            {
                attendence.Notify(notification);
            }
        }

    }
}