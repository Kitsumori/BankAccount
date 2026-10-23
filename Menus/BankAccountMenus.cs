using BankAccount.Models;
using BankAccount.Services;
namespace BankAccount.Menus;
public static class BankAccountMenus
{
    public static void Main()
    {
        var menu = @"
            1. Crear cuenta
            2. Depositar
            3. Retirar
            4. Listar cuentas
            5. Buscar cuenta
            0. Salir
            ";
        Console.WriteLine(menu);
    }

    public static BankAccountModel CreateBankAccount()
    {
        var menu = @"
            --- Crear Cuenta ---
            Le solicitaremos los siguientes datos:
            - Nombre del titular
            - Número de DNI
            Ingrese los datos de la nueva cuenta:
            ";
        Console.WriteLine(menu);
        Console.Write("Nombre completo del titular: ");
        var name = Console.ReadLine()!;
        Console.Write("Número de DNI: ");
        var dni = Console.ReadLine()!;
        Console.Write("Saldo inicial: ");
        var balance = decimal.Parse(Console.ReadLine() ?? "0.0");

        return new(accountHolderName: name, dni: dni, balance: balance);
    }

    public static void DepositMenu(BankAccountService service)
    {
        var menu = @"
            --- Depositar ---
            Ingrese los siguientes datos:
            - Número de cuenta
            - Monto a depositar
            ";
        Console.WriteLine(menu);
        Console.Write("Número de cuenta: ");
        var accountNumber = Console.ReadLine()!;
        Console.Write("Monto a depositar: ");
        var amount = decimal.Parse(Console.ReadLine() ?? "1.0");

        service.Deposit(accountNumber, amount);
    }
}