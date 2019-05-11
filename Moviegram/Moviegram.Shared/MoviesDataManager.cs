using Moviegram.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moviegram.Shared.Domain;
using Moviegram.Data.Context;
using System.Data.Entity;

namespace Moviegram.Shared
{
    public class MoviesDataManager : IMoviesDataManager
    {
        private readonly MoviegramContext _moviegramContext;  

        public MoviesDataManager(MoviegramContext moviegramContext)
        {
            _moviegramContext = moviegramContext;
        }

        public async Task<ICollection<MovieDTO>> GetAllMovies()
        {
            var moviesList = _moviegramContext.Movies.ToListAsync();

            return new List<MovieDTO>();
        }
    }
}
