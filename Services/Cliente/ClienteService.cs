using BarbeariaMVC.Data;
using BarbeariaMVC.Dto;
using BarbeariaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BarbeariaMVC.Services.Cliente
{
    public class ClienteService : IClienteInterface
    {
        private readonly AppDbContext _context;
        private readonly string _sistema;

        public ClienteService(AppDbContext context, IWebHostEnvironment sistema)
        {
            _context = context;
            _sistema = sistema.WebRootPath;
        }

        public string gerarCaminhoArquivo(IFormFile foto)
        {
            var codigoUnico =  Guid.NewGuid().ToString();
            var nomeCaminhoFoto = foto.FileName.Replace(" ","").ToLower()+ codigoUnico+".png";

            var caminhoSalvarFoto = _sistema + "\\imagem\\";

            if (!Directory.Exists(caminhoSalvarFoto))
            {
                Directory.CreateDirectory(caminhoSalvarFoto);
            }
            using (var stream = File.Create(caminhoSalvarFoto + nomeCaminhoFoto))
            {
                foto.CopyToAsync(stream).Wait();
            }

                return nomeCaminhoFoto;
        }



        public async Task<List<ClienteModel>> GetClientes()
        {
            try
            {
                return await _context.Clientes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);   
            }
        }

        public async Task<ClienteModel> GetClienteId(int id)
        {
            try
            {

                return await _context.Clientes.FirstOrDefaultAsync(cliente => cliente.ClienteId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteModel> PostCliente(ClienteDto clienteDto, IFormFile foto)
        {
            try
            {
                var nomeCaminhoFoto = gerarCaminhoArquivo(foto);
                var cliente = new ClienteModel
                {
                    Nome = clienteDto.Nome,
                    Telefone = clienteDto.Telefone,
                    Email = clienteDto.Email,
                    Foto = nomeCaminhoFoto
                };

                _context.Add(cliente);
                await _context.SaveChangesAsync();

                return cliente;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<ClienteModel> UpdateCliente(ClienteModel cliente, IFormFile? foto)
        {
            try
            {
                var clienteBanco = await _context.Clientes.FirstOrDefaultAsync(clienteBD => clienteBD.ClienteId == cliente.ClienteId);

                if (clienteBanco == null)
                {
                    throw new Exception("Cliente não encontrado.");
                }

                // Lógica da foto
                var nomeCaminhoFoto = "";

                if (foto != null)
                {
                    string caminhoFotoExistente = _sistema + "\\imagem\\" + clienteBanco.Foto;

                    if (File.Exists(caminhoFotoExistente))
                    {
                        File.Delete(caminhoFotoExistente);
                    }

                    nomeCaminhoFoto = gerarCaminhoArquivo(foto);
                }

                // Atualizando os dados
                clienteBanco.Nome = cliente.Nome;
                clienteBanco.Email = cliente.Email;
                clienteBanco.Telefone = cliente.Telefone;

                if (!string.IsNullOrEmpty(nomeCaminhoFoto))
                {
                    clienteBanco.Foto = nomeCaminhoFoto;
                }
                else
                {
                    clienteBanco.Foto = cliente.Foto;
                }

                _context.Update(clienteBanco);
                await _context.SaveChangesAsync();

                return cliente;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteModel> DeleteCliente(int id)
        {
  
                try
                {
                    var cliente = await _context.Clientes.FirstOrDefaultAsync(
                        clienteBanco => clienteBanco.ClienteId == id);
                    _context.Remove(cliente);
                    await _context.SaveChangesAsync();
                    return cliente;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        public async Task<List<ClienteModel>> GetClientesFiltro(string? pesquisar)
        {
            try
            {
                var clientes = await _context.Clientes.Where(clienteBanco => clienteBanco.Nome.Contains(pesquisar)).ToListAsync();
                return clientes;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
