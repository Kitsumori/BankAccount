using BankAccount.Models;
using BankAccount.Helpers;

namespace BankAccount.Repositories;
public class BankAccountRepository
{
    private readonly List<BankAccountModel> _accounts = DbFileHelper.LoadFromFile();

    public void Add(BankAccountModel account) => _accounts.Add(account);

    public List<BankAccountModel> GetAll() => _accounts;

    public BankAccountModel? GetAccountByNumber(string accountNumber) => 
    _accounts.FirstOrDefault(account => account.AccountNumber == accountNumber);

    public BankAccountModel? GetAccountByNameAndDni(string accountHolderName, string dni) =>
        _accounts.FirstOrDefault(account => account.AccountHolderName == accountHolderName && account.Dni == dni);

    public void SaveChanges() => DbFileHelper.SaveToFile(_accounts);
}