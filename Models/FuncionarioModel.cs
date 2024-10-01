
namespace BarbeariaMVC.Models;
public class FuncionarioModel
{
    public int FuncionarioId { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }

    // Relacionamento: Funcionário pode realizar vários Atendimentos
    public ICollection<AtendimentoModel> Atendimentos { get; set; }
}
