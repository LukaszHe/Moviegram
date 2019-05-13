﻿using Moviegram.Data.Entities;
using Moviegram.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moviegram.Shared.Interfaces
{
    public interface IMoviesDataManager
    {
        Task<ICollection<MovieDTO>> GetAllMovies();
        Task<MovieDTO> GetMovieById(Guid movieId);
        Task<ICollection<MovieDTO>> SearchMoviesDetailsForText(string searchText);
    }
}
