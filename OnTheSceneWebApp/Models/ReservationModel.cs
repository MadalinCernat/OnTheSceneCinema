using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTheSceneWebApp.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public int UniqueCodeId { get; set; }
        public int AvailableBookingId { get; set; }
        public List<ChairModel> Chairs { get; set; }
        public string Time { get; set; }
        public bool OnlineReservation { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
