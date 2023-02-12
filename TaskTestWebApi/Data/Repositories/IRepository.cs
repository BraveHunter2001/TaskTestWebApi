namespace TaskTestWebApi.Data.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetItems();
        T GetItem(int id);
        void Add(T item);
        void Delete(int id);
        void Delete(T item);
        void Update(T item);
        void Save();
    }
}
