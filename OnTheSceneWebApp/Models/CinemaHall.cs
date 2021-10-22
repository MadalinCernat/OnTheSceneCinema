using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTheSceneWebApp.Models
{
    class CinemaHall
    {
        public int Id { get; set; }
        public int NumberOfRows { get; set; }
        public int NumberOfColumns { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
