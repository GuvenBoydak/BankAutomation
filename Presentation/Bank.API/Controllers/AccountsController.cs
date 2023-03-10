using System.Security.Claims;
using Bank.Application.Features.Commands.Accounts.CreateAccount;
using Bank.Application.Features.Commands.Accounts.DeleteAccount;
using Bank.Application.Features.Commands.Accounts.UpdateAccount;
using Bank.Application.Features.Queries.Accounts.GetAllAccounts;
using Bank.Application.Features.Queries.Accounts.GetByIdAccount;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AccountsController:ControllerBase
{
    private readonly IMediator _mediator;

    public AccountsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<AccountListDto>>> GetAllAccount([FromQuery]GetAllAccountQuery request)
    {
        return Ok(await _mediator.Send(request));
    }
    
    [HttpGet("{Id:guid}")]
    public async Task<ActionResult<AccountDto>> GetByIdAccount([FromRoute] GetByIdAccountQuery request)
    {
        return Ok(await _mediator.Send(request));
    }
    
    [HttpPost]
    public async Task<ActionResult> AddAccount([FromBody] CreateAccountCommand request)
    {
        request.UserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
        return Ok(await _mediator.Send(request));
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task<ActionResult> UpdateAccount([FromBody] UpdateAccountCommand request)
    {
        return Ok(await _mediator.Send(request));
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("{Id:guid}")]
    public async Task<ActionResult> DeleteAccount([FromRoute] DeleteAccountCommand request)
    {
        return Ok(await _mediator.Send(request));
    }
}