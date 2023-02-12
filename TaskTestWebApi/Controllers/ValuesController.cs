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
        
        public ValuesController(IParser parser, IRepository<Value> valueRepo, IRepository<Result> resultRepo)
        {
            _parserValue = parser;
            _valueRepo = valueRepo;
            _resultRepo = resultRepo;
        }

        [HttpPost] 
        public IActionResult UploadFile(IFormFile file)
        {
            List<ValueDTO> values = new List<ValueDTO>();

            values = _parserValue.GetRecords<ValueDTO>(file).ToList();
            var res = CreateResultUtility.CalculateBySamples(values);


            return Ok(res);
            
        }

       
    }
}
