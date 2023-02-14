using TaskTestWebApi.Models;

namespace TaskTestWebApi.Data.Repositories
{
    public class ValueRepository : IValueRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private bool disposedValue;
        public ValueRepository(ApplicationDbContext context) => _dbContext = context;
        public void Add(Value item)
        {
            _dbContext.Values.Add(item);
        }

        public void Delete(int id)
        {
            Value value = _dbContext.Values.Find(id);
            Delete(value);
        }

        public void Delete(Value item)
        {
            _dbContext.Values.Remove(item);
        }

        public Value GetItem(int id)
        {
            return _dbContext.Values.Find(id);
        }

        public IEnumerable<Value> GetItems()
        {
            return _dbContext.Values.ToList();
        }

        public IEnumerable<Value> GetItemsByName(string name)
        {
           var values  = _dbContext.Values.Where(value=> value.Namefile== name);
           return values;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Value item)
        {
            Value oldValue = _dbContext.Values.Find(item.Id);
            oldValue.Date = item.Date;
            oldValue.Time = item.Time;
            oldValue.Indicator = item.Indicator;
            oldValue.Namefile = item.Namefile;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

       
    }
}
