using Microsoft.AspNetCore.Mvc;
using Models;
using IParser = TaskTestWebApi.Utility.Parser.IParser;

namespace TaskTestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IParser _parserValue;

        public ValuesController(IParser parserValue)
        {
            _parserValue= parserValue;
        }

        [HttpPost] 
        public IActionResult UploadFile(IFormFile file)
        {
            List<Value> values = new List<Value>();

            values = _parserValue.GetRecords<Value>(file).ToList();

            var res = CreateResultUtility.CalculateBySamples(file.FileName, values);

            return Ok(res);
            
        }

       
    }
}
