using OnTheSceneWebApp.Data;
using OnTheSceneWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTheSceneWebApp.Services
{
    public class CrudOperations
    {
        private readonly MoviesDbContext _db;

        public CrudOperations(MoviesDbContext db)
        {
            _db = db;
        }
        public async Task CreateMovie(MovieModel movie)
        {
            using(_db)
            {
                await _db.Movies.AddAsync(movie);
                await _db.SaveChangesAsync();
            }
        }
    }
}
