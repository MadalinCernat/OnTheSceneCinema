using OnTheSceneWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTheSceneWebApp.ViewModels
{
    public class CreateAvailableBookingViewModel
    {
        public AvailableBookingModel AvailableBooking { get; set; }
        public List<MovieTitleId> TitleId { get; set; }
        public List<CinemaHall> Halls { get; set; }
    }
}
