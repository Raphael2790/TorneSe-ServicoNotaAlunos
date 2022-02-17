using TorneSe.ServicoNotaAlunos.Domain.DomainObjects;
using TorneSe.ServicoNotaAlunos.Domain.Entidades;
using TorneSe.ServicoNotaAlunos.Domain.Notification;
using TorneSe.ServicoNotaAlunos.Domain.Utils;
using TorneSe.ServicoNotaAlunos.Domain.Validations.Handlers.Base;

namespace TorneSe.ServicoNotaAlunos.Domain.Validations.Handlers;

public class AlunoValidacaoHandler : AbstractHandler<ServicoNotaValidacaoRequest>
{
    private readonly ContextoNotificacao _contextoNotificacao;

    public AlunoValidacaoHandler(ContextoNotificacao contextoNotificacao)
    {
        _contextoNotificacao = contextoNotificacao;
    }
    
    public override void Handle(ServicoNotaValidacaoRequest request)
    {
        if(!request.Aluno.Usuario.Ativo)
        {
            _contextoNotificacao.Add(Constantes.MensagensValidacao.ALUNO_INATIVO);
            return;
        }

        //O aluno deve estar inscrito na disciplina pela sua turma
        if(!AlunoEstaMatriculado(request.Aluno, request.Disciplina.Id))
        {
            _contextoNotificacao.Add(Constantes.MensagensValidacao.ALUNO_NAO_ESTA_MATRICULADO);
            return;
        }

        base.Handle(request);
    }

    private bool AlunoEstaMatriculado(Aluno aluno, int disciplinaId) =>
        aluno.AlunosTurmas
            .SelectMany(alunoTurma => alunoTurma.Turmas)
            .Any(turma => turma.DisciplinaId == disciplinaId);
}