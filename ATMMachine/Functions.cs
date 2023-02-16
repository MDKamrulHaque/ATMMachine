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

        internal static void TransferMoney(string withDraw, Account userAccount, ListOfAllAccounts accountList)
        {
            Console.WriteLine($"Sure {userAccount.AccountHolderName}, but I will need their account details");
            Console.WriteLine("Please provide me with their account number");
            int receiverAccNumb = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please provide the account holder's name");
            string receiverAccName = Console.ReadLine();

            Account AccToSendMoneyTo = accountList.accounts.FirstOrDefault(a => a.AccountNumber == receiverAccNumb && a.AccountHolderName == receiverAccName);

            if (AccToSendMoneyTo != null)
            {
                Console.WriteLine($"Finally, please tell me how much you would like to transfer");
                decimal userSendAmount = Convert.ToDecimal(Console.ReadLine());

                if (userSendAmount <= 0)
                {
                    Console.WriteLine("Invalid amount, transfer amount must be greater than 0");
                }
                else if (userSendAmount > userAccount.AccountBalance)
                {
                    Console.WriteLine("Insufficient funds, transfer amount cannot exceed account balance");
                }
                else
                {
                    userAccount.AccountBalance -= userSendAmount;
                    AccToSendMoneyTo.AccountBalance += userSendAmount;
                    Console.WriteLine($"Transfer complete, we have sent {userSendAmount} to {AccToSendMoneyTo.AccountHolderName}");
                }
            }
            else
            {
                Console.WriteLine("Invalid account number or account holder's name. Please try again.");
            }

            Console.WriteLine("");
        }
    }
}
