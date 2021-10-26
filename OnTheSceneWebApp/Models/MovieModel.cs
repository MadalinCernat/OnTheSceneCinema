using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTheSceneWebApp.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateReleased { get; set; }
        public string PosterUrl { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public List<ActorModel> Actors { get; set; }
        public string Plot { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
