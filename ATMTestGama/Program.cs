using System;

namespace ATMTestGama
{
    class Program
    {
        static void Main(string[] args)
        {
            var gamaBank = new Bank();
            var firstATM = new ATM(ref gamaBank);
            var secondATM = new ATM(ref gamaBank);

            firstATM.operateAtm();
            secondATM.operateAtm();
        }
    }
}
