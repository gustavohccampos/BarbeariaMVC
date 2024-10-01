namespace BarbeariaMVC.Models;

public class AtendimentoServicoModel
{
    public int Id { get; set; }
    public int AtendimentoId { get; set; }  // Chave estrangeira para Atendimento
    public AtendimentoModel Atendimento { get; set; }  // Propriedade de navegação

    public int ServicoId { get; set; }  // Chave estrangeira para Servico
    public ServicoModel Servico { get; set; }  // Propriedade de navegação
}
