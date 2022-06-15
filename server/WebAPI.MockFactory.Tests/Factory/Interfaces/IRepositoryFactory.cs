namespace WebAPI.MockFactory.Tests.Factory.Interfaces
{
    using Domain.Repository;

    public interface IRepositoryFactory
    {
        IFilmRepository CreateFilmsRepository();
    }
}