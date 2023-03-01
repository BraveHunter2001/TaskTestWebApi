using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskTestWebApi.Data.Repositories;
using TaskTestWebApi.Models;

namespace TaskTestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IResultRepository _resultRepo;
        private readonly IMapper _mapper;
        public ResultsController(IResultRepository repository, IMapper mapper)
        {
            _resultRepo = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<List<ResultDTO>> SearchResult(ResultSearch resultSearchModel)
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

            var resDto = _mapper.Map<List<ResultDTO>>(result.ToList());
            return resDto;
        }
    }
}
