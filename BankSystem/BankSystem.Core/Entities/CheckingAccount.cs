using System;

namespace BankSystem.Core.Entities
{
    //Classe referente à conta-corrente
    public class CheckingAccount: BankAccount
    {
        public decimal Limit { get; private set; }
        public decimal CheckingAccountMaintenance { get; private set; } //taxa manutenção da conta-corrente



        public CheckingAccount(Client client, decimal limit) : base(client)
        {
            CheckingAccountMaintenance = 0.05M;
            Limit = limit;
        }

        //método referente à saque de valores da conta-corrente
        public void WithdrawCheckingAccount(decimal value, string password)
        {
            if (password != Password)
            {
                throw new Exception("password is incorrect.");
            }
             
            if (Balance + Limit < value)
            {
              throw new Exception("Balance unavailable.");
            }

            Limit -= value;


        }
    }
}
