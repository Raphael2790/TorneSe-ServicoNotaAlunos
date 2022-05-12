using Xunit;
using TorneSe.ServicoNotaAlunos.UnitTests.Fakes;
using TorneSe.ServicoNotaAlunos.Domain.Validations;
using System.Linq;

namespace TorneSe.ServicoNotaAlunos.UnitTests.Domain.Messages;

public class RegistrarNotaAlunoTests
{
    [Fact(DisplayName = "Mensagem com informacoes corretas deve estar valida")]
    [Trait("Domain", "Messages")]
    public void DadaMensagem_QuandoMensagemComInformacoesCorretas_DeveEstarValida()
    {
        //Arrange
        var mensagem = RegistrarNotaAlunoFakes.RetornaMensagemValida();

        //Act
        var mensagemValida = mensagem.MensagemEstaValida();

        //Assert
        Assert.True(mensagemValida);
        Assert.Empty(mensagem.Validacoes.Errors);
    }

    [Fact(DisplayName = "Mensagem com informacoes incorretas deve estar invalida")]
    [Trait("Domain", "Messages")]
    public void DadaMensagem_QuandoMensagemComInformacoesFaltando_DeveEstarInvalida()
    {
        //Arrange
        var mensagem = RegistrarNotaAlunoFakes.RetornaMensagemInvalida();

        //Act
        var mensagemValida = mensagem.MensagemEstaValida();

        //Assert
        Assert.False(mensagemValida);
        Assert.NotEmpty(mensagem.Validacoes.Errors);
        Assert.True(mensagem.Validacoes.Errors.Any(x => x.ErrorMessage == RegistrarNotaAlunoValidacao.AlunoIdMsgErro));
    }
}
