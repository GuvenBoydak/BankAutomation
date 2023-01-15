using AutoMapper;
using Bank.Application.Features.Queries.Transactions.GetAllTransactions;
using Bank.Application.Interfaces.Repositories;
using Bank.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Features.Queries.Transactions.GetAllTransactionByRecipientAccountId;

public class
    GetAllTransactionByRecipientAccountIdQueryHandler : IRequestHandler<GetAllTransactionByRecipientAccountIdQuery,
        List<TransactionListDto>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public GetAllTransactionByRecipientAccountIdQueryHandler(ITransactionRepository transactionRepository,
        IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }

    public async Task<List<TransactionListDto>> Handle(GetAllTransactionByRecipientAccountIdQuery request,
        CancellationToken cancellationToken)
    {
        var transactions = await _transactionRepository.Where(x => x.RecipientAccountId == request.RecipientAccountId)
            .ToListAsync();

        return _mapper.Map<List<Transaction>, List<TransactionListDto>>(transactions);
    }
}