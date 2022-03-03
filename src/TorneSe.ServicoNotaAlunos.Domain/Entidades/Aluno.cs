namespace TorneSe.ServicoNotaAlunos.Domain.Entidades;

public class Aluno: Usuario
{
    public Aluno(int alunoId,string nomeAbreviado, string emailInterno, int usuarioId, DateTime dataCadastro)
    {
        Id = alunoId;
        NomeAbreviado = nomeAbreviado;
        EmailInterno = emailInterno;
        DataCadastro = dataCadastro;
        Notas = new List<Nota>();
        AlunosTurmas = new List<AlunosTurmas>();
    }

    protected Aluno() { }

    public string NomeAbreviado { get; private set; }
    public string EmailInterno { get; private set; }
    public DateTime DataCadastro { get; private set; }

    public ICollection<Nota> Notas { get; private set; }
    public ICollection<AlunosTurmas> AlunosTurmas { get; set; }

    public void AdicionarNota(Nota nota) 
    {
        //Validar a Nota
        Notas.Add(nota);
    }
}
