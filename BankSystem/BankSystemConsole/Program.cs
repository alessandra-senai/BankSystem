using BankSystem.Core.Entities;
using System;

namespace BankSystemConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("João Pedro", "123456", "345345666", "Rua Flor de Jasmim, 45 - Águas da Prata - SP");

            CheckingAccount checkingAccount = new CheckingAccount(client, 100);

            Console.WriteLine("----------Checking Account created------------");
            Console.WriteLine($"Client: {client.Name} CPF: {client.CPF}");
            Console.WriteLine("");
            Console.WriteLine($"Situation:{checkingAccount.AccountSituation} " +
                $"      Account:{checkingAccount.AccountNumber}-{checkingAccount.VerifyingDigit}");
            Console.WriteLine("");
            Console.WriteLine("************************************");
            Console.WriteLine("");

            string password = "abc12345";
            checkingAccount.OpenAccount(password);
            Console.WriteLine("----------Account Created------------");
            Console.WriteLine("");
            Console.WriteLine($"Situation:{checkingAccount.AccountSituation}" +
                $"      Account:{checkingAccount.AccountNumber}-{checkingAccount.VerifyingDigit}");

            Console.WriteLine("");
            Console.WriteLine("----------Withdraw value------------");
            Console.WriteLine("");
            checkingAccount.WithdrawCheckingAccount(10, password);
            Console.WriteLine(checkingAccount.Limit);
        }
    }
}
