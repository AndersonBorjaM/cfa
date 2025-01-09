using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Request;
using Domain.Response;

namespace Domain.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> CreateAsync(Client client);
        Task<Client> UpdateAsync(UpdateClientRequest updateClient);
        Task<string> DeleteAsync(DeleteClientRequest deleteClient);
        Task<IEnumerable<Client>> FilterDataClient(FiltersClientRequest filtersClient);
        IEnumerable<PropertiesClientResponse> PropertiesClient();
        Task<IEnumerable<ClientFilterPhoneResponse>> ClientFilterPhone();
        Task<IEnumerable<FilterAddressClientResponse>> GetAddressAndFullNameClientAsync();
    }
}
