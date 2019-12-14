namespace BusinessLayer.Repository.Interfaces
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork MakeUnitOfWork();
    }
}