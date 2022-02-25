﻿using System;

namespace SupportBank
{
    public class Program
    {
        public static void Main(string[] args)
        {
          var fileReader = new FileReader();
          List<Transaction> transactions = fileReader.GetTransactions("./DodgyTransactions2015.csv");
          var newBank = new SupportBank(transactions);

          foreach (var arg in args)
          {
            if (args[0] != "list")
            {
              return;
            }
            if (args[1] == "all")
            {
              newBank.ListAll();
              return;
            }
            if (args[1] != "all")
            {
              newBank.List(args[1]);
              return;
            }

          }
          // newBank.ListAll();
          // newBank.List("Ben B");
        }
    }
}