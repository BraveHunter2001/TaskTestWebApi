using TaskTestWebApi.Models;

public static class CreateResultUtility
{
    public static ResultDTO CalculateBySamples(List<ValueDTO> samples)
    {
        ResultDTO value = new ResultDTO
        {
            TotalTime = CalculateTotalTime(samples),
            MinimalDate = samples.Min(sample => sample.Date),
            AverageTime = (float)samples.Average(samples => samples.Time),
            AverageIndicator = (float)samples.Average(samples => samples.Time),
            MedianIndicator = CalculateMedian(samples),
            MinimumIndicator = samples.Min(sample => sample.Indicator),
            MaximumIndicator = samples.Max(sample => sample.Indicator),
            CountRow = samples.Count()
        };

        return value;
    }
    private static int CalculateTotalTime(List<ValueDTO> samples)
    {
       
        int[] times = samples.Select(s => s.Time).ToArray();

        return times.Max() - times.Min();
    }
    private static float CalculateMedian(List<ValueDTO> samples)
    {
        float[] indicator = samples.Select(s => s.Indicator).ToArray();

        Array.Sort(indicator);

        if (indicator.Length % 2 == 1)
            return indicator[indicator.Length / 2];
        else
            return 0.5f * (indicator[(indicator.Length / 2 - 1)] + indicator[indicator.Length / 2]);
    }
}