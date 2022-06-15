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

    public class TestUpdateFilm : BaseTest
    {
        [Fact]
        public void Update_Return_OkResult()
        {
            // Arrange
            var testData = TestFilms.AllProducts;
            IDatabaseInitializer databaseInitializer = TestDataFactory.CreateDatabaseInitializer();
            databaseInitializer.InitializeDatabase((ILogger<DatabaseInitializer> logger, DatabaseContext databaseContext) =>
            {
                databaseContext.AddRange(testData);
                databaseContext.SaveChanges();
            });

            IControllerFactory controllerFactory = TestDataFactory.CreateControllerFactory();
            Controllers.FilmsController filmsController = controllerFactory.CreateFilmsController();

            // Act
            var result = filmsController.Update(TestDtoFilm.FilmA);
            var successResult = result.Result as OkObjectResult;
            var film = successResult.Value as FilmDto;

            // Assert
            Assert.Equal(testData[0].Id, film.Id);
        }
    }
}
