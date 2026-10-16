
namespace FintechBank.App.Services;

public class ContaCorrenteService
{
    public decimal CalcularTaxaManutencao(decimal saldo, bool clienteEspecial)
    {
        if (saldo >= 5000m || clienteEspecial)
        {
            return 0.00m;
        }

        if (saldo >= 1000m)
        {
            return 12.50m;
        }

        return 25.00m;
    }

    public bool PodeRealizarSaque(
        decimal saldo,
        decimal limiteChequeEspecial,
        decimal valorSaque)
    {
        return valorSaque <= saldo + limiteChequeEspecial;
    }
}
