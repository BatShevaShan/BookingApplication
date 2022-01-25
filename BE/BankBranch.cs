using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public struct BankBranch
    {//describe bank account
        public long BankBranchKey;
        public string BankName;
        public int BranchNumber;
        public string BranchAddress;
        public string BranchCity;
        public long BankNumber;
        //public long BankAccountNumber { set; get; }
        public override string ToString()
        {//the tostring enturns the variables and their data
            return "BankAccount [BankName-" + BankName + ",BranchNumber-" + BranchNumber + ",BranchAddress-" + BranchAddress + ",BranchCity-"+ BranchCity + ",BankNumber-" + BankNumber + "]";
        }
    }
}

