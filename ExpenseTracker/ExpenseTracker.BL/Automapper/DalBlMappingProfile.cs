using AutoMapper;
using ExpenseTracker.BL.Models;
using DALCategory = ExpenseTracker.DAL.Models.Category;
using DALAccount = ExpenseTracker.DAL.Models.Account;

namespace ExpenseTracker.BL.Automapper;

public class DalBlMappingProfile : Profile
{
    public DalBlMappingProfile()
    {
        CreateMap<Category, DALCategory>();
        CreateMap<DALCategory, Category>();
        CreateMap<Account, DALAccount>();
        CreateMap<DALAccount, Account>();
    }
}
