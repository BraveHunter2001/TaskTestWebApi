using CsvHelper;
using TaskTestWebApi.Models;
using System.Globalization;

int countValue = int.Parse(Console.ReadLine());
const int maxTimes = 1000;

Random random = new Random();

List<ValueDTO> values = new List<ValueDTO>();

for(int i = 0; i < countValue; i++)
{
    values.Add(
        new ValueDTO
        {
            Date= GetDateTime(random),
            Time = random.Next(0, maxTimes),
            Indicator = (float)random.NextDouble(),
        });
}

using (StreamWriter streamWriter = new StreamWriter($"test_{countValue}.csv"))
{
    using(CsvWriter cw = new CsvWriter(streamWriter, CultureInfo.CurrentCulture))
    {
        cw.WriteRecords(values);
    }
}


static DateTime GetDateTime(Random random)
{
    DateTime start = new DateTime(2000,1,1);
    int range = (DateTime.Now - start).Days;
    return start.AddDays(random.Next(range));
}
