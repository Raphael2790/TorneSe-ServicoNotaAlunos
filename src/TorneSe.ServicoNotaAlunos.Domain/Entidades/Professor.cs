using System;

namespace TorneSe.ServicoNotaAlunos.Domain.Entidades;

public class Professor : Entidade
{
    public Professor(int professorId, string nomeAbreviado, 
                string emailInterno, bool professorTitular, 
                bool professorSuplente, int usuarioId, DateTime dataCadastro, int disciplinaId)
    {
        Id = professorId;
        NomeAbreviado = nomeAbreviado;
        EmailInterno = emailInterno;
        ProfessorTitular = professorTitular;
        ProfessorSuplente = professorSuplente;
        UsuarioId = usuarioId;
        DataCadastro = dataCadastro;
        DisciplinaId = disciplinaId;
    }

    protected Professor() {}

    public string NomeAbreviado { get; private set; }
    public string EmailInterno { get; private set; }
    public bool ProfessorTitular { get; private set; }
    public bool ProfessorSuplente { get; private set; }
    public int UsuarioId { get; private set; }
    public DateTime DataCadastro { get; private set; }
    public int DisciplinaId { get; private set; }

    public Usuario Usuario { get; set; }
    public Disciplina Disciplina { get; private set; }
}
