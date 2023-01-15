using AutoMapper;
using Bank.Application.Interfaces.Repositories;
using Bank.Application.Interfaces.UnitOfWork;
using Bank.Domain.Models;
using MediatR;

namespace Bank.Application.Features.Commands.Transactions.CreateTransaction;

public class CreateTransactionCommandHandler : AsyncRequestHandler<CreateTransactionCommand>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork,
        IMapper mapper, IAccountRepository accountRepository)
    {
        _transactionRepository = transactionRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _accountRepository = accountRepository;
    }

    protected override async Task Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = _mapper.Map<CreateTransactionCommand, Transaction>(request);

        var senderAccount = await _accountRepository.GetById(request.SenderAccountId);
        if (senderAccount == null)
            throw new InvalidOperationException("Sender Account Not Found ");
        if (senderAccount.IsBlocked)
            throw new InvalidOperationException("Sender Account is Blocked");

        var recipientAccount = await _accountRepository.GetById(request.RecipientAccountId);
        if (recipientAccount == null)
            throw new InvalidOperationException("Recipient Account Not Found ");
        if (recipientAccount.IsBlocked)
            throw new InvalidOperationException("Recipient Account is Blocked");

        SenderBalanceReduction(request.SenderAccountId, request.Amount);
        RecipientBalanceReduction(request.RecipientAccountId, request.Amount);

        await _transactionRepository.AddAsync(transaction);
        await _unitOfWork.SaveChangesAsync();
    }

    private async void SenderBalanceReduction(Guid senderId, decimal balance)
    {
        var senderAccount = await _accountRepository.GetById(senderId);

        if (senderAccount.Balance < balance)
            throw new InvalidOperationException("Sender Account balance insufficient");

        senderAccount.Balance -= balance;
        senderAccount.LastActivty = DateTime.Now;

        _accountRepository.Update(senderAccount);
    }

    private async void RecipientBalanceReduction(Guid recipientId, decimal balance)
    {
        var recipientAccount = await _accountRepository.GetById(recipientId);
        recipientAccount.Balance += balance;
        recipientAccount.LastActivty = DateTime.Now;

        _accountRepository.Update(recipientAccount);
    }
}