namespace TaskTestWebApi.Utility.Parser
{
    public interface IParser
    {
        public IEnumerable<T> GetRecords<T>(IFormFile file);
    }
}
