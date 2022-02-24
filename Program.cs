﻿using System;

namespace SupportBank
{
    public class Program
    {
        public static void Main(string[] args)
        {
          var fileReader = new FileReader();
          List<Transaction> transactions = fileReader.GetTransactions("./Transactions2014.txt");
          var newBank = new SupportBank(transactions);          
          newBank.ListAll();
          newBank.List("Ben B");
        }
    }
}