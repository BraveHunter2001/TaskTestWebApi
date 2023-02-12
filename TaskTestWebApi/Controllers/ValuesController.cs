using Microsoft.AspNetCore.Mvc;
using TaskTestWebApi.Models;
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
            List<ValueDTO> values = new List<ValueDTO>();

            values = _parserValue.GetRecords<ValueDTO>(file).ToList();

            var res = CreateResultUtility.CalculateBySamples(values);

            return Ok(res);
            
        }

       
    }
}
