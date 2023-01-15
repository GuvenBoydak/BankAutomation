using AutoMapper;
using Bank.Application.Interfaces.Repositories;
using Bank.Domain.Models;
using MediatR;

namespace Bank.Application.Features.Queries.Transactions.GetByIdTransaction;

public class GetByIdTransactionQueryHandler : IRequestHandler<GetByIdTransactionQuery, TransactionDto>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public GetByIdTransactionQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }

    public async Task<TransactionDto> Handle(GetByIdTransactionQuery request, CancellationToken cancellationToken)
    {
        var transaction = await _transactionRepository.GetById(request.Id);

        return _mapper.Map<Transaction, TransactionDto>(transaction);
    }
}