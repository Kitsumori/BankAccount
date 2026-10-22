namespace BankAccount.Menus;
public static class CreateAccountMenu
{
    public static void Show()
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

    }
}