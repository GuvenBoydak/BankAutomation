using Bank.Application.DTOs.Token;
using Bank.Domain.Models;

namespace Bank.Application.Interfaces.Services;

public interface ITokenHelper
{
    AccessToken CreateToken(User user);
}