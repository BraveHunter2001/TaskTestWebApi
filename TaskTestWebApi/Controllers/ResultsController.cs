using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskTestWebApi.Data.Repositories;
using TaskTestWebApi.Models;
using TaskTestWebApi.Services;

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
            SearchResultService searchResult = new SearchResultService(_resultRepo);
            var result = searchResult.Search(resultSearchModel);
            var resDto = _mapper.Map<List<ResultDTO>>(result.ToList());
            return resDto;
        }
    }
}
