using Bank.Application.Interfaces.Repositories;
using Bank.Application.Interfaces.UnitOfWork;
using MediatR;

namespace Bank.Application.Features.Commands.Transactions.DeleteTransaction;

public class DeleteTransactionCommandHandler : AsyncRequestHandler<DeleteTransactionCommand>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTransactionCommandHandler(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork)
    {
        _transactionRepository = transactionRepository;
        _unitOfWork = unitOfWork;
    }

    protected override async Task Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
    {
        await _transactionRepository.DeleteAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}