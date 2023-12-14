using ExpenseTracker.BL.Models;

namespace ExpenseTracker.BL.Services.Interfaces;

public interface ICategoryService
{
    Task<ServiceDataResponse<Category>> CreateCategoryAsync(Category category);
    Task<ServiceDataResponse<IEnumerable<Category>>> GetCategoriesAsync();
    Task<ServiceDataResponse<Category>> GetCategoryByIdAsync(Guid categoryId);
    Task<ServiceDataResponse<Category>> UpdateCategoryAsync(Category category);
    Task<ServiceResponse> DeleteCategoryAsync(Guid categoryId);
}
