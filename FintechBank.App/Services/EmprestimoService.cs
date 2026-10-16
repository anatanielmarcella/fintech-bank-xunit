
namespace FintechBank.App.Services;

public class EmprestimoService
{
    public decimal CalcularValorParcela(
        decimal valorTotal,
        int parcelas,
        int scoreCredito)
    {
        if (valorTotal <= 0)
            throw new ArgumentOutOfRangeException(
                nameof(valorTotal), "O valor total deve ser maior que zero.");

        if (parcelas <= 0)
            throw new ArgumentOutOfRangeException(
                nameof(parcelas), "O número de parcelas deve ser maior que zero.");

        if (scoreCredito < 0 || scoreCredito > 1000)
            throw new ArgumentOutOfRangeException(
                nameof(scoreCredito), "O score deve estar entre 0 e 1000.");

        decimal taxaJuros;

        if (scoreCredito >= 700)
        {
            taxaJuros = 1.05m;
        }
        else if (scoreCredito >= 500)
        {
            taxaJuros = 1.12m;
        }
        else
        {
            taxaJuros = 1.20m;
        }

        decimal valorComJuros = valorTotal * taxaJuros;

        return valorComJuros / parcelas;
    }

    public bool AprovarEmprestimo(decimal rendaMensal, decimal valorParcela)
    {
        if (rendaMensal < 0)
            throw new ArgumentOutOfRangeException(
                nameof(rendaMensal), "A renda não pode ser negativa.");

        if (valorParcela < 0)
            throw new ArgumentOutOfRangeException(
                nameof(valorParcela), "O valor da parcela não pode ser negativo.");

        return valorParcela <= rendaMensal * 0.30m;
    }
}
