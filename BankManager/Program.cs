namespace BankManager;

class Program {
    static void Main(string[] args) {
        Database.DatabaseItems.Add(new BankAccount());
        Console.WriteLine(Database.DatabaseItems[0]);
    }
}