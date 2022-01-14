using System;
namespace TorneSe.ServicoNotaAlunos.Domain.Entidades;

public class Nota : Entidade
{
    public Nota(int alunoId, int atividadeId, double valorNota, DateTime dataLancamento, int usuarioId, bool canceladaPorRetentativa)
    {
        AlunoId = alunoId;
        AtividadeId = atividadeId;
        ValorNota = valorNota;
        DataLancamento = dataLancamento;
        UsuarioId = usuarioId;
        CanceladaPorRetentativa = canceladaPorRetentativa;
    }

    protected Nota() { }

    public int AlunoId { get; private set; }
    public int AtividadeId { get; private set; }
    public double ValorNota { get; private set; }
    public DateTime DataLancamento { get; private set; }
    public int UsuarioId { get; private set; } //Usuario Sistemico
    public bool CanceladaPorRetentativa { get;  private set;}

    public Aluno Aluno { get; set; }
    public Atividade Atividade { get; set; }
}
