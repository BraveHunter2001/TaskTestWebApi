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
        private readonly IRepository<Result> _resultRepo;
        private readonly IMapper _mapper;
        public ResultsController(IRepository<Result> repository, IMapper mapper)
        {
            _resultRepo = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("search/{namefile}")]
        public ActionResult<List<ResultDTO>> SearchByName(string namefile)
        {
            List<Result> results = _resultRepo.GetItems().Where(res => res.NameFile == namefile).ToList();

            var resultdto = _mapper.Map<List<ResultDTO>>(results);

            return Ok(resultdto);
        }

        [HttpGet]
        [Route("search/{datetime}")]
        public ActionResult<List<ResultDTO>> SearchByDatetime(DateTime datetime)
        {
            List<Result> results = _resultRepo.GetItems().Where(res => res.MinimalDate == datetime).ToList();

            var resultdto = _mapper.Map<List<ResultDTO>>(results);

            return Ok(resultdto);
        }

        [HttpGet]
        [Route("search/{averageindicator}")]
        public ActionResult<List<ResultDTO>> SearchByAverageInd(float averageindicator)
        {
            List<Result> results = _resultRepo.GetItems().Where(res => res.AverageIndicator == averageindicator).ToList();

            var resultdto = _mapper.Map<List<ResultDTO>>(results);

            return Ok(resultdto);
        }

        [HttpGet]
        [Route("search/{averageTime}")]
        public ActionResult<List<ResultDTO>> SearchByAverageTime(float averageTime)
        {
            List<Result> results = _resultRepo.GetItems().Where(res => res.AverageTime == averageTime).ToList();

            var resultdto = _mapper.Map<List<ResultDTO>>(results);

            return Ok(resultdto);
        }
    }
}
