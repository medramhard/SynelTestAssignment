using AutoMapper;
using DataAccessLibrary.Models;
using SynelEmployees.Models;

namespace SynelEmployees.Mapping;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<EmployeeDisplayModel, EmployeeModel>().ReverseMap();
    }
}
