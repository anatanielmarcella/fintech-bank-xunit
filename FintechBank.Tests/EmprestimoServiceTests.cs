
using FintechBank.App.Services;

namespace FintechBank.Tests;

public class EmprestimoServiceTests
{
    private readonly EmprestimoService _service = new();

    [Theory]
    [InlineData(1200, 12, 700, 105)]
    [InlineData(1200, 12, 500, 112)]
    [InlineData(1200, 12, 499, 120)]
    [InlineData(1200, 12, 800, 105)]
    public void CalcularValorParcela_DeveAplicarTaxaCorreta(
        decimal valorTotal,
        int parcelas,
        int scoreCredito,
        decimal valorEsperado)
    {
        var resultado = _service.CalcularValorParcela(
            valorTotal, parcelas, scoreCredito);

        Assert.Equal(valorEsperado, resultado);
    }

    [Theory]
    [InlineData(2000, 600, true)]
    [InlineData(2000, 600.01, false)]
    [InlineData(2000, 500, true)]
    [InlineData(1000, 300, true)]
    [InlineData(1000, 300.01, false)]
    public void AprovarEmprestimo_DeveRespeitarLimiteDe30PorCento(
        decimal rendaMensal,
        decimal valorParcela,
        bool aprovadoEsperado)
    {
        var resultado = _service.AprovarEmprestimo(
            rendaMensal, valorParcela);

        Assert.Equal(aprovadoEsperado, resultado);
    }
}
