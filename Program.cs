using BankAccount.Menus;
using BankAccount.Services;
using BankAccount.Repositories;

namespace BankAccount;
class Program 
{
    static void Main(string[] args) 
    {
        var lastOption = BankAccountMenus.MainMenu();
        var repository = new BankAccountRepository();
        var service = new BankAccountService(repository);
        while(true)
        {
            switch(lastOption)
            {
                case "0":
                    Console.WriteLine("Saliendo del programa...");
                    repository.SaveChanges();
                    return;
                case "1":
                    BankAccountMenus.CreateBankAccount(service);
                    lastOption = BankAccountMenus.MainMenu();
                    break;
                case "2":
                    BankAccountMenus.DepositMenu(service);
                    lastOption = BankAccountMenus.MainMenu();
                    break;
                case "3":
                    BankAccountMenus.WithdrawMenu(service);
                    lastOption = BankAccountMenus.MainMenu();
                    break;
                case "4":
                    BankAccountMenus.ListAccountsMenu(service);
                    lastOption = BankAccountMenus.MainMenu();
                    break;
                case "5":
                    BankAccountMenus.SearchAccountMenu(service);
                    lastOption = BankAccountMenus.MainMenu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opción inválida, intente de nuevo.");
                    lastOption = BankAccountMenus.MainMenu();    
                    break;
            }
        }
    }
}

