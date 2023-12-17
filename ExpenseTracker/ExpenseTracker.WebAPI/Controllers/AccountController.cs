using AutoMapper;
using ExpenseTracker.BL.Services.Interfaces;
using ExpenseTracker.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.WebAPI.Controllers;

[Route("[controller]")]
public class AccountController : Controller
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public AccountController(IAccountService accountService, IMapper mapper)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAccount([FromBody] Account account)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var operationResult = await _accountService.CreateAccountAsync(_mapper.Map<BL.Models.Account>(account));
        if (!operationResult.IsSucceeded)
        {
            return BadRequest(operationResult.ErrorMessage);
        }

        var uri = Url.Action(nameof(GetAccount), new { id = operationResult?.Data?.Id });
        return Created(uri ?? string.Empty, _mapper.Map<Account>(operationResult?.Data));
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> GetAccount(Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var operationResult = await _accountService.GetAccountByIdAsync(id);
        if (!operationResult.IsSucceeded)
        {
            return BadRequest(operationResult.ErrorMessage);
        }

        return Ok(_mapper.Map<Account>(operationResult.Data));
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetCategories()
    {
        var operationResult = await _accountService.GetAccountsAsync();
        if (!operationResult.IsSucceeded)
        {
            return BadRequest(operationResult.ErrorMessage);
        }

        return Ok(_mapper.Map<IEnumerable<Account>>(operationResult.Data));
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAccount([FromBody] Account account)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var operationResult = await _accountService.UpdateAccountAsync(_mapper.Map<BL.Models.Account>(account));
        if (!operationResult.IsSucceeded)
        {
            return BadRequest(operationResult.ErrorMessage);
        }

        var updatedAccount = _mapper.Map<Account>(operationResult.Data);
        var uri = Url.Action(nameof(GetAccount), new { id = operationResult?.Data?.Id });
        return Accepted(uri, updatedAccount);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteAccount(Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var operationResult = await _accountService.DeleteAccountAsync(id);
        if (!operationResult.IsSucceeded)
        {
            return BadRequest(operationResult.ErrorMessage);
        }

        return Ok();
    }
}
