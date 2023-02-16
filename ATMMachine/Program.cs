using ATMMachine;
using System.Reflection.Metadata;

ListOfAllAccounts accountList = new ListOfAllAccounts();

string exit = "EXIT";
string withDraw = "WITHDRAW";
string deposit = "DEPOSIT";
string viewBalance = "BALANCE";


string userInput = "";

do
{
    Console.WriteLine("Please Verify your details");
    Console.WriteLine("\nPlease enter account number (or type 'exit' to quit):\n");
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
        Console.WriteLine($"\nWelcome {userAccount.AccountHolderName}\n");
        Console.WriteLine("Please Select what you would like to do");

        string userSelectionMenu = Console.ReadLine();

        if(userSelectionMenu.Equals(withDraw))
        {
            Functions.WithDrawMoney(withDraw, userAccount);

        }else if (userSelectionMenu.Equals(deposit))
        {
            Functions.DepositMoney(deposit, userAccount);

        } else if (userSelectionMenu.Equals(viewBalance))
        {
            Functions.ViewBalance(viewBalance, userAccount);
        }

    }
    else
    {
        Console.WriteLine("Invalid account number or pin. Please try again.");
    }

} while (userInput != exit);