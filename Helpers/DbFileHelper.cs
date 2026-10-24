using System.Text.Json;
using BankAccount.Models;

namespace BankAccount.Helpers;
public static class DbFileHelper
{
    readonly static string _filePath = "bankAccounts.json";
    readonly static JsonSerializerOptions _options = new()
    {
        WriteIndented = true
    };

    public static void SaveToFile(List<BankAccountModel> data)
    {
        var json = JsonSerializer.Serialize(data, _options);
        File.WriteAllText(_filePath, json);     
    }

    public static List<BankAccountModel> LoadFromFile()
    {
        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<BankAccountModel>>(json) ?? [];
        }
        return [];
    }
}