using Application.DTO;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Infrastrecture.Interfaces;
using Infrastrecture.Repository;

namespace Application.User.Query
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, IEnumerable<UserDto>>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            var users = userRepository.GetAll(); 
            var userDtos = mapper.Map<IEnumerable<UserDto>>(users);
            return userDtos;
        }
    }
}
