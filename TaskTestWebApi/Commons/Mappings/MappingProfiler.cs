using AutoMapper;
using TaskTestWebApi.Models;

namespace TaskTestWebApi.Commons.Mappings
{
    public class MappingProfiler: Profile
    {
        public MappingProfiler() 
        {
            CreateMap<Value, ValueDTO>();
            CreateMap<ValueDTO, Value>();

            CreateMap<Result, ResultDTO>();
            CreateMap<ResultDTO, Result>();
        }

    }
}
