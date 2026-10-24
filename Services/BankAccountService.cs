using BankAccount.Repositories;
using BankAccount.Helpers;
using BankAccount.Models;

namespace BankAccount.Services;
public class BankAccountService(BankAccountRepository repository)
{
    private readonly BankAccountRepository _repository = repository;

    public void CreateAccount(BankAccountModel account)
    {
        account.AccountNumber = StringHelper.GenerateRandomAccountNumber();
        _repository.Add(account);
    }

    public List<BankAccountModel> GetAllAccounts() => _repository.GetAll();

    public BankAccountModel GetAccountByNumber(string accountNumber) => 
        _repository.GetAccountByNumber(accountNumber) ?? throw new ArgumentException("Account not found");

    public BankAccountModel GetAccountByNameAndDni(string accountHolderName, string dni) => 
        _repository.GetAccountByNameAndDni(accountHolderName, dni) ?? throw new ArgumentException("Account not found");
    
    public void Deposit(string accountNumber, decimal amount)
    {
        var account = GetAccountByNumber(accountNumber) ?? throw new ArgumentException("Account not found");
        if (amount <= 0) throw new ArgumentException("Deposit amount must be greater than zero");
        account.Deposit(amount);
    }
    public void Withdraw(string accountNumber, decimal amount)
    {
        var account = GetAccountByNumber(accountNumber) ?? throw new ArgumentException("Account not found");
        if (amount <= 0) throw new ArgumentException("Withdrawal amount must be greater than zero");
        if (account.GetBalance() < amount) throw new InvalidOperationException("Insufficient balance");
        account.Withdraw(amount);
    }
}