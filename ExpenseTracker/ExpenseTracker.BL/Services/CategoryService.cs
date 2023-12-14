using AutoMapper;
using ExpenseTracker.BL.Models;
using ExpenseTracker.BL.Services.Interfaces;
using ExpenseTracker.DAL;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.BL.Services;

public class CategoryService : ICategoryService
{
    private readonly ExpenseTrackerDbContext _dbContext;
    private readonly IMapper _mapper;

    public CategoryService(ExpenseTrackerDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public ServiceDataResponse<Guid> CreateCategory(Category category)
    {
        if(category == null)
        {
            return new ServiceDataResponse<Guid>
            {
                ErrorMessage = "Data cannot be null",
                Succeeded = false
            };
        }

        if(_dbContext.Categories.Any(c => c.Name == category.Name))
        {
            return new ServiceDataResponse<Guid>
            {
                ErrorMessage = "Category with this name already exists",
                Succeeded = false
            };
        }

        var categoryId = Guid.NewGuid();
        var dalCategory = _mapper.Map<DAL.Models.Category>(category);
        dalCategory.Id = categoryId;

        _dbContext.Categories.Add(dalCategory);
        _dbContext.SaveChanges();

        return new ServiceDataResponse<Guid>
        {
            Succeeded = true,
            Data = categoryId,
        };
    }

    public async Task<ServiceDataResponse<Category>> CreateCategoryAsync(Category category)
    {
        if (category == null)
        {
            return new ServiceDataResponse<Category> { Succeeded = false, ErrorMessage = "Data cannot be null" };
        }

        if (await _dbContext.Categories.AnyAsync(c => c.Name == category.Name))
        {
            return new ServiceDataResponse<Category> { Succeeded = false, ErrorMessage = "Category with this name already exists" };
        }

        category.Id = Guid.NewGuid();
        var dalCategory = _mapper.Map<DAL.Models.Category>(category);

        _dbContext.Categories.Add(dalCategory);
        await _dbContext.SaveChangesAsync();

        return new ServiceDataResponse<Category>
        {
            Succeeded = true,
            Data = category,
        };
    }

    public async Task<ServiceResponse> DeleteCategoryAsync(Guid categoryId)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(category => category.Id == categoryId);
        if(category == null)
        {
            return new ServiceResponse { Succeeded = false, ErrorMessage = "Category doesn't exist" };
        }

        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync();
        return new ServiceResponse { Succeeded = true };
    }

    public Task<ServiceDataResponse<IEnumerable<Category>>> GetCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceDataResponse<Category>> GetCategoryByIdAsync(Guid categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceDataResponse<Category>> UpdateCategoryAsync(Category category)
    {
        throw new NotImplementedException();
    }
}
