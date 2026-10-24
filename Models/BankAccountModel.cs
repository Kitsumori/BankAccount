namespace BankAccount.Models;

public class BankAccountModel(
    string accountHolderName, 
    string dni, 
    decimal balance
)
{
    public string AccountHolderName { get; set; } = accountHolderName;
    public string Dni { get; set; } = dni;
    private decimal _balance { get; set; } = balance;
    public string? AccountNumber { get; set; }

    public void Deposit(decimal amount) => _balance += amount;

    public void Withdraw(decimal amount) => _balance -= amount;

    public decimal GetBalance() => _balance;

    public string GetAccountNumber() => AccountNumber ?? "";

    public string GetAccountHolderName() => AccountHolderName;

    public string GetDni() => Dni;
}