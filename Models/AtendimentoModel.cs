
namespace BarbeariaMVC.Models;

public class AtendimentoModel
{
    public int AtendimentoId { get; set; }
    public int ClienteId { get; set; }
    public int FuncionarioId { get; set; }
    public DateTime DataHora { get; set; }
    public string Observacoes { get; set; }= string.Empty;


    // Relacionamentos
    public ClienteModel Cliente { get; set; }
    public FuncionarioModel Funcionario { get; set; }
    public ICollection<AtendimentoServicoModel> AtendimentoServicos { get; set; }




}
