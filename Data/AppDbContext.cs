
using BarbeariaMVC.Models;
using Microsoft.EntityFrameworkCore;


namespace BarbeariaMVC.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<ClienteModel> Clientes { get; set; }
    public DbSet<FuncionarioModel> Funcionarios { get; set; }
    public DbSet<ServicoModel> Servicos { get; set; }
    public DbSet<AtendimentoModel> Atendimentos { get; set; }
    public DbSet<AtendimentoServicoModel> AtendimentoServicos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Definindo a chave primária ClienteModel
        modelBuilder.Entity<ClienteModel>()
        .HasKey(c => c.ClienteId);

        // Definindo a chave primária AtendimentoModel
        modelBuilder.Entity<FuncionarioModel>()
        .HasKey(f => f.FuncionarioId);

        // Definindo a chave primária AtendimentoModel
        modelBuilder.Entity<AtendimentoModel>()
        .HasKey(a => a.AtendimentoId);

        // Definindo a chave primária AtendimentoModel
        modelBuilder.Entity<ServicoModel>()
        .HasKey(s => s.ServicoId);

        // Definindo a chave primária AtendimentoModel
        modelBuilder.Entity<AtendimentoServicoModel>()
        .HasKey(a => a.Id);


        // Configuração de muitos-para-muitos entre Atendimento e Servico via AtendimentoServico
        modelBuilder.Entity<AtendimentoServicoModel>()
            .HasKey(op => new { op.AtendimentoId, op.ServicoId }); // Define a chave composta

        modelBuilder.Entity<AtendimentoServicoModel>()
            .HasOne(op => op.Atendimento)
            .WithMany(a => a.AtendimentoServicos)
            .HasForeignKey(op => op.AtendimentoId); // Chave estrangeira para Atendimento

        modelBuilder.Entity<AtendimentoServicoModel>()
            .HasOne(op => op.Servico)
            .WithMany(s => s.AtendimentoServicos)
            .HasForeignKey(op => op.ServicoId); // Chave estrangeira para Servico

   



        // Opcional: Configurações de outros relacionamentos
        modelBuilder.Entity<AtendimentoModel>()
            .HasOne(a => a.Cliente)
            .WithMany(c => c.Atendimentos)
            .HasForeignKey(a => a.ClienteId);

        modelBuilder.Entity<AtendimentoModel>()
            .HasOne(a => a.Funcionario)
            .WithMany(f => f.Atendimentos)
            .HasForeignKey(a => a.FuncionarioId);


    }
}
