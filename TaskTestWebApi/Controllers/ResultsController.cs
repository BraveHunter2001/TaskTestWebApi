using AutoMapper;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        [Route("search/{namefile}")]
        public ActionResult<ResultDTO> SearchByName(string namefile)
        {
            Result results = _resultRepo.GetItemByNameFile(namefile);

            var resultdto = _mapper.Map<ResultDTO>(results);

            return Ok(resultdto);
        }

        [HttpGet]
        [Route("search/MinimalDate/from={from}&to={to}")]
        public ActionResult<List<ResultDTO>> SearchByDatetime(DateTime from, DateTime to)
        {
            List<Result> results = _resultRepo.GetItemsByMinimalDateBetween(from,to).ToList();

            var resultdto = _mapper.Map<List<ResultDTO>>(results);

            return Ok(resultdto);
        }

        [HttpGet]
        [Route("search/AverageIndicator/from={from}&to={to}")]
        public ActionResult<List<ResultDTO>> SearchByAverageInd(float from, float to)
        {
            List<Result> results = _resultRepo.GetItemsByAverageIndicatorBetween(from,to).ToList();

            var resultdto = _mapper.Map<List<ResultDTO>>(results);

            return Ok(resultdto);
        }

        [HttpGet]
        [Route("search/AverageTime/from={from}&to={to}")]
        public ActionResult<List<ResultDTO>> SearchByAverageTime(float from, float to)
        {
            List<Result> results = _resultRepo.GetItemsByAverageTimeBetween(from,to).ToList();

            var resultdto = _mapper.Map<List<ResultDTO>>(results);

            return Ok(resultdto);
        }
    }
}
