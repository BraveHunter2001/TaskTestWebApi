using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskTestWebApi.Data.Repositories;
using TaskTestWebApi.Models;
using IParser = TaskTestWebApi.Utility.Parser.IParser;

namespace TaskTestWebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IParser _parserValue;
        private readonly IValueRepository _valueRepo;
        private readonly IResultRepository _resultRepo;
        private readonly IMapper _mapper;

        public ValuesController(
            IParser parser,
            IValueRepository valueRepo,
            IResultRepository resultRepo,
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
            if (file == null)
            {
                return BadRequest("File was empty");
            }

            List<ValueDTO> valuesDto = _parserValue.GetRecords<ValueDTO>(file).ToList();
            ResultDTO resultsDto = CreateResultUtility.CalculateBySamples(valuesDto);
            resultsDto.NameFile= file.FileName;

            List<Value> values = _mapper.Map<List<Value>>(valuesDto);
            values.ForEach(value => { value.Namefile = file.FileName; });

            Result result = _mapper.Map<Result>(resultsDto);
            result.NameFile = file.FileName;

            var resultByName = _resultRepo.GetItemByNameFile(file.FileName);

            if (resultByName != null)
            {
                var valuesToDelete = _valueRepo.GetItemsByNameFile(file.FileName);
                foreach (var value in valuesToDelete)
                {
                    _valueRepo.Delete(value);
                }

                _resultRepo.Delete(resultByName);
            }

            values.ForEach(values => { _valueRepo.Add(values); });
            _resultRepo.Add(result);


            _valueRepo.Save();
            _resultRepo.Save();
            return Ok(resultsDto);

        }

        [HttpGet]
        [Route("{stringName}")]
        public ActionResult<List<ValueDTO>> GetValuesByName(string stringName)
        {
            List<Value> results = _valueRepo.GetItems().Where(res => res.Namefile == stringName).ToList();

            var valuedto = _mapper.Map<List<ValueDTO>>(results);

            return Ok(valuedto);
        }
    }
}

