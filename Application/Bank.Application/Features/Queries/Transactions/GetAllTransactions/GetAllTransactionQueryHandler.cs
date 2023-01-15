using AutoMapper;
using Bank.Application.Interfaces.Repositories;
using Bank.Domain.Models;
using MediatR;

namespace Bank.Application.Features.Queries.Transactions.GetAllTransactions;

public class GetAllTransactionQueryHandler:IRequestHandler<GetAllTransactionQuery,List<TransactionListDto>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public GetAllTransactionQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }

    public async Task<List<TransactionListDto>> Handle(GetAllTransactionQuery request, CancellationToken cancellationToken)
    {
        var transactions = await _transactionRepository.GetAllAsync();

        return _mapper.Map<List<Transaction>, List<TransactionListDto>>(transactions);
    }
}