using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskTestWebApi.Data.Repositories;
using TaskTestWebApi.Models;
using TaskTestWebApi.Services;
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

            if(valuesDto.Count < 0) {
                return BadRequest("There are no entries in the file.");
            }

            if(valuesDto.Count > 10000)
                return BadRequest("The file cannot contain more than 10,000 entries.");


            UploadValuesService uploadValues = new UploadValuesService(_mapper, _valueRepo, _resultRepo);
            uploadValues.UploadValues(valuesDto, file.FileName);

            return Ok();

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

