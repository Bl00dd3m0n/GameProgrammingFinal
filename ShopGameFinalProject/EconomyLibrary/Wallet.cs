using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomyLibrary
{
    public class Wallet
    {
        float balance;
        float Balance { get { return balance; } }
        bool AccountFroze;
        public Wallet(float StartingBalance)
        {
            this.balance = StartingBalance;
        }
        public void Freeze()
        {
            if (AccountFroze) AccountFroze = false;
            else AccountFroze = true;
        }
        public void Inject(float amount)
        {
            balance += amount;
        }
        public bool Withdraw(float amount)
        {
            if (balance - amount >= 0)
            {
                balance -= amount;
                return true;
            }
            //TODO possibly add credit but that is a last touches possibility
            return false;
        }
    }
}
