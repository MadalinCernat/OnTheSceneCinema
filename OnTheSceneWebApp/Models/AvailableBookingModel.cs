using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnTheSceneWebApp.Models
{
    public class AvailableBookingModel
    {
        public int Id { get; set; }
        [Required]
        public int MovieId { get; set; }
        public List<HoursModel> HoursAvailable { get; set; }
        [Required]
        public int CinemaHallId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
