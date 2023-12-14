using AutoMapper;
using ExpenseTracker.BL.Models;
using DALCategory = ExpenseTracker.DAL.Models.Category;

namespace ExpenseTracker.BL.Automapper;

public class DalBlMappingProfile : Profile
{
    public DalBlMappingProfile()
    {
        CreateMap<Category, DALCategory>();
        CreateMap<DALCategory, Category>();
    }
}
