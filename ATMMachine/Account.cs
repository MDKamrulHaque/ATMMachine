﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMMachine
{
    internal class Account
    {

        public string AccountHolderName { get; set; }
        public int AccountNumber { get; set; }
        public int AccountPin { get; set; }
        public decimal AccountBalance { get; set; }

    }

}