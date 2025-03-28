using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.classes
{
    public class User
    {
        public string Username { get; set; }
        public int Balance { get; set; }

        public User(string username, int balance = 1000)
        {
            Username = username;
            Balance = balance;
        }

        public void WinBet(int amount)
        {
            Balance += amount;
        }

        public void LoseBet(int amount)
        {
            Balance -= amount;
        }
    }
}
