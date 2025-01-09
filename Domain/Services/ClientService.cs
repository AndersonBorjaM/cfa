using Domain.DTO;
using Domain.Helpers;
using Domain.Repositories;
using Domain.Request;
using Domain.Response;
using Domain.Validations;

namespace Domain.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        public async Task<Client> CreateAsync(Client client)
        {
            ClientServiceValidation validationRules = new ClientServiceValidation();
            var resultValidation = validationRules.Validate(client);

            if (!resultValidation.IsValid)
                throw new ArgumentException(resultValidation.Errors.Select(x => x.ErrorMessage).Aggregate((current, next) => $"{current}, {next}"));

            if (await _clientRepository.GetByDocumentAndDocumentTypeAsync(client.Document, client.DocumentType.Replace(" ", "").ToUpper()) != null)
                throw new ArgumentException($"El cliente con el documento {client.Document} ya esta registrado en base de datos.");

            var response = await _clientRepository.CreateAsync(client);

            return response;
        }

        public async Task<Client> UpdateAsync(UpdateClientRequest updateClient)
        {
            var client = await _clientRepository.GetByIdAsync(updateClient.ClientId);

            if (client == null)
                throw new ArgumentNullException("El cliente no existe.");

            client.DateOfBirth = updateClient.DateOfBirth;
            client.DocumentType = updateClient.DocumentType;
            client.Document = updateClient.Document;

            ClientServiceValidation validationRules = new ClientServiceValidation();
            var resultValidation = validationRules.Validate(client);

            if (!resultValidation.IsValid)
                throw new ArgumentException(resultValidation.Errors.Select(x => x.ErrorMessage).Aggregate((current, next) => $"{current}, {next}"));

            return await _clientRepository.UpdateAsync(client);
        }

        public async Task<string> DeleteAsync(DeleteClientRequest deleteClient)
        {
            var client = await _clientRepository.GetByDocumentAndDocumentTypeAsync(deleteClient.Document, deleteClient.DocumentType);

            if (client == null)
                throw new ArgumentNullException("El cliente no existe.");

            if (await _clientRepository.DeleteAsync(client))
                return "El cliente se elimino correctamente.";
            else
                return "No se pudo eliminar el cliente.";
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
            => await _clientRepository.GetAllAsync();

        public async Task<IEnumerable<Client>> FilterDataClient(FiltersClientRequest filtersClient)
            => (await _clientRepository.GetAllAsync()).ApplyFilter(filtersClient);

        public IEnumerable<PropertiesClientResponse> PropertiesClient()
            => typeof(Client).GetProperties()
            .Where(x => !x.Name.Equals("Addresses") && !x.Name.Equals("Phones"))
            .Select(x => new PropertiesClientResponse
            {
                PropertyName = x.Name,
                PropertyType = x.PropertyType.Name
            });

        public async Task<IEnumerable<ClientFilterPhoneResponse>> ClientFilterPhone()
            => (await _clientRepository.GetAllAsync()).Where(x => x.Phones.Count() > 1)
            .Select(x => new ClientFilterPhoneResponse
            {
                FullName = x.FullName,
                TotalPhones = x.Phones.Count()
            });

        public async Task<IEnumerable<FilterAddressClientResponse>> GetAddressAndFullNameClientAsync()
            => await _clientRepository.GetAddressAndFullNameClientAsync();
    }
}
