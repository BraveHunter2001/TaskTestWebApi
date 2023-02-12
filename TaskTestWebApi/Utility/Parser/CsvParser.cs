using CsvHelper;
using System.Globalization;

namespace TaskTestWebApi.Utility.Parser
{
    public class CsvParser : IParser, IDisposable
    {
        private bool disposedValue;
        StreamReader _stream;
        CsvReader _csvReader;



        public IEnumerable<T> GetRecords<T>(IFormFile file)
        {
            IEnumerable<T> values;

            _stream = new StreamReader(file.OpenReadStream());
            _csvReader = new CsvReader(_stream, CultureInfo.CurrentCulture);

            values = _csvReader.GetRecords<T>();

            return values;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if(_stream != null)
                        _stream.Dispose();
                    if(_csvReader!= null)
                        _csvReader.Dispose();
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
