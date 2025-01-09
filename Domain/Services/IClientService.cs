using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Request;

namespace Domain.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> CreateAsync(Client client);
        Task<List<Client>> FilterDataClient(FiltersClientRequest filtersClient);
    }
}
