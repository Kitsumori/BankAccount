namespace BankAccount;
class Program 
{
    static void Main(string[] args) 
    {
        var lastOption = -1;
        while(true)
        {
            switch(lastOption)
            {
                case 0:
                    return;
                default:
                    BankAccount.Menus.MainMenu.Show();
                    try
                    {
                        Console.Write("Que desea hacer? ");
                        lastOption = int.Parse(Console.ReadLine()!);    
                    }
                    catch
                    {
                        Console.WriteLine("Opción inválida, intente de nuevo.");
                    }
                    break;
            }
        }
    }
}

