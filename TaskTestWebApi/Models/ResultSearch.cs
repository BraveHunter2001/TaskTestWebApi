
namespace TaskTestWebApi.Models;
public class ResultSearch 
{
    public string? NameFile { get; set; }
    public RangeDataSearch<DateTime>? MinimalDateRange { get; set; }
    public RangeDataSearch<float>? AverageIndicatorRange { get; set; }
    public RangeDataSearch<float>? AverageTimeRange { get; set; }

}

public class RangeDataSearch<T> where T: struct
{
    public T? LowerLimit { get; set; }
    public T? UpperLimit { get; set; }
}