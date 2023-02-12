using CsvHelper;
using Models;
using System.Globalization;

const int countValue = 1000;
const int maxTimes = 10000;

Random random = new Random();

List<Value> values = new List<Value>();

for(int i = 0; i < countValue; i++)
{
    values.Add(
        new Value {
            Date= GetDateTime(random),
            Time = random.Next(0, maxTimes),
            Indicator = (float)random.NextDouble(),
        });
}

using (StreamWriter streamWriter = new StreamWriter("test.csv"))
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
