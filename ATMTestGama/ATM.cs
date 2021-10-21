using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTestGama
{
    class ATM
    {
        public ATM(ref Bank owner)
        {
            Id = Guid.NewGuid();
            owner.AllAtms.Add(this);
            _ownerBank = owner;
        }

        public Guid Id { get; }

        readonly Bank _ownerBank;

        public void operateAtm()
        {
            bool isOperating = true;

            while (isOperating)
            {
                Console.Write(string.Join("\n", new string[]
                {
                    "What do you wish to do?",
                    "1 - Create account",
                    "2 - Deposit value",
                    "3 - Withdraw value",
                    "4 - Exit",
                    "\n"
                }));

                int userAction;

                try
                {
                    userAction = int.Parse(Console.ReadLine());
                    if (userAction < 1 || userAction > 4)
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("You must select a valid option between 1 and 4\n");
                    continue;
                }

                switch (userAction)
                {
                    case 1:
                        _ownerBank.CreateAccount();
                        break;
                    case 2:
                        _ownerBank.Deposit();
                        break;
                    case 3:
                        var withdrawnValue = _ownerBank.Withdraw();
                        SpitBills(withdrawnValue);
                        break;
                    default:
                        isOperating = false;
                        break;
                }
            }
        }

        private void SpitBills(decimal value)
        {
            decimal remainingWithdrawalValue = value;
            int Bills100, Bills50, Bills20, Bills10, Bills5 = 0;

            Bills100 = (int)Math.Floor(remainingWithdrawalValue / 100);
            remainingWithdrawalValue -= Bills100 * 100;

            Bills50 = (int)Math.Floor(remainingWithdrawalValue / 50);
            remainingWithdrawalValue -= Bills50 * 50;

            Bills20 = (int)Math.Floor(remainingWithdrawalValue / 20);
            remainingWithdrawalValue -= Bills20 * 20;

            Bills10 = (int)Math.Floor(remainingWithdrawalValue / 10);
            remainingWithdrawalValue -= Bills10 * 10;

            Bills5 = (int)Math.Floor(remainingWithdrawalValue / 5);

            Console.Write(string.Join("\n", new string[]
                {
                    "The following bills were withdrawn:",
                    $"100 USD bills: {Bills100} ",
                    $"50 USD bills: {Bills50}",
                    $"20 USD bills: {Bills20}",
                    $"10 USD bills: {Bills10}",
                    $"5 USD bills: {Bills5}",
                    "\n"
                }));

        }
    }
}
