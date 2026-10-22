using BankAccount.Models;

namespace BankAccount.Repository;
public class BankAccountRepository
{
    private readonly List<BankAccountModel> _accounts = new();

    public void Add(BankAccountModel account) => _accounts.Add(account);

    public List<BankAccountModel> GetAll() => _accounts;

    public BankAccountModel? GetAccountByNumber(string accountNumber) => 
    _accounts.FirstOrDefault(account => account.AccountNumber == accountNumber);

    public BankAccountModel? GetAccountByNameAndDni(string accountHolderName, string dni) =>
        _accounts.FirstOrDefault(account => account.AccountHolderName == accountHolderName && account.Dni == dni);

    public void AddToBalance(string account, decimal ammount)
    {
        var accountToUpdate = GetAccountByNumber(account);
        if (accountToUpdate == null) throw new ArgumentException("Account not found");
        accountToUpdate.Balance += ammount;
    }

    public void SubtractFromBalance(string account, decimal ammount)
    {
        var accountToUpdate = GetAccountByNumber(account);
        if (accountToUpdate == null) throw new ArgumentException("Account not found");
        if (accountToUpdate.Balance < ammount) throw new InvalidOperationException("Insufficient balance");
        accountToUpdate.Balance -= ammount;
    }
}