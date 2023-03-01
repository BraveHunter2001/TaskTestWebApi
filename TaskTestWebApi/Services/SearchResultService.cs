using System.Xml.Serialization;
using TaskTestWebApi.Data.Repositories;
using TaskTestWebApi.Models;

namespace TaskTestWebApi.Services;
public class SearchResultService
{
    private readonly IResultRepository _resultRepo;
    public SearchResultService(IResultRepository resultRepo) => _resultRepo = resultRepo;
    public IEnumerable<Result> Search(ResultSearch resultSearchModel)
    {
        var result = _resultRepo.GetItems();

        if (resultSearchModel != null)
        {
            if (!string.IsNullOrEmpty(resultSearchModel.NameFile))
            {
                result = result.Where(res => res.NameFile == resultSearchModel.NameFile);
            }
            if (resultSearchModel.MinimalDateRange != null)
            {
                result = result.Where(res =>
                    res.MinimalDate >= resultSearchModel.MinimalDateRange.LowerLimit &&
                    res.MinimalDate <= resultSearchModel.MinimalDateRange.UpperLimit
                );
            }
            if (resultSearchModel.AverageIndicatorRange != null)
            {
                result = result.Where(res =>
                    res.AverageIndicator >= resultSearchModel.AverageIndicatorRange.LowerLimit &&
                    res.AverageIndicator <= resultSearchModel.AverageIndicatorRange.UpperLimit
                );
            }

            if (resultSearchModel.AverageTimeRange != null)
            {
                result = result.Where(res =>
                    res.AverageTime >= resultSearchModel.AverageTimeRange.LowerLimit &&
                    res.AverageTime <= resultSearchModel.AverageTimeRange.UpperLimit
                );
            }
        }

        return result;
    }
}

