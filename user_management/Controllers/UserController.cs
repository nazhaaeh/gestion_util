using System;
using System.Net.Http;
using System.Threading.Tasks;
using Application.DTO;
using Application.User.Commands;
using Application.User.Query;
using AutoMapper;
using Infrastrecture.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polly;
using Polly.Retry;

namespace user_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly RetryPolicy _retryPolicy;

        public UserController(IMediator mediator, IUserRepository userRepository, IMapper mapper, RetryPolicy retryPolicy)
        {
            _mediator = mediator;
            this.userRepository = userRepository;
            this.mapper = mapper;
            _retryPolicy = retryPolicy;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest command)
        {
            var userId = await _mediator.Send(command);
            return Ok(userId);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            
            var result = await _retryPolicy.Execute(async () =>
            {
                // Appel à l'API distant
                var response = await CallApiAsync();
                response.EnsureSuccessStatusCode();

                // Traitement des données de la réponse
                var content = await response.Content.ReadAsStringAsync();
                var userDtos = mapper.Map<IEnumerable<UserDto>>(content);

                return userDtos;
            });

            return Ok(result);
        }

        private async Task<HttpResponseMessage> CallApiAsync()
        {
            // Utilisation de l'API JSONPlaceholder pour récupérer des utilisateurs fictifs
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");
            }
        }
    }
}
