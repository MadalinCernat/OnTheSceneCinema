using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnTheSceneWebApp.Models
{
    public class MovieModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "DateReleased is required")]
        public DateTime DateReleased { get; set; }

        [Required(ErrorMessage = "PosterUrl is required")]
        public string PosterUrl { get; set; }

        [Required(ErrorMessage = "Runtime is required")]
        public string Runtime { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }

        public List<ActorModel> Actors { get; set; }

        [Required(ErrorMessage = "Plot is required")]
        public string Plot { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
