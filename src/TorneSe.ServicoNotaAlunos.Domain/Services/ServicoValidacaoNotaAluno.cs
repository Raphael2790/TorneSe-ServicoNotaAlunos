using TorneSe.ServicoNotaAlunos.Domain.Entidades;
using TorneSe.ServicoNotaAlunos.Domain.Interfaces.Services;

namespace TorneSe.ServicoNotaAlunos.Domain.Services;

public class ServicoValidacaoNotaAluno : IServicoValidacaoNotaAluno
{
    private void ValidarProfessor(Professor professor)
    {
        throw new NotImplementedException();
    }

    private void ValidarDisciplina(Disciplina disciplina)
    {
        throw new NotImplementedException();
    }

    private void ValidarAluno(Aluno aluno)
    {
        throw new NotImplementedException();
    }

    public void ValidarLancamento(Aluno aluno, Professor professor, Disciplina disciplina)
    {
        ValidarDisciplina(disciplina);
        ValidarProfessor(professor);
        ValidarAluno(aluno);
    }
}
