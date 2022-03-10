using System;
using System.Collections.Generic;
using TorneSe.ServicoNotaAlunos.Domain.Enums;

namespace TorneSe.ServicoNotaAlunos.Domain.Entidades;

public class Turma : Entidade
{
    public Turma(string nome, Periodo periodo, DateTime dataInicio, DateTime dataFinal, DateTime dataCadastrado, int disciplinaId)
    {
        Nome = nome;
        Periodo = periodo;
        DataInicio = dataInicio;
        DataFinal = dataFinal;
        DataCadastrado = dataCadastrado;
        DisciplinaId = disciplinaId;
    }

    protected Turma() { }

    public string Nome { get; private set; }
    public Periodo Periodo { get; private set; }
    public DateTime DataInicio { get; private set; }
    public DateTime DataFinal { get; private set; }
    public DateTime DataCadastrado { get; private set; }
    public int DisciplinaId { get; private set; }

    public Disciplina Disciplina { get; private set; }
    public ICollection<AlunosTurmas> AlunosTurmas { get; private set; }
    public ICollection<Aluno> Alunos { get; private set; }
}
