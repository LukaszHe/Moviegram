using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moviegram.Shared.Interfaces;

namespace Moviegram.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Movie")]
    public class MovieController : Controller
    {
        private readonly IMoviesDataManager _moviesDataManager; 
        
        public MovieController()
        {

        }
        [HttpGet]
        [Route("GetAllMovies")]
        public async Task<IActionResult> Get()
        {
            var moviesList = await _moviesDataManager.GetAllMovies();

            if(moviesList == null)
            {
                return NotFound();
            }

            return new ObjectResult(moviesList);

        }
    }
}
