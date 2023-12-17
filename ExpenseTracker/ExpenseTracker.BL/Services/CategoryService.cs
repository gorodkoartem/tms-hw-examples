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

    public async Task<ServiceDataResponse<Category>> CreateCategoryAsync(Category category)
    {
        if (category == null)
        {
            return ServiceDataResponse<Category>.Failed("Data cannot be null");
        }

        if (await _dbContext.Categories.AnyAsync(c => c.Name == category.Name))
        {
            return ServiceDataResponse<Category>.Failed("Category with this name already exists");
        }

        category.Id = Guid.NewGuid();
        var dalCategory = _mapper.Map<DAL.Models.Category>(category);

        _dbContext.Categories.Add(dalCategory);
        await _dbContext.SaveChangesAsync();

        return ServiceDataResponse<Category>.Succeeded(category);
    }

    public async Task<ServiceResponse> DeleteCategoryAsync(Guid categoryId)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(category => category.Id == categoryId);
        if(category == null)
        {
            return ServiceResponse.Failed("Category doesn't exist");
        }

        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync();
        return ServiceResponse.Succeeded();
    }

    public async Task<ServiceDataResponse<IEnumerable<Category>>> GetCategoriesAsync()
    {
        var categories = await _dbContext.Categories.ToListAsync();
        return ServiceDataResponse<IEnumerable<Category>>.Succeeded(_mapper.Map<IEnumerable<Category>>(categories));
    }

    public async Task<ServiceDataResponse<Category>> GetCategoryByIdAsync(Guid categoryId)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(category => category.Id == categoryId);
        if (category == null)
        {
            return ServiceDataResponse<Category>.Failed("Category doesn't exist");
        }

        return ServiceDataResponse<Category>.Succeeded(_mapper.Map<Category>(category));
    }

    public async Task<ServiceDataResponse<Category>> UpdateCategoryAsync(Category category)
    {
        if (category == null)
        {
            return ServiceDataResponse<Category>.Failed("Data cannot be null");
        }

        var dbCategory = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
        if (dbCategory == null)
        {
            return ServiceDataResponse<Category>.Failed("Category doesn't exist");
        }

        if (await _dbContext.Categories.AnyAsync(c => c.Name == category.Name))
        {
            return ServiceDataResponse<Category>.Failed("Category with this name already exists");
        }

        dbCategory.Name = category.Name;
        dbCategory.Description = category.Description;
        await _dbContext.SaveChangesAsync();

        return ServiceDataResponse<Category>.Succeeded(category);
    }
}
