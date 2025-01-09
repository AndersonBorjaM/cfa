using AutoMapper;
using Domain.DTO;
using Domain.Request;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {

            this._clientService = clientService;
            this._mapper = mapper;
        }

        [HttpPost("Create")]
        public async Task<Client> CreateClient(ClientRequest client)
            => await _clientService.CreateAsync(_mapper.Map<Client>(client));


        [HttpGet("GetAll")]
        public async Task<IEnumerable<Client>> GetAllAsync()
            => await _clientService.GetAllAsync();
    }
}
