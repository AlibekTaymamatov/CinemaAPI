namespace WebApi.Tests.ProductsController
{
    using Infrastructure.EF;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using WebAPI.MockFactory.Tests.Data;
    using WebAPI.MockFactory.Tests.Factory.Interfaces;
    using WebAPI.MockFactory.Tests.Utils;
    using Xunit;

    public class TestDeleteFilm : BaseTest
    {
        [Fact]
        public void DeleteFilmById_Return_NoContent()
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

            for (int i = 1; i <= testFilms.Count; i++)
            {
                // Act
                var result = filmsController.Delete(i);
                var successResult = result.Result;

                // Assert
                Assert.IsType<NoContentResult>(successResult);
            }
        }

        [Fact]
        public void DeleteFilmById_Return_NotFoundResult()
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
            var filmId = testFilms.Count + 1;

            // Act
            var result = filmsController.Delete(filmId);
            var notFoundResult = result.Result;

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
    }
}
