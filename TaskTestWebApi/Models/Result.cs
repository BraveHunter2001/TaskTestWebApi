namespace Models;
public class Result
{
    public Guid Id { get; set; }
    public string NameFile { get; set; }
    public int TotalTime { get; set; }
    public DateTime MinimalDate { get; set; }
    public float AverageTime { get; set; }
    public float AverageIndicator { get; set; }
    public float MedianIndicator { get; set; }
    public float MinimumIndicator { get; set; }
    public float MaximumIndicator { get; set; }
    public int CountRow { get; set; }
}

