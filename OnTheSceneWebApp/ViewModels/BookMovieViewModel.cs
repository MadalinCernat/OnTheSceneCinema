using OnTheSceneWebApp.Models;
using System.Collections.Generic;

namespace OnTheSceneWebApp.ViewModels
{
    public class BookMovieViewModel
    {
        public MovieModel Movie { get; set; }
        public AvailableBookingModel AvailableBooking { get; set; } = new AvailableBookingModel();
        public int HourId { get; set; }
    }
}
