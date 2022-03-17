using TorneSe.ServicoNotaAlunos.Data.Context;
using TorneSe.ServicoNotaAlunos.Domain.DomainObjects;
using TorneSe.ServicoNotaAlunos.Domain.Entidades;
using TorneSe.ServicoNotaAlunos.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TorneSe.ServicoNotaAlunos.Data.Repositories
;
public class UsuarioRepository : IUsuarioRepository
{
    private readonly FakeDbContexto _contexto;
    private readonly ServicoNotaAlunosContexto _servicoNotaAlunoContexto;

    public UsuarioRepository(FakeDbContexto contexto, 
                            ServicoNotaAlunosContexto servicoNotaAlunoContexto)
    {
        _contexto = contexto;
        _servicoNotaAlunoContexto = servicoNotaAlunoContexto;
    }

    public IUnitOfWork UnitOfWork => _servicoNotaAlunoContexto;

    public async Task<Aluno> BuscarAluno(int alunoId) =>
        await Task.FromResult(_contexto.Alunos.FirstOrDefault(x => x.Id == alunoId));

    public async Task<Aluno> BuscarAlunoDb(int alunoId) =>
            await _servicoNotaAlunoContexto.Alunos.FirstOrDefaultAsync(x => x.Id == alunoId);

    public async Task<Professor> BuscarProfessor(int professorId) =>
        await Task.FromResult(_contexto.Professores.FirstOrDefault(x => x.Id == professorId));

    public async Task<Professor> BuscarProfessorDb(int professorId) => 
        await _servicoNotaAlunoContexto.Professores.FirstOrDefaultAsync(x => x.Id == professorId);

    public void Dispose()
    {
        _contexto?.Dispose();
        _servicoNotaAlunoContexto?.Dispose();
    }
}
