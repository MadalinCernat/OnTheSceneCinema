using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTheSceneWebApp.Models
{
    public class HoursModel
    {
        public int Id { get; set; }
        public string Hour { get; set; }
        public string Minutes { get; set; }
        public int AvailableBookingModelId { get; set; }
    }
}
