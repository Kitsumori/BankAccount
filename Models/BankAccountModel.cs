namespace BankAccount.Models;

public class BankAccountModel(
    string accountHolderName, 
    string dni, 
    decimal balance
)
{
    public required string AccountHolderName { get; set; } = accountHolderName;
    public required string Dni { get; set; } = dni;
    private decimal Balance { get; set; } = balance;
    public string? AccountNumber { get; set; }

    public void Deposit(decimal amount) => Balance += amount;

    public void Withdraw(decimal amount) => Balance -= amount;

    public decimal GetBalance() => Balance;
}