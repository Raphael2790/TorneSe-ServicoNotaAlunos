using Microsoft.EntityFrameworkCore;
using TorneSe.ServicoNotaAlunos.Data.Context;
using TorneSe.ServicoNotaAlunos.Domain.DomainObjects;
using TorneSe.ServicoNotaAlunos.Domain.Entidades;
using TorneSe.ServicoNotaAlunos.Domain.Interfaces.Repositories;

namespace TorneSe.ServicoNotaAlunos.Data.Repositories;

public class DisciplinaRepository : IDisciplinaRepository
{
    private readonly FakeDbContexto _contexto;
    private readonly ServicoNotaAlunosContexto _servicoNotaAlunoContexto;

    public DisciplinaRepository(FakeDbContexto contexto, 
                                ServicoNotaAlunosContexto servicoNotaAlunoContexto)
    {
        _contexto = contexto;
        _servicoNotaAlunoContexto = servicoNotaAlunoContexto;
    }

    public IUnitOfWork UnitOfWork => _servicoNotaAlunoContexto;

    public async Task<bool> ConectadoAoBanco() =>
        await _servicoNotaAlunoContexto.Database.CanConnectAsync();
    
    public async Task<Disciplina> BuscarDisciplinaPorAtividadeId(int atividadeId) =>
        await Task.FromResult(_contexto.Disciplinas.FirstOrDefault(x => x.Conteudos.SelectMany(y => y.Atividades).Any(y => y.Id == atividadeId)));

    public async Task<Disciplina> BuscarDisciplinaPorAtividadeIdDb(int atividadeId) =>
        await _servicoNotaAlunoContexto.Disciplinas.FirstOrDefaultAsync(x => x.Conteudos.SelectMany(y => y.Atividades).Any(y => y.Id == atividadeId));

    public void Dispose()
    {
        _contexto?.Dispose();
        _servicoNotaAlunoContexto?.Dispose();
    }
}
