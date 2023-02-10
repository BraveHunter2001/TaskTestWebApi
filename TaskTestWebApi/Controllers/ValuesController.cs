using CsvHelper;
using CsvHelper.TypeConversion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Models;
using System.Globalization;

namespace TaskTestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpPost] 
        public IActionResult UploadFile(IFormFile file)
        {
            List<Value> values = new List<Value>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
                {
                
                    values = csvReader.GetRecords<Value>().ToList();
                }
            }

            return Ok(values);
            
        }

       
    }
}
