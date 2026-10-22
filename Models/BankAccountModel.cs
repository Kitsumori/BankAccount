namespace BankAccount.Models;

public class BankAccountModel
{
    public string AccountNumber { get; set; }
    public string AccountHolderName { get; set; }
    public string Dni { get; set; }
    public decimal Balance { get; set; }
}