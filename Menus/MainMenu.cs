
namespace BankAccount.Menus;
public static class MainMenu
{
    public static void Show()
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
}