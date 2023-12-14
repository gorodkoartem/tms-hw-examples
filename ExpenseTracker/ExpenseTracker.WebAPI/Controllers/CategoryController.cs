using AutoMapper;
using ExpenseTracker.BL.Services.Interfaces;
using ExpenseTracker.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.WebAPI.Controllers;

[Route("[controller]")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateCategory([FromBody] Category category)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var operationResult = await _categoryService.CreateCategoryAsync(_mapper.Map<BL.Models.Category>(category));
        if (!operationResult.Succeeded)
        {
            return BadRequest(operationResult.ErrorMessage);
        }

        // TODO replace an empty string with URI
        return Created("", _mapper.Map<Category>(operationResult.Data));
    }
}
