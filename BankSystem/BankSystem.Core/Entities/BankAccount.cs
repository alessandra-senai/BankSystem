using System;

namespace BankSystem.Core.Entities
{
    public abstract class BankAccount
    {
        public int AccountNumber { get; private set; }
        public int VerifyingDigit { get; private set; }
        public decimal Balance { get; private set; }
        public DateTime? AccountCreated { get; private set; }
        public DateTime? AccountFinished { get; private set; }
        public AccountSituationEnum AccountSituation { get; private set; }
        public string Password { get; private set; }
        public Client Client { get; private set; }


        public BankAccount(Client client)
        {
            Random random = new Random();
            AccountNumber = random.Next(50000, 100000);
            VerifyingDigit = random.Next(0, 9);
            AccountSituation = AccountSituationEnum.Created;
            Client = client;
        }

        public void OpenAccount(string password)
        {
            SetPassword(password);

            AccountSituation = AccountSituationEnum.Created;
            AccountCreated = DateTime.Now;

        }
        private void SetPassword(string password)
        {
            Password = password;
        }

        //método referente à sacar valor na conta
        public void WithdrawAccount(decimal value, string password)
        {
            if (password != Password)
            {
                throw new Exception("password is incorrect.");
            }

            if (Balance < value)
            {
                throw new Exception("Balance unavailable.");
            }

            Balance -= value;
        }
    }
}
