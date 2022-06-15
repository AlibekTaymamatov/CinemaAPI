namespace WebAPI.MockFactory.Tests.Factory
{
    using Application.Interfaces;
    using Application.Services;

    using WebAPI.MockFactory.Tests.Factory.Interfaces;

    public class ServiceFactory : IServiceFactory
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public ServiceFactory(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public IFilmService CreateFilmsService()
        {
            return new FilmsService(_repositoryFactory.CreateFilmsRepository());
        }
    }
}
