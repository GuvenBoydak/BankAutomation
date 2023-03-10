using System.Text.Json.Serialization;
using MediatR;

namespace Bank.Application.Features.Commands.Accounts.CreateAccount;

public class CreateAccountCommand : IRequest
{
    public string AccountNo { get; set; }
    public decimal Balance { get; set; }
    public DateTime LastActivty { get; set; }
    public bool IsBlocked { get; set; }
    [JsonIgnore]
    public Guid UserId { get; set; }
}