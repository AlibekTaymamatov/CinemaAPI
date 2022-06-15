namespace WebApi.Tests.ProductsController
{
    using Application.ViewModels;
    using Infrastructure.EF;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using WebAPI.MockFactory.Tests.Data;
    using WebAPI.MockFactory.Tests.Factory.Interfaces;
    using WebAPI.MockFactory.Tests.Utils;
    using Xunit;

    public class TestAddFilm : BaseTest
    {
        [Fact]
        public void Insert_Return_OkResult()
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

            // Act
            var result = filmsController.Insert(TestDtoFilm.FilmB);
            var successResult = result.Result as OkObjectResult;
            var film = successResult.Value as FilmDto;
            var context = databaseInitializer.Getcontext();
            var dbFilm = context.Film.Find(film.Id);

            // Assert
            Assert.Equal(dbFilm.Id, film.Id);
        }
    }
}
