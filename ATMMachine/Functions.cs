using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMMachine
{
   
    internal class Functions
    {
       internal static void DepositMoney(Account userAccount)
        {
            Console.Clear();
            Console.WriteLine("\n---------Deposit Service---------\n");
            Console.WriteLine($"\nhow much would you like to deposit\n");
            decimal userDepositAmount = Convert.ToDecimal(Console.ReadLine());
            if (userDepositAmount <= 5)
            {
               
                Console.WriteLine("\nInvalid, minimum amount must be £5");
                Console.WriteLine("\nTo go back to main menu press any key");
                Console.ReadLine();
                Console.Clear();
            }
            else if (userDepositAmount > 500)
            {
                
                Console.WriteLine("\nDeposit amount cannot be more than £500\n");
                Console.WriteLine("\nTo go back to main menu press any key");
                Console.ReadLine();
                Console.Clear();
            }
            else if(userDepositAmount <= 500)
            {
                userAccount.AccountBalance += userDepositAmount;
               
                Console.WriteLine($"\nYou Deposited £{userDepositAmount}. \n\nYour new balance is £{userAccount.AccountBalance}\n");
                Console.WriteLine("\nTo go back to main menu press any key");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("\nError: somthing went wrong please try again.\n");
                Console.WriteLine("\nTo go back to main menu press any key");
                Console.ReadLine();
                Console.Clear();

            }
        }

        internal static void ViewBalance(Account userAccount)
        {
            Console.Clear();
            Console.WriteLine("\n---------Account Balance Service---------\n");
            Console.WriteLine($"\nHi {userAccount.AccountHolderName}, Your current Balance is £{userAccount.AccountBalance}\n");
            Console.WriteLine("\nTo go back to main menu press any key");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void WithDrawMoney(Account userAccount)
        {
            Console.Clear();
            Console.WriteLine("\n---------Withdraw Service---------\n");
            Console.WriteLine($"\nhow much would you like to take out\n");
            decimal userWithDrawAmount = Convert.ToDecimal(Console.ReadLine());
            if (userWithDrawAmount <= 5)
            {
                
                Console.WriteLine("\nInvalid, minimum amount must be £5");
                Console.WriteLine("\nTo go back to main menu press any key");
                Console.ReadLine();
                Console.Clear();
            }
            else if(userWithDrawAmount > 500 || userWithDrawAmount> userAccount.AccountBalance)
            {
                
                Console.WriteLine("\nNot possible! amount cannot exceed account balance or be more than £500\n");
                Console.WriteLine("\nTo go back to main menu press any key");
                Console.ReadLine();
                Console.Clear();
            }
            else if(userWithDrawAmount <= 500)
            {
                userAccount.AccountBalance -= userWithDrawAmount;
                Console.WriteLine($"\nYou toke out £{userWithDrawAmount}. Your new balance is £{userAccount.AccountBalance}\n");
                Console.WriteLine("\nTo go back to main menu press any key");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("\nError: somthing went wrong please try again.\n");
                Console.WriteLine("\nTo go back to main menu press any key");
                Console.ReadLine();
                Console.Clear();

            }
        }

        internal static void TransferMoney(Account userAccount, ListOfAllAccounts accountList)
        {
            Console.Clear();
            Console.WriteLine("\n---------Transfer Service---------\n");
            Console.WriteLine("\nplease provide the account holder's name\n");
            string receiverAccName = Console.ReadLine();
            Console.WriteLine($"\nNow, enter their account number\n");
            int receiverAccNumb = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nYou entered" +
                              $"\n\nAccount Holder Name: {receiverAccName} " +
                              $"\nAccount Number: {receiverAccNumb} " +
                              $"\n\ndo you wish to continue? type 'y' or 'n'\n");
            string userYesOrNo = Console.ReadLine();
            if (userYesOrNo.Equals("y"))
            {
                Account AccToSendMoneyTo = accountList.accounts.FirstOrDefault(a => a.AccountNumber == receiverAccNumb && a.AccountHolderName == receiverAccName);
               
                if (AccToSendMoneyTo != null)
                {
                    Console.WriteLine($"\nHow much you would like to transfer\n");
                    decimal userSendAmount = Convert.ToDecimal(Console.ReadLine());

                    if (userSendAmount <= 0)
                    {
                        Console.WriteLine("\nInvalid amount, transfer amount must be greater than £0\n");
                        Console.WriteLine("\nTo go back to main menu press any key");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (userSendAmount > userAccount.AccountBalance || userSendAmount > 500)
                    {
                        Console.WriteLine("\ntransfer amount cannot exceed account balance or be more than £500\n");
                        Console.WriteLine("\nTo go back to main menu press any key");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        userAccount.AccountBalance -= userSendAmount;
                        AccToSendMoneyTo.AccountBalance += userSendAmount;
                        Console.WriteLine($"\nTransaction complete, £{userSendAmount} sent to {AccToSendMoneyTo.AccountHolderName}\n");
                        Console.WriteLine("\nTo go back to main menu press any key");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("\nError: Account holder's name & number doesn't match. Please try again.\n");
                    Console.WriteLine("\nTo go back to main menu press any key");
                    Console.ReadLine();
                    Console.Clear();
                }
            } else if (userYesOrNo.Equals("n"))
            {
               
                Console.WriteLine("\nTransaction cancelled!\n");
                Console.WriteLine("\nTo go back to main menu press any key");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("\nError: Account holder's name & number doesn't match. Please try again.\n");
                Console.WriteLine("\nTo go back to main menu press any key");
                Console.ReadLine();
                Console.Clear();
            }

        }
    }
}
