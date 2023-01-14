using Bank.Application.Helper;
using Bank.Application.Interfaces.Repositories;
using Bank.Application.Interfaces.UnitOfWork;
using Bank.Domain.Models;
using MediatR;

namespace Bank.Application.Features.Commands.Users.RegisterUser;

public class RegisterUserCommandHandler : AsyncRequestHandler<RegisterUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    protected override async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var userEmail = await _userRepository.GetByEmailAsync(request.Email);

        if (userEmail != null)
            throw new InvalidOperationException($"{request.Email} User already exist");

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

        var user = new User()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Phone = request.Phone,
            Email = request.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        await _userRepository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();
    }
}