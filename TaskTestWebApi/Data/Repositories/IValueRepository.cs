using TaskTestWebApi.Models;

namespace TaskTestWebApi.Data.Repositories;
public interface IValueRepository : IDisposable 
{
    IEnumerable<Value> GetItems();
    IEnumerable<Value> GetItemsByNameFile(string name);
    Value GetItem(int id);
    void Add(Value value);
    void Delete(int id);
    void Delete(Value Value);
    void Update(Value Value);
    void Save();
}