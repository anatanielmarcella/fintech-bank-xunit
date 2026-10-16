
using FintechBank.App.Services;

namespace FintechBank.Tests;

public class ContaCorrenteServiceTests
{
    private readonly ContaCorrenteService _service = new();

    [Theory]
    [InlineData(500, false, 25.00)]
    [InlineData(1000, false, 12.50)]
    [InlineData(4999.99, false, 12.50)]
    [InlineData(5000, false, 0.00)]
    [InlineData(500, true, 0.00)]
    public void CalcularTaxaManutencao_DeveRetornarTaxaCorreta(
        decimal saldo,
        bool clienteEspecial,
        decimal taxaEsperada)
    {
        var resultado = _service.CalcularTaxaManutencao(
            saldo, clienteEspecial);

        Assert.Equal(taxaEsperada, resultado);
    }

    [Theory]
    [InlineData(1000, 500, 1400, true)]
    [InlineData(1000, 500, 1500, true)]
    [InlineData(1000, 500, 1500.01, false)]
    [InlineData(0, 500, 500, true)]
    public void PodeRealizarSaque_DeveValidarLimiteCorretamente(
        decimal saldo,
        decimal limiteChequeEspecial,
        decimal valorSaque,
        bool saqueEsperado)
    {
        var resultado = _service.PodeRealizarSaque(
            saldo, limiteChequeEspecial, valorSaque);

        Assert.Equal(saqueEsperado, resultado);
    }
}
