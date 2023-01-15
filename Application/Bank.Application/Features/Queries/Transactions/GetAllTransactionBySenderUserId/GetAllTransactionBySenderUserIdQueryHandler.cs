using AutoMapper;
using Bank.Application.Features.Queries.Transactions.GetAllTransactions;
using Bank.Application.Interfaces.Repositories;
using Bank.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Features.Queries.Transactions.GetAllTransactionBySenderUserId;

public class
    GetAllTransactionBySenderUserIdQueryHandler : IRequestHandler<GetAllTransactionBySenderUserIdQuery,
        List<TransactionListDto>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public GetAllTransactionBySenderUserIdQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }

    public async Task<List<TransactionListDto>> Handle(GetAllTransactionBySenderUserIdQuery request,
        CancellationToken cancellationToken)
    {
        var transactions = await _transactionRepository.Where(x => x.SenderUserId == request.SenderUserId)
            .ToListAsync();

        return _mapper.Map<List<Transaction>, List<TransactionListDto>>(transactions);
    }
}