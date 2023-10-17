using AutoMapper;
using CRUD_WebApi_Net6.Entities;

namespace CRUD_WebApi_Net6.Models;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<CreateEmpRequest, Employee>();
        CreateMap<UpdateEmpRequest, Employee>();
    }
}