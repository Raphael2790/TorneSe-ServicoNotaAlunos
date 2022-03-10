using TorneSe.ServicoNotaAlunos.Domain.DomainObjects;
using TorneSe.ServicoNotaAlunos.Domain.Entidades;
using TorneSe.ServicoNotaAlunos.Domain.Enums;

namespace TorneSe.ServicoNotaAlunos.Data.Context;

public class FakeDbContexto : IDisposable, IUnitOfWork
{
    public FakeDbContexto()
    {
        Alunos = AlunosFake();
        Professores = ProfessoresFake();
        Disciplinas = DisciplinasFake();
    }

    public ICollection<Aluno> Alunos { get; set; }
    public ICollection<Professor> Professores { get; set; }
    public ICollection<Disciplina> Disciplinas { get; set; }

    private ICollection<Aluno> AlunosFake()
    {
        var alunos = new List<Aluno>();

        Aluno aluno = new(1234,"Raphael", "raphael.s@email.com", 1212, DateTime.Now);

        // aluno.Usuario = new("Raphael Silvestre", "87628929919", new DateTime(1990, 3, 10), true,
        // "raphael.s@email.com",null, false,DateTime.Now);

        aluno.AlunosTurmas = new List<AlunosTurmas>() 
        { 
            new(1234,10019,DateTime.Now) 
            {
                Turma =
                    new("Grupo Matemática I", Periodo.Noturno, new DateTime(2021,06,01),
                    new DateTime(2021,12,01), DateTime.Now, 1341567)
            } 
        };

        alunos.Add(aluno);

        return alunos;
    }

    private ICollection<Professor> ProfessoresFake()
    {
        var professores = new List<Professor>();

        Professor professor = new(1282727, "Danilo", 
        "danilo.s@email.com", true,false,1212, DateTime.Now, 1341567);

        // professor.Usuario = new ("Danilo Aparecido", "30292919821", new DateTime(1983,01,01), true,
        // "danilo.aparecido@email.com",null, false, DateTime.Now);

        professores.Add(professor);

        return professores;
    }

    private ICollection<Disciplina> DisciplinasFake()
    {
        //biblioteca Bogus para gerar dados falsos é uma oportunidade

        var disciplinas = new List<Disciplina>();

        var disciplina = new Disciplina(1341567,"Matemática", "Matemática base ensino médio"
        , new DateTime(2021,10,12),new DateTime(2022,10,12), TipoDisciplina.Teorica, 
        new DateTime(2021, 09,12), 1282727);

        var conteudo = new Conteudo("Equações segundo grau", "Aprendizado de equações de segundo grau",
        new DateTime(2021,10,18), new DateTime(2021,11,18), new DateTime(2021,10,15));

        var atividade = new Atividade(34545,"Atividade avaliativa equações", TipoAtividade.Avaliativa,
         new DateTime(2021,11,10), new DateTime(2021, 11, 01), false);

        conteudo.CadastrarAtividade(atividade);

        disciplina.AdicionarConteudo(conteudo);

        disciplinas.Add(disciplina);

        return disciplinas;
    }

    public async Task<bool> Commit()
        => await Task.FromResult(true);

    public void Dispose()
    {
        Console.WriteLine("Fazendo liberação de recursos...");
    }
}


