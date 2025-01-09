using AutoMapper;
using Domain.DTO;
using Domain.Request;
using Domain.Response;
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
            _clientService = clientService;
            _mapper = mapper;
        }

        /// <summary>
        /// Método para crear un cliente.
        /// </summary>
        /// <param name="client">Información del cliente a crear</param>
        /// <returns>Información del cliente creado</returns>
        [HttpPost("Create")]
        public async Task<Client> CreateClient([FromBody] ClientRequest client)
            => await _clientService.CreateAsync(_mapper.Map<Client>(client));

        /// <summary>
        /// Método para modificar un cliente.
        /// </summary>
        /// <param name="client">Información de id del cliente e información a modificar.</param>
        /// <returns>Inormación modificada del cliente</returns>
        [HttpPatch("Update")]
        public async Task<Client> UpdateAsync([FromBody] UpdateClientRequest client)
            => await _clientService.UpdateAsync(client);

        /// <summary>
        /// Método para eliminar un cliente.
        /// </summary>
        /// <param name="client">Información de documento y tipo de documento para eliminar el cliente.</param>
        /// <returns>Mensaje de operación exitoso.</returns>
        [HttpPost("Delete")]
        public async Task<string> DeleteAsync([FromBody] DeleteClientRequest client)
           => await _clientService.DeleteAsync(client);

        /// <summary>
        /// Método para consultar todos los clientes registrados en base de datos.
        /// </summary>
        /// <returns>Listado de clientes.</returns>
        [HttpGet("GetAll")]
        public async Task<IEnumerable<Client>> GetAllAsync()
            => await _clientService.GetAllAsync();

        /// <summary>
        /// Método para filtrar el listado de clientes.
        /// </summary>
        /// <param name="filtersClient"> Información del filtro a aplicar.</param>
        /// <returns>Listado de clientes</returns>
        [HttpPost("Filters")]
        public async Task<IEnumerable<Client>> FilterDataClient([FromBody] FiltersClientRequest filtersClient)
            => await _clientService.FilterDataClient(filtersClient);

        /// <summary>
        /// Método para obtener las propiedades por las cuales se puede filtrar el listado de clientes
        /// </summary>
        /// <returns>listado de propiedades</returns>
        [HttpGet("PropertiesClient")]
        public IEnumerable<PropertiesClientResponse> PropertiesClient()
            => _clientService.PropertiesClient();

        [HttpGet("ClientFilterPhone")]
        public async Task<IEnumerable<ClientFilterPhoneResponse>> ClientFilterPhone()
            => await _clientService.ClientFilterPhone();

        [HttpGet("GetAddressAndFullNameClientAsync")]
        public async Task<IEnumerable<FilterAddressClientResponse>> GetAddressAndFullNameClientAsync()
            => await _clientService.GetAddressAndFullNameClientAsync();
    }
}
