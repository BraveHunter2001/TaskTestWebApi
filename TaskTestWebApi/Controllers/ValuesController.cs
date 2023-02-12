﻿using AutoMapper;
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
            if (file == null)
            {
                return BadRequest("File was empty");
            }

            List<ValueDTO> valuesDto = _parserValue.GetRecords<ValueDTO>(file).ToList();
            ResultDTO resultsDto = CreateResultUtility.CalculateBySamples(valuesDto);

            List<Value> values = _mapper.Map<List<Value>>(valuesDto);
            values.ForEach(value => { value.Namefile = file.FileName; });

            Result result = _mapper.Map<Result>(resultsDto);
            result.NameFile = file.FileName;


            if (_resultRepo.GetItems().Any(result => result.NameFile == file.FileName))
            {
                var valuesToDelete = _valueRepo.GetItems().Where(value => value.Namefile == file.FileName);
                foreach (var value in valuesToDelete)
                {
                    _valueRepo.Delete(value);
                }

                var resultToDelete = _resultRepo.GetItems().FirstOrDefault(res=> res.NameFile == file.FileName);
                _resultRepo.Delete(resultToDelete);
            }

            values.ForEach(values => { _resultRepo.Add(result); });
            _resultRepo.Add(result);


            _valueRepo.Save();
            _resultRepo.Save();
            return Ok(resultsDto);

        }


    }
}
