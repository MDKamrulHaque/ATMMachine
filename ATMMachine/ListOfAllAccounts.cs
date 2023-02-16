using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMMachine
{
    internal class ListOfAllAccounts
    {
     public List<Account> accounts = new List<Account>()
       {
            new Account(){AccountHolderName = "UserOne", AccountNumber = 12345, AccountPin = 1212, AccountBalance= 4500},
            new Account(){AccountHolderName = "UserTwo", AccountNumber = 26789, AccountPin = 1313, AccountBalance= 500},
            new Account(){AccountHolderName = "UserThree", AccountNumber = 31011, AccountPin = 1414, AccountBalance= 1500},
            new Account(){AccountHolderName = "UserFour", AccountNumber = 41213, AccountPin = 1515, AccountBalance= 3500}
             
       };
    }
}
