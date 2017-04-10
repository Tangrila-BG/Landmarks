namespace DeltaDucks.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
