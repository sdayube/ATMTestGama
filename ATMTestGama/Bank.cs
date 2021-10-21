using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTestGama
{
    class Bank
    {
        internal List<User> Users { get; set; }
        internal List<ATM> AllAtms { get; set; }
        internal List<Transaction> AllTransactions { get; set; }

        public Bank()
        {
            AllAtms = new List<ATM>();
            Users = new List<User>();
            AllTransactions = new List<Transaction>();
        }

        internal void CreateAccount()
        {
            (string name, string password) = GetUserDataInput();

            if (Users.Find(user => user.Name == name) is not null)
            {
                Console.WriteLine($"User {name} already exists");
            }
            else
            {
                Users.Add(new User(name, password));
                Console.WriteLine($"User {name} created!");
            }

            Console.WriteLine("\n");
        }

        internal void Deposit()
        {
            Console.WriteLine("Enter your user data:");
            User user = GetUser();
            if (user is null)
            {
                Console.WriteLine("User not found");
                return;
            }

            Console.WriteLine($"Current funds: {user.AccountBalance} USD");
            Console.WriteLine("Choose amount to deposit:");
            try
            {
                var value = decimal.Parse(Console.ReadLine());
                user.DepositValue(value);
                AllTransactions.Add(new Transaction(value, user.Id));
                Console.WriteLine($"Current funds: {user.AccountBalance} USD");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid deposit value");
            }

        }

        internal decimal Withdraw()
        {
            Console.WriteLine("Enter your user data:");
            User user = GetUser();
            if (user is null)
            {
                Console.WriteLine("User not found");
                return 0;
            }

            Console.WriteLine("Available bills: 100, 50, 20, 10, 5");
            Console.WriteLine($"Available funds: {user.AccountBalance} USD");
            Console.WriteLine("Choose amount to withdraw:");
            try
            {
                var value = decimal.Parse(Console.ReadLine());
                if (value > user.AccountBalance || value % 5 != 0)
                {
                    throw new ArgumentException();
                }
                user.WithdrawValue(value);
                AllTransactions.Add(new Transaction(-value, user.Id));
                Console.WriteLine($"Current funds: {user.AccountBalance} USD");
                return value;
            }
            catch (Exception ex) when (ex is FormatException or ArgumentException)
            {
                Console.WriteLine("Invalid deposit value");
                return 0;
            }
        }

        private User GetUser()
        {
            (string name, string password) = GetUserDataInput();
            return Users.Find(user => user.Name == name && user.Password == password);
        }

        public static (string, string) GetUserDataInput()
        {
            Console.WriteLine("Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Password:");
            string password = Console.ReadLine();

            Console.WriteLine("\n");

            return (name, password);
        }
    }
}
