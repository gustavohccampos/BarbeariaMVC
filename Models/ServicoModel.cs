
namespace BarbeariaMVC.Models;

public class ServicoModel
{
    public int ServicoId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public DateTime DataCadastro { get; set; }


    // Relacionamento muitos-para-muitos via AtendimentoServico
    public ICollection<AtendimentoServicoModel> AtendimentoServicos { get; set; }
}
