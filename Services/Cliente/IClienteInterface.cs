using BarbeariaMVC.Dto;
using BarbeariaMVC.Models;

namespace BarbeariaMVC.Services.Cliente
{
    public interface IClienteInterface
    {
        Task<ClienteModel> PostCliente(ClienteDto clienteDto, IFormFile foto);
        Task<List<ClienteModel>> GetClientes();
        Task<ClienteModel> GetClienteId(int id);

        Task<ClienteModel> UpdateCliente(ClienteModel cliente, IFormFile? foto);
        Task<ClienteModel> DeleteCliente(int id);

        Task<List<ClienteModel>> GetClientesFiltro(string? pesquisar);
    }
}
