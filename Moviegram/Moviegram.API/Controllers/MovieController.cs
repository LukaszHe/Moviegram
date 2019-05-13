using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moviegram.Shared.Domain;
using Moviegram.Shared.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Moviegram.API.Controllers
{
    [Produces("application/json")]
    [Route("api/movie")]
    public class MovieController : Controller
    {
        private readonly IMoviesDataManager _moviesDataManager;

        public MovieController(IMoviesDataManager moviesDataManager)
        {
            _moviesDataManager = moviesDataManager;
        }

        /// <summary>
        /// Find movie by ID
        /// </summary>
        /// <remarks>Returns a single movie data</remarks>
        /// <param name="movieId">ID of movie to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Movie not found</response>
        [HttpGet]
        [Route("/api/movie/{movieId}")]
        [SwaggerOperation("GetMovieById")]
        [SwaggerResponse(statusCode: 200, type: typeof(MovieDTO), description: "successful operation")]
        public async Task<IActionResult> GetMoviedById(Guid movieId)
        {
            var movie = await _moviesDataManager.GetMovieById(movieId);

            if (movie == null)
            {
                return NotFound();
            }

            return new ObjectResult(movie);
        }

        /// <summary>
        /// Get list of all movies
        /// </summary>
        /// <remarks>Returns the whole list of the movies</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="404">No movies in the database</response>
        [HttpGet]
        [Route("/api/movie/GetAllMovies")]
        [SwaggerOperation("GetAllMovies")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<MovieDTO>), description: "successful operation")]
        public async Task<IActionResult> Get()
        {
            var moviesList = await _moviesDataManager.GetAllMovies();

            if (moviesList == null || moviesList.Count() == 0)
            {
                return NotFound();
            }

            return new ObjectResult(moviesList);
        }

        /// <summary>
        /// Get list of all movies with a given text in their details
        /// </summary>
        /// <remarks>Return a list of movies where the search text occurs in the details </remarks>
        /// <param name="searchText">Text to search</param>
        /// <response code="200">successful operation</response>
        /// <response code="404">Movies with the search text not found</response>
        [HttpGet]
        [Route("/api/movie/SearchMoviesDetails/{searchText}")]
        [SwaggerOperation("SearchMoviesDetails")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<MovieDTO>), description: "successful operation")]
        public async Task<IActionResult> SearchMoviesDetails(string searchText)
        {
            var moviesList = await _moviesDataManager.SearchMoviesDetailsForText(searchText);

            if (moviesList == null || moviesList.Count() == 0)
            {
                return NotFound();
            }

            return new ObjectResult(moviesList);
        }
    }
}
