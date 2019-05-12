using Moviegram.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moviegram.Shared.Domain;
using Moviegram.Data.Context;
using System.Data.Entity;
using AutoMapper;

namespace Moviegram.Shared
{
    public class MoviesDataManager : IMoviesDataManager
    {
        private readonly MoviegramContext _moviegramContext;
        private readonly IMapper _mapper;

        public MoviesDataManager(MoviegramContext moviegramContext, IMapper mapper)
        {
            _moviegramContext = moviegramContext;
            _mapper = mapper;
        }

        public async Task<ICollection<MovieDTO>> GetAllMovies()
        {
            var moviesList = _moviegramContext.Movies.ToListAsync();

            return _mapper.Map<List<MovieDTO>>(moviesList);
        }

        public async Task<MovieDTO> GetMovieById(Guid movieId)
        {
            var movie = _moviegramContext.Movies.FindAsync(movieId);

            return _mapper.Map<MovieDTO>(movie);
        }
    }
}
