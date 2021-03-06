using OnTheSceneWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTheSceneWebApp.ViewModels
{
    public class AvailableBookingViewModel
    {
        public int AvailableBookingId { get; set; }
        public MovieModel Movie { get; set; }
        public List<HoursModel> Hours { get; set; }
        public CinemaHall CinemaHall { get; set; }
        public DateTime Date { get; set; }
    }
}
