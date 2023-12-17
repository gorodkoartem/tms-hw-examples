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

    [HttpPost("create")]
    public async Task<IActionResult> CreateCategory([FromBody] Category category)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var operationResult = await _categoryService.CreateCategoryAsync(_mapper.Map<BL.Models.Category>(category));
        if (!operationResult.IsSucceeded)
        {
            return BadRequest(operationResult.ErrorMessage);
        }

        var uri = Url.Action(nameof(GetCategory), new { id = operationResult?.Data?.Id });
        return Created(uri ?? string.Empty, _mapper.Map<Category>(operationResult?.Data));
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> GetCategory(Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var operationResult = await _categoryService.GetCategoryByIdAsync(id);
        if (!operationResult.IsSucceeded)
        {
            return BadRequest(operationResult.ErrorMessage);
        }

        return Ok(_mapper.Map<Category>(operationResult.Data));
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetCategories()
    {
        var operationResult = await _categoryService.GetCategoriesAsync();
        if (!operationResult.IsSucceeded)
        {
            return BadRequest(operationResult.ErrorMessage);
        }

        return Ok(_mapper.Map<IEnumerable<Category>>(operationResult.Data));
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateCategory([FromBody] Category category)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var operationResult = await _categoryService.UpdateCategoryAsync(_mapper.Map<BL.Models.Category>(category));
        if (!operationResult.IsSucceeded)
        {
            return BadRequest(operationResult.ErrorMessage);
        }

        var updatedCategory = _mapper.Map<Category>(operationResult.Data);
        var uri = Url.Action(nameof(GetCategory), new { id = operationResult?.Data?.Id });
        return Accepted(uri, updatedCategory);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var operationResult = await _categoryService.DeleteCategoryAsync(id);
        if (!operationResult.IsSucceeded)
        {
            return BadRequest(operationResult.ErrorMessage);
        }

        return Ok();
    }
}
