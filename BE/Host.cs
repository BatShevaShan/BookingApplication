using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public struct Host
    {
        public long HostKey { set; get; }
        public string PrivateName { set; get; }
        public string FamilyName { set; get; }
        public long FhoneNumber { set; get; }
        public string MailAddress { set; get; }
        public BankBranch BankBranchDetails;
        public long BankAccountNumber { set; get; }
        
        public override string ToString()
        {//the tostring enturns the variables and their data
            return "Host [PrivateName-" + PrivateName + ",FamilyName-" + FamilyName + ",FhoneNumber-" + FhoneNumber + ",MailAddress-" + MailAddress + ",BankBranchDetails-" + BankBranchDetails.ToString() + ",BankAccountNumber-" + BankAccountNumber + "]";
        }
    }
}
