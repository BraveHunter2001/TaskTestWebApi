using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskTestWebApi.Data.Repositories;
using TaskTestWebApi.Models;
using IParser = TaskTestWebApi.Utility.Parser.IParser;

namespace TaskTestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IParser _parserValue;
        private readonly IRepository<Value> _valueRepo;
        private readonly IRepository<Result> _resultRepo;
        private readonly IMapper _mapper;
        
        public ValuesController(
            IParser parser,
            IRepository<Value> valueRepo,
            IRepository<Result> resultRepo,
            IMapper mapper)
        {
            _parserValue = parser;
            _valueRepo = valueRepo;
            _resultRepo = resultRepo;
            _mapper = mapper;
        }

        [HttpPost] 
        public IActionResult UploadFile(IFormFile file)
        {
            List<ValueDTO> valuesDto = new List<ValueDTO>();

            valuesDto = _parserValue.GetRecords<ValueDTO>(file).ToList();

            valuesDto.ForEach((valueDto) =>
            {
                Value val = _mapper.Map<Value>(valueDto);
                val.Namefile = file.FileName;
                _valueRepo.Add(val);
            });
            _valueRepo.Save();
            
            var res = CreateResultUtility.CalculateBySamples(valuesDto);
            Result result = _mapper.Map<Result>(res);
            result.NameFile = file.FileName;
            _resultRepo.Add(result);
            _resultRepo.Save();

            return Ok(res);
            
        }

       
    }
}
