using TorneSe.ServicoNotaAlunos.Domain.Interfaces.Services;
using TorneSe.ServicoNotaAlunos.Domain.Messages;
using TorneSe.ServicoNotaAlunos.Domain.Notification;

namespace TorneSe.ServicoNotaAlunos.Domain.Services;

public class ServicoNotaAluno : IServicoNotaAluno
{
    private readonly ContextoNotificacao _contextoNotificacao;

    public ServicoNotaAluno(ContextoNotificacao contextoNotificacao)
    {
        _contextoNotificacao = contextoNotificacao;
    }

    public async Task LancarNota(RegistrarNotaAluno registrarNotaAluno)
    {
        Console.WriteLine("Processando lógica de negocio...");

        if(!registrarNotaAluno.MensagemEstaValida())
        {
            _contextoNotificacao.AddRange(registrarNotaAluno.Validacoes.Errors.Select(x => x.ErrorMessage));
            return;
        }
    }
}
