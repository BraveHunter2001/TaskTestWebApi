using AutoMapper;
using TaskTestWebApi.Data.Repositories;
using TaskTestWebApi.Models;
using TaskTestWebApi.Utility.Parser;

namespace TaskTestWebApi.Services;
public class UploadValuesService
{
    private readonly IMapper _mapper;
    private readonly IValueRepository _valueRepo;
    private readonly IResultRepository _resultRepo;
  
    public UploadValuesService(IMapper mapper, IValueRepository valueRepo, IResultRepository resultRepo)
    {
        _mapper = mapper;
        _valueRepo = valueRepo;
        _resultRepo = resultRepo;
    }

    public void UploadValues(List<ValueDTO> valuesDto, string fileName)
    {
       
        ResultDTO resultsDto = CreateResultUtility.CalculateBySamples(valuesDto);
        resultsDto.NameFile = fileName;

        
        var resultByName = _resultRepo.GetItemByNameFile(fileName);
        if (resultByName != null)
        {
            var valuesToDelete = _valueRepo.GetItemsByNameFile(fileName);
            foreach (var value in valuesToDelete)
            {
                _valueRepo.Delete(value);
            }
            _resultRepo.Delete(resultByName);
        }



        // Mapping 
        Result result = _mapper.Map<Result>(resultsDto);
        result.NameFile = fileName;
        List<Value> values = _mapper.Map<List<Value>>(valuesDto);

        
       // put in db
        values.ForEach(value => {
            value.Namefile = fileName;
            _valueRepo.Add(value); 
        });

        _resultRepo.Add(result);


        _valueRepo.Save();
        _resultRepo.Save();
    }
}