using AutoMapper;
using Bank.Application.Features.Commands.Accounts.CreateAccount;
using Bank.Application.Features.Commands.Accounts.UpdateAccount;
using Bank.Application.Features.Commands.Roles.CreateRole;
using Bank.Application.Features.Commands.Roles.UpdateRole;
using Bank.Application.Features.Commands.Transactions.CreateTransaction;
using Bank.Application.Features.Commands.Users.UpdateUser;
using Bank.Application.Features.Queries.Users.GetAllUsers;
using Bank.Application.Features.Queries.Users.GetByIdUser;
using Bank.Domain.Models;

namespace Bank.Application.Mapping;

public class MapProfile:Profile
{
    public MapProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserListDto>().ReverseMap();
        CreateMap<User,UpdateUserCommand>().ReverseMap();

        CreateMap<Transaction, CreateTransactionCommand>().ReverseMap();

        CreateMap<Account, CreateAccountCommand>().ReverseMap();
        CreateMap<Account, UpdateAccountCommand>().ReverseMap();
        
        CreateMap<Role, CreateRoleCommand>().ReverseMap();
        CreateMap<Role, UpdateRoleCommand>().ReverseMap();
        
        

    }
}