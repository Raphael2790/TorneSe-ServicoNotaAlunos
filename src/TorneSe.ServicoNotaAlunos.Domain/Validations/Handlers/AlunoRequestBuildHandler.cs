using TorneSe.ServicoNotaAlunos.Domain.DomainObjects;
using TorneSe.ServicoNotaAlunos.Domain.Interfaces.Repositories;
using TorneSe.ServicoNotaAlunos.Domain.Notification;
using TorneSe.ServicoNotaAlunos.Domain.Utils;
using TorneSe.ServicoNotaAlunos.Domain.Validations.Handlers.Base;

namespace TorneSe.ServicoNotaAlunos.Domain.Validations.Handlers;

public class AlunoRequestBuildHandler : AbstractAsyncHandler<ServicoNotaValidacaoRequest>
{
    private readonly ContextoNotificacao _contextoNotificacao;
    private readonly IUsuarioRepository _usuarioRepository;

    public AlunoRequestBuildHandler(ContextoNotificacao contextoNotificacao,
                                    IUsuarioRepository usuarioRepository)
    {
        _contextoNotificacao = contextoNotificacao;
        _usuarioRepository = usuarioRepository;
    }

    public override async Task Handle(ServicoNotaValidacaoRequest request)
    {
        request.Aluno = await _usuarioRepository.BuscarAlunoDb(request.AlunoId);

        if(request.Aluno is null)
        {
            _contextoNotificacao.Add(Constantes.MensagensExcecao.ALUNO_INEXISTENTE);
            return;
        }

        await base.Handle(request);
    }
}
