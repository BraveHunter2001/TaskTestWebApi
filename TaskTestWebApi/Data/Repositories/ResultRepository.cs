using System.Xml.Linq;
using TaskTestWebApi.Models;

namespace TaskTestWebApi.Data.Repositories
{
    public class ResultRepository :IResultRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private bool disposedValue;

        public ResultRepository(ApplicationDbContext context) => _dbContext = context;
        public void Add(Result item)
        {
            _dbContext.Results.Add(item);
        }
        public void Delete(int id)
        {
            Result value = _dbContext.Results.Find(id);
            Delete(value);
        }
        public void Delete(Result item)
        {
            _dbContext.Results.Remove(item);
        }
        public Result GetItem(int id)
        {
            return _dbContext.Results.Find(id);
        }
        public IEnumerable<Result> GetItems()
        {
            return _dbContext.Results.ToList();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Result item)
        {
            Result oldValue = _dbContext.Results.Find(item.Id);
            oldValue.NameFile = item.NameFile;
            oldValue.TotalTime = item.TotalTime;
            oldValue.MinimalDate = item.MinimalDate;
            oldValue.AverageTime = item.AverageTime;
            oldValue.AverageIndicator = item.AverageIndicator;
            oldValue.MedianIndicator = item.MedianIndicator;
            oldValue.MinimumIndicator = item.MinimumIndicator;
            oldValue.MaximumIndicator = item.MaximumIndicator;
            oldValue.CountRow = item.CountRow;
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

        public Result GetItemByNameFile(string name)
        {
            var results = _dbContext.Results.FirstOrDefault(res=>res.NameFile == name);

            return results;
        }

        public IEnumerable<Result> GetItemsByMinimalDateBetween(DateTime from, DateTime to)
        {
            var results = _dbContext.Results.Where(res => res.MinimalDate >=from || res.MinimalDate <= to);
            return results;
        }

        public IEnumerable<Result> GetItemsByAverageIndicatorBetween(float from, float to)
        {
            var results = _dbContext.Results.Where(res => res.AverageIndicator >= from || res.AverageIndicator <= to);
            return results;
        }

        public IEnumerable<Result> GetItemsByAverageTimeBetween(float from, float to)
        {
            var results = _dbContext.Results.Where(res => res.AverageTime >= from || res.AverageTime <= to);
            return results;
        }
    }
}
