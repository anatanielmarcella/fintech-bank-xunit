
using Xunit;
using FintechBank.App.Services;

namespace FintechBank.Tests;

public class EmprestimoServiceTests
{
    [Theory]
    [InlineData(10000.00, 10, 800, 1050.00)]
    [InlineData(10000.00, 10, 600, 1120.00)]
    [InlineData(10000.00, 10, 400, 1200.00)]
    public void CalcularValorParcela_DeveCalcularJurosCorretamente(
        decimal valorTotal,
        int parcelas,
        int scoreCredito,
        decimal valorEsperado)
    {
        var service = new EmprestimoService();

        decimal resultado = service.CalcularValorParcela(
            valorTotal, parcelas, scoreCredito);

        Assert.Equal(valorEsperado, resultado);
    }

    [Theory]
    [InlineData(5000.00, 1500.00, true)]
    [InlineData(5000.00, 1600.00, false)]
    public void AprovarEmprestimo_DeveValidarLimiteDaRenda(
        decimal rendaMensal,
        decimal valorParcela,
        bool resultadoEsperado)
    {
        var service = new EmprestimoService();

        bool resultado = service.AprovarEmprestimo(
            rendaMensal, valorParcela);

        Assert.Equal(resultadoEsperado, resultado);
    }
}
