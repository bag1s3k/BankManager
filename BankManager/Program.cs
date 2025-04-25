namespace BankManager;

class Program {
    static void Main(string[] args) {
        for (int i = 0; i < 2; i++)
            Database.DatabaseItems.Add(new BankAccount());
        
        foreach(var acc in Database.DatabaseItems)
            Console.WriteLine(acc);

        Database.DatabaseItems[0].SendMoney(1000);
        Database.DatabaseItems[1].ReceiveMoney(1000);
        
        foreach(var acc in Database.DatabaseItems)
            Console.WriteLine(acc);
    }
}