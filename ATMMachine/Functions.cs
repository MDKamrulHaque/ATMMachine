using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMMachine
{
   
    internal class Functions
    {
       internal static void DepositMoney(string deposit, Account userAccount)
        {
            Console.WriteLine($"Sure {userAccount.AccountHolderName}, please tell me how much would like to deposit");
            decimal userDepositAmount = Convert.ToDecimal(Console.ReadLine());
            if (userDepositAmount <= 5)
            {
                Console.WriteLine("Invalid, mimum amount must be 5");
            }
            else
            {
                userAccount.AccountBalance += userDepositAmount;

                Console.WriteLine($"You have deposited {userDepositAmount}. Your new balance is {userAccount.AccountBalance}\n");
            }
        }

        internal static void ViewBalance(string viewBalance, Account userAccount)
        {
            Console.WriteLine($"\nYour current Balance is {userAccount.AccountBalance}\n");
        }

        internal static void WithDrawMoney(string withDraw, Account userAccount)
        {
            Console.WriteLine($"Sure {userAccount.AccountHolderName}, please tell me how much would like to take out");
            decimal userWithDrawAmount = Convert.ToDecimal(Console.ReadLine());
            if (userWithDrawAmount <= 5)
            {
                Console.WriteLine("Invalid, mimum amount must be 5");
            }
            else
            {
                userAccount.AccountBalance -= userWithDrawAmount;

                Console.WriteLine($"You have toke out {userWithDrawAmount}. Your new balance is {userAccount.AccountBalance}\n");
            }
        }

 
    }
}
