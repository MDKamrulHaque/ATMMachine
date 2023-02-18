using ATMMachine;
using System.Reflection.Metadata;

ListOfAllAccounts accountList = new ListOfAllAccounts();

string exit = "EXIT";
string withDraw = "WITHDRAW";
string deposit = "DEPOSIT";
string viewBalance = "BALANCE";
string transfer = "TRANSFER";
string logOut = "LOGOUT";

string userInput = "";
int maxAttempts = 3;


for (int i = 1; i<=maxAttempts; i++)
    {
        try
        {
            Console.WriteLine("\nWelcome to Super ATM Service?");
            Console.WriteLine("\nPlease Verify your details");
            Console.WriteLine("\nEnter account number (or type 'EXIT' to quit):\n");
            userInput = Console.ReadLine();
              
            if (userInput.ToLower() == exit.ToLower())
            {
                break;
            }

            int userInputAccNum = Convert.ToInt32(userInput);

            Console.WriteLine("\nPlease enter your pin:\n");
            int userInputAccPin = Convert.ToInt32(Console.ReadLine());

            Account userAccount = accountList.accounts.FirstOrDefault(a => a.AccountNumber == userInputAccNum && a.AccountPin == userInputAccPin);

            if (userAccount != null)
            {
                Console.Clear();
                string userSelectionMenuTwo = null;
                Console.WriteLine($"\nWelcome {userAccount.AccountHolderName}, Hope your having a wonderful day! (>_<)\n");
                do
                {
                    Console.WriteLine($"\nPlease make a selection\n");
                    Console.WriteLine($"\n******************************************");
                    Console.WriteLine($"*  type 'Deposit'  to deposit money      *");
                    Console.WriteLine($"*  type 'Withdraw' to take out money     *");
                    Console.WriteLine($"*  type 'Transfer' to send moeny         *");
                    Console.WriteLine($"*  type 'Balance'  to see your balance   *");
                    Console.WriteLine($"*  type 'Logout'   to go logout          *");
                    Console.WriteLine($"******************************************\n");

                    string userSelectionMenu = Console.ReadLine();

                    try
                    {
                        if (userSelectionMenu.Equals(withDraw, StringComparison.OrdinalIgnoreCase))
                        {
                            Functions.WithDrawMoney(userAccount);
                        }
                        else if (userSelectionMenu.Equals(deposit, StringComparison.OrdinalIgnoreCase))
                        {
                            Functions.DepositMoney(userAccount);
                        }
                        else if (userSelectionMenu.Equals(viewBalance, StringComparison.OrdinalIgnoreCase))
                        {
                            Functions.ViewBalance(userAccount);
                        }
                        else if (userSelectionMenu.Equals(transfer, StringComparison.OrdinalIgnoreCase))
                        {
                            Functions.TransferMoney(userAccount, accountList);
                        }
                        else if (userSelectionMenu.Equals(logOut, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\ninvalid selection! please try again\n");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.Clear();
                        Console.WriteLine("\ninvalid, use numbers\n");
                    }

                } while (userSelectionMenuTwo != logOut);
            }
            else
            {
                if (i == maxAttempts)
                {
                    Console.Clear();
                    Console.WriteLine("\nprocess terminated due to failing to verify account details:\n");
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"\nInvalid account number or pin. Please try again");
                    Console.WriteLine($"\nYou {maxAttempts - i} more attempt(s) left or process will be terminated\n");
                }
            }
        }
        catch (FormatException)
        {
                if (i == maxAttempts)
                {
                    Console.Clear();
                    Console.WriteLine("\nprocess terminated due to failing to verify account details:\n");
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nError: Account Number & Pin must in forms of numeric values \n");
                    Console.WriteLine($"\nYou {maxAttempts - i} more attempt(s) left or process will be terminated\n");
                }      
        }
    }
    
