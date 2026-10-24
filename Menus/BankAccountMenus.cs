using BankAccount.Models;
using BankAccount.Services;
namespace BankAccount.Menus;
public static class BankAccountMenus
{
    public static string MainMenu()
    {
        var menu = @"
            --- Menú Principal ---
            1. Crear cuenta
            2. Depositar
            3. Retirar
            4. Listar cuentas
            5. Buscar cuenta
            0. Salir
            ";
        Console.WriteLine(menu);
        return Console.ReadLine()!;
    }

    public static void CreateBankAccount(BankAccountService service)
    {
        var menu = @"
            --- Crear Cuenta ---
            Le solicitaremos los siguientes datos:
            - Nombre del titular
            - Número de DNI
            Ingrese los datos de la nueva cuenta:
            ";
        Console.WriteLine(menu);
        try
        {
            Console.Write("Nombre completo del titular: ");
            var name = Console.ReadLine() ?? throw new ArgumentException("El nombre del titular no puede estar vacío.");
            Console.Write("Número de DNI: ");
            var dni = Console.ReadLine() ?? throw new ArgumentException("El DNI no puede estar vacío.");
            Console.Write("Saldo inicial: ");
            var balance = decimal.Parse(Console.ReadLine() ?? "0.0");
            var account = new BankAccountModel(accountHolderName: name, dni: dni, balance: balance);
            service.CreateAccount(account);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return;
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
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
        try
        {
            service.Deposit(accountNumber, amount);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static void WithdrawMenu(BankAccountService service)
    {
        var menu = @"
            --- Retirar ---
            Ingrese los siguientes datos:
            - Número de cuenta
            - Monto a retirar
            ";
        Console.WriteLine(menu);
        Console.Write("Número de cuenta: ");
        var accountNumber = Console.ReadLine()!;
        Console.Write("Monto a retirar: ");
        var amount = decimal.Parse(Console.ReadLine() ?? "1.0");
        try
        {
            service.Withdraw(accountNumber, amount);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static void ListAccountsMenu(BankAccountService service)
    {
        var menu = @"
            --- Listar Cuentas ---
            ";
        Console.WriteLine(menu);
        var accounts = service.GetAllAccounts();
        if (accounts.Count == 0)
        {
            Console.WriteLine("No hay cuentas registradas.");
            return;
        }
        else
        {
            foreach (var account in accounts)
            {
                Console.WriteLine($"Número de cuenta: {account.GetAccountNumber()}, Titular: {account.GetAccountHolderName()}, DNI: {account.GetDni()}");
            }
        }
        
    }
    public static void SearchAccountMenu(BankAccountService service)
    {
        BankAccountModel account;
        var menu = @"
            --- Buscar Cuenta ---
            Desea buscar por número de cuenta o por nombre y DNI?
            - Ingrese '1' para buscar por número de cuenta
            - Ingrese '2' para buscar por nombre y DNI
            ";
        Console.WriteLine(menu);
        var option = Console.ReadLine()!;
        try
        {
            switch (option)
            {
                case "1":
                    Console.Write("Número de cuenta: ");
                    var accountNumber = Console.ReadLine() ?? throw new ArgumentException("Número de cuenta inválido.");
                    account = service.GetAccountByNumber(accountNumber);
                    Console.WriteLine($"Número de cuenta: {account.AccountNumber}, Titular: {account.AccountHolderName}, DNI: {account.Dni}, Saldo: {account.GetBalance()}");
                    break;
                case "2":
                    Console.Write("Nombre del titular: ");
                    var accountHolderName = Console.ReadLine() ?? throw new ArgumentException("Nombre del titular inválido.");
                    Console.Write("DNI del titular: ");
                    var dni = Console.ReadLine() ?? throw new ArgumentException("DNI del titular inválido.");
                    account = service.GetAccountByNameAndDni(accountHolderName, dni);
                    Console.WriteLine($"Número de cuenta: {account.GetAccountNumber()}, Titular: {account.GetAccountHolderName()}, DNI: {account.GetDni()}, Saldo: {account.GetBalance()}");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Cuenta no encontrada.");
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("El monto ingresado no es valido.");
        }
    }
}