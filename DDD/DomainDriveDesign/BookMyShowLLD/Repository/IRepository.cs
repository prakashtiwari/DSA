namespace BookMyShowLLD.Repository
{
    public interface IRepository
    {
        T Get<T>();
        void Add<T>(T entity);
    }
}
