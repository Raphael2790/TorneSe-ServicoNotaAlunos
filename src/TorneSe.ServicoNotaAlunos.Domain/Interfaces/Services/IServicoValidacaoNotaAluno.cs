using TorneSe.ServicoNotaAlunos.Domain.DomainObjects;
using TorneSe.ServicoNotaAlunos.Domain.Entidades;

namespace TorneSe.ServicoNotaAlunos.Domain.Interfaces.Services;

public interface IServicoValidacaoNotaAluno
{
    void ValidarLancamento(Aluno aluno, Professor professor, Disciplina disciplina);
    void ValidarLancamento(ServicoNotaValidacaoRequest request);
}