using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTheSceneWebApp.Models
{
    class AvailableBookingModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public List<string> HoursAvailable { get; set; }
        public int CinemaHallId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
