using Bank.Application.Features.Commands.Transactions.CreateTransaction;
using Bank.Application.Features.Commands.Transactions.DeleteTransaction;
using Bank.Application.Features.Queries.Transactions.GetAllTransactionByRecipientAccountId;
using Bank.Application.Features.Queries.Transactions.GetAllTransactionByRecipientUserId;
using Bank.Application.Features.Queries.Transactions.GetAllTransactionBySenderAccountId;
using Bank.Application.Features.Queries.Transactions.GetAllTransactionBySenderUserId;
using Bank.Application.Features.Queries.Transactions.GetAllTransactions;
using Bank.Application.Features.Queries.Transactions.GetByIdTransaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionsController:ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<ActionResult<List<TransactionListDto>>> GetAllTransactions([FromQuery]GetAllTransactionQuery request)
    {
        return Ok( await _mediator.Send(request));
    }
    
    [HttpGet("{Id:guid}")]
    public async Task<ActionResult<TransactionDto>> GetByIdTransaction([FromRoute]GetByIdTransactionQuery request)
    {
        return Ok( await _mediator.Send(request));
    }
    
    [HttpPost]
    public async Task<ActionResult> AddTransaction([FromBody]CreateTransactionCommand request)
    {
        return Ok( await _mediator.Send(request));
    }
    
    [HttpDelete("{Id:guid}")]
    public async Task<ActionResult> DeleteTransaction([FromRoute]DeleteTransactionCommand request)
    {
        return Ok( await _mediator.Send(request));
    }
    
    [HttpGet("get-all-sender-account/{Id:guid}")]
    public async Task<ActionResult<List<TransactionListDto>>> GetAllTransactionBySenderAccountId([FromRoute]GetAllTransactionBySenderAccountIdQuery request)
    {
       return Ok( await _mediator.Send(request));
    }
    
    [HttpGet("get-all-recipient-account/{Id:guid}")]
    public async Task<ActionResult<List<TransactionListDto>>> GetAllTransactionByRecipientAccountId([FromRoute]GetAllTransactionByRecipientAccountIdQuery request)
    {
        return Ok( await _mediator.Send(request));
    }
    
    [HttpGet("get-all-sender-user/{Id:guid}")]
    public async Task<ActionResult<List<TransactionListDto>>> GetAllTransactionBySenderUserId([FromRoute]GetAllTransactionBySenderUserIdQuery request)
    {
        return Ok( await _mediator.Send(request));
    }
    
    [HttpGet("get-all-recipient-user/{Id:guid}")]
    public async Task<ActionResult<List<TransactionListDto>>> GetAllTransactionByRecipientUserId([FromRoute]GetAllTransactionByRecipientUserIdQuery request)
    {
        return Ok( await _mediator.Send(request));
    }
}