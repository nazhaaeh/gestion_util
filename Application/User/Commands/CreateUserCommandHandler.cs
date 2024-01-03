using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Infrastrecture.Interfaces;
using Application.User.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, int>
{
    private readonly IUserRepository _userRepository; 

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
           Sexe = request.Sexe,
        };

        _userRepository.AddUserAndSave(user);

        _userRepository.Save();

        return user.IdUser;
    }

 
}
