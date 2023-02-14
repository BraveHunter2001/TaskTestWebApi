using TaskTestWebApi.Models;

namespace TaskTestWebApi.Data.Repositories;
public interface IResultRepository : IDisposable
{
    IEnumerable<Result> GetItems();
    Result GetItemByNameFile(string name);
    IEnumerable<Result> GetItemsByMinimalDateBetween(DateTime from, DateTime to);
    IEnumerable<Result> GetItemsByAverageIndicatorBetween(float from, float to);
    IEnumerable<Result> GetItemsByAverageTimeBetween(float from, float to);
    Result GetItem(int id);
    void Add(Result item);
    void Delete(int id);
    void Delete(Result item);
    void Update(Result item);
    void Save();
}