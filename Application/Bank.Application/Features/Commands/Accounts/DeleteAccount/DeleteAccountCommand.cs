using MediatR;

namespace Bank.Application.Features.Commands.Accounts.DeleteAccount;

public class DeleteAccountCommand : IRequest
{
    public Guid Id { get; set; }
}