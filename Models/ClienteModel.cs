
namespace BarbeariaMVC.Models;

public class ClienteModel
{
    public int ClienteId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;

    public string? Foto {  get; set; } = string.Empty;


    // Relacionamentos
    public ICollection<AtendimentoModel>? Atendimentos { get; set; }

}

