
namespace FintechBank.App.Services;

public class EmprestimoService
{
    public decimal CalcularValorParcela(
        decimal valorTotal,
        int parcelas,
        int scoreCredito)
    {
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
        return valorParcela <= rendaMensal * 0.30m;
    }
}
