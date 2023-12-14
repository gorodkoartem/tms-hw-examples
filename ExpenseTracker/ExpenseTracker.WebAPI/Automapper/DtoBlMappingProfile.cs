using AutoMapper;
using ExpenseTracker.BL.Models;

namespace ExpenseTracker.WebAPI.Automapper;

public class DtoBlMappingProfile : Profile
{
    public DtoBlMappingProfile()
    {
        CreateMap<DTO.Category, Category>();
        CreateMap<Category, DTO.Category>();
    }
}
