namespace WebApi.Tests.ProductsController
{
    using System.Collections.Generic;
    using Application.ViewModels;
    using Infrastructure.EF;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using WebAPI.MockFactory.Tests.Data;
    using WebAPI.MockFactory.Tests.Factory.Interfaces;
    using WebAPI.MockFactory.Tests.Utils;
    using Xunit;

    public class TestGetFilm : BaseTest
    {
        [Fact]
        public void GetFilms_Return_OkResult()
        {
            // Arrange
            var testFilms = TestFilms.AllProducts;
            IDatabaseInitializer databaseInitializer = TestDataFactory.CreateDatabaseInitializer();
            databaseInitializer.InitializeDatabase((ILogger<DatabaseInitializer> logger, DatabaseContext databaseContext) =>
            {
                databaseContext.AddRange(testFilms);
                databaseContext.SaveChanges();
            });

            IControllerFactory controllerFactory = TestDataFactory.CreateControllerFactory();
            Controllers.FilmsController productsController = controllerFactory.CreateFilmsController();

            // Act
            var result = productsController.Get();
            var successResult = result.Result as OkObjectResult;
            var listOfProducts = successResult.Value as List<FilmDto>;

            // Assert
            Assert.Equal(testFilms.Count, listOfProducts.Count);
        }

        [Fact]
        public void GetFilmById_Return_OkResult()
        {
            var testFilms = TestFilms.AllProducts;
            IDatabaseInitializer databaseInitializer = TestDataFactory.CreateDatabaseInitializer();
            databaseInitializer.InitializeDatabase((ILogger<DatabaseInitializer> logger, DatabaseContext databaseContext) =>
            {
                databaseContext.AddRange(testFilms);
                databaseContext.SaveChanges();
            });

            IControllerFactory controllerFactory = TestDataFactory.CreateControllerFactory();
            Controllers.FilmsController filmsController = controllerFactory.CreateFilmsController();

            for (int i = 1; i >= testFilms.Count; i++)
            {
                // Act
                var result = filmsController.GetById(i);
                var successResult = result.Result as OkObjectResult;
                var film = successResult.Value as FilmDto;

                // Assert
                Assert.Equal(testFilms[i - 1].Id, film.Id);
            }
        }

        [Fact]
        public void GetFilmById_Return_NotFoundResult()
        {
            // Arrange
            var testFilms = TestFilms.AllProducts;
            IDatabaseInitializer databaseInitializer = TestDataFactory.CreateDatabaseInitializer();
            databaseInitializer.InitializeDatabase((ILogger<DatabaseInitializer> logger, DatabaseContext databaseContext) =>
            {
                databaseContext.AddRange(testFilms);
                databaseContext.SaveChanges();
            });

            IControllerFactory controllerFactory = TestDataFactory.CreateControllerFactory();
            Controllers.FilmsController filmsController = controllerFactory.CreateFilmsController();
            var filmId = 4;

            // Act
            var result = filmsController.GetById(filmId);
            var notFoundResult = result.Result;

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
    }
}
