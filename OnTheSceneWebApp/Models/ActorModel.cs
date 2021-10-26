using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnTheSceneWebApp.Models
{
    public class ActorModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Actor name required")]
        public string Name { get; set; }
    }
}
