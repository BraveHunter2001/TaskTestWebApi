using System.ComponentModel.DataAnnotations;

namespace TaskTestWebApi.Models;
public class ResultDTO
{
    public int TotalTime { get; set; }
    public DateTime MinimalDate { get; set; }
    public float AverageTime { get; set; }
    public float AverageIndicator { get; set; }
    public float MedianIndicator { get; set; }
    public float MinimumIndicator { get; set; }
    public float MaximumIndicator { get; set; }
    [Range(1, 10000)]
    public int CountRow { get; set; }
    public string NameFile { get; set; }
}

