using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moviegram.API.Controllers;
using Moviegram.API.Utils.AutoMapper;
using Moviegram.Data.Context;
using Moviegram.Data.Entities;
using Moviegram.Shared.Interfaces;

namespace Moviegram.Shared.Test
{
    [TestClass]
    public class MoviesDataManagerTests
    {
        private Mock<MoviegramContext> _moviegramContextMock;
        IMapper _mapper;

        [TestInitialize]
        public void Setup()
        {

            var movies = new List<Movie> {
                    new Movie
                    {
                        Id = Guid.Parse("77111877-2b89-4876-b71d-6053b8395f5e"),
                        Title = "Avengers: Infinity War",
                        Details = "Here comes Thanos",
                        ReleaseDate = new DateTime(2018, 4, 23)
                    },
                    new Movie
                    {
                        Id = Guid.Parse("648a888b-9044-4a58-a3a7-69e5902019c6"),
                        Title = "Avengers: Endgame",
                        Details = "Thanos returns",
                        ReleaseDate = new DateTime(2019, 4, 24)
                    },
                    new Movie
                    {
                        Id = Guid.Parse("96c636b9-606e-4da6-b8fe-fd9290830d32"),
                        Title = "Jurrasic World: Fallen Kingdom",
                        Details = "Dinosaurs are here",
                        ReleaseDate = new DateTime(2018, 5, 21)
                    },
                                        new Movie
                    {
                        Id = Guid.Parse("96c636b9-606e-4da6-b8fe-fd9290830d32"),
                        Title = "Dark Night Rises",
                        Details = "Batman movies",
                        ReleaseDate = new DateTime(2008, 7, 18)
                    }
                }.AsQueryable();

            var moviesMock = new Mock<DbSet<Movie>>();
            moviesMock.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(movies.Provider);
            moviesMock.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(movies.Expression);
            moviesMock.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(movies.ElementType);
            moviesMock.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(movies.GetEnumerator());


            _moviegramContextMock = new Mock<MoviegramContext>();
            _moviegramContextMock.Setup(x => x.Movies).Returns(moviesMock.Object);

            var moviegramProfile = new MoviegramMappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(moviegramProfile));
            _mapper = new Mapper(configuration);
        }
  

        [TestMethod]
        public void MoviesSearch_TextFound()
        {
            //Arrange
            var searchText = "Thanos";
            var moviesDataManager = new MoviesDataManager(_moviegramContextMock.Object, _mapper);

            //Act
            var moviesFound = moviesDataManager.SearchMoviesDetailsForText(searchText).GetAwaiter().GetResult();

            //Assert
            Assert.AreEqual(2, moviesFound.Count);
        }

        [TestMethod]
        public void Movies_GetAllMovies()
        {
            //Arrange 
            var moviesDataManager = new MoviesDataManager(_moviegramContextMock.Object, _mapper);

            //Act 
            var allMovies = moviesDataManager.GetAllMovies().GetAwaiter().GetResult();

            //Assert
            Assert.AreEqual(4, allMovies.Count);
        }

        [TestMethod]
        public void Movie_GetById()
        {
            //Arrange
            var movieId = Guid.Parse("648a888b-9044-4a58-a3a7-69e5902019c6");
            var moviesDataManager = new MoviesDataManager(_moviegramContextMock.Object, _mapper);

            //Act
            var movie = moviesDataManager.GetMovieById(movieId).GetAwaiter().GetResult();

            //Assert
            Assert.IsNotNull(movie);
            Assert.AreEqual("Avengers: Endgame", movie.Title);
        }
    }
}
