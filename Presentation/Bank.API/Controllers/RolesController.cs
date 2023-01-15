using Bank.Application.Features.Commands.Roles.CreateRole;
using Bank.Application.Features.Commands.Roles.DeleteRole;
using Bank.Application.Features.Commands.Roles.UpdateRole;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers;

[Authorize("Admin")]
[Route("api/[controller]")]
[ApiController]
public class RolesController:ControllerBase
{
    private readonly IMediator _mediator;

    public RolesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<ActionResult> AddRole([FromBody] CreateRoleCommand request)
    {
        return Ok(await _mediator.Send(request));
    }
    
    [HttpPut]
    public async Task<ActionResult> UpdateRole([FromBody] UpdateRoleCommand request)
    {
        return Ok(await _mediator.Send(request));
    }
    
    [HttpDelete("{Id:guid}")]
    public async Task<ActionResult> DeleteRole([FromRoute] DeleteRoleCommand request)
    {
        return Ok(await _mediator.Send(request));
    }
}