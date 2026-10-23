namespace BankAccount.Helpers;
public static class StringHelper
{
    public static string GenerateRandomAccountNumber()
    {
        var random = new Random();
        var accountNumber = string.Empty;
        for (int i = 0; i < 22; i++)
        {
            accountNumber += random.Next(0, 10).ToString();
        }
        return accountNumber;
    }
}