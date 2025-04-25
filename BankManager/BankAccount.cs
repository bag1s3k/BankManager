namespace BankManager;

public class BankAccount {
    private static readonly string[] _firstNames = { "Pepa", "Karel", "Jan", "Tomáš", "Martin", "Petr", "Jirka", "Marek", "David", "Michal" };
    private static readonly string[] _lastNames = { "Kašný", "Novák", "Svoboda", "Dvořák", "Černý", "Müller", "Pokorný", "Kovář", "Veselý", "Fiala" };
    private static readonly string[] _banksNumbers = new[] { "0300", "0100", "0600", "0800", "5500", "2700" };
    
    private Random rnd = new Random();
    
    private string _accountNumber;
    private string _userName;
    private double _balance;
    private List<string> _history = new List<string>();

    public BankAccount() {
        _accountNumber = GenerateAccountNumber();
        _userName = GenerateUserName();
        _balance = Math.Round((double)rnd.Next(10000), 2);
    }
    
    private string GenerateAccountNumber() {
        while (true) {
            string accNum = $"{rnd.NextInt64(1000000000, 9999999999)} / {_banksNumbers[rnd.Next(_banksNumbers.Length)]}";

            if (Database.DatabaseItems.All(acc => acc._accountNumber != accNum))
                return accNum;
        }
    }

    private string GenerateUserName() => $"{_firstNames[rnd.Next(_firstNames.Length)]} {_lastNames[rnd.Next(_lastNames.Length)]}";
    
    public bool SendMoney(double amount) {
        if (_balance - amount >= 0) {
            _balance -= amount;
            return true;
        } else {
            Console.WriteLine("Not enough money on bank account!!!");
            return false;
        } 
    }

    public void ReceiveMoney(double amount) {
        _balance += amount;
    }

    public override string ToString() {
        return $"{_userName}\t{_accountNumber}\t{_balance},-";
    }
}