using System;
using System.Transactions;

namespace Classes; // The namespace declaration provides a way to logically organize the code

public class BankAccount // Defines the class, or type. There are 5 members on this class
{
    //Static fields start with s_ prefix / That is a member declaration
    private static int s_accountNumberSeed = 1234567890; // It's private, which means it can only be accessed by code inside the BankAccount class. It is also static, which means it's shared by all objects in the class.
    private List<Transaction> _allTransactions = new List<Transaction>();
    // Those are properties
    public string Number { get; } 
	public string Owner { get; set; }
	public decimal Balance 
	{
		get
		{
			decimal balance = 0;
			foreach (var item in _allTransactions)
			{
				balance += item.Amount;
			}

			return balance;
		}
	}
	

	// Define constructor that assigned values - Constructor is a member that has the same name as the class. It is used to initialize objects of that class type.
	public BankAccount(string name, decimal initialBalance)
	{
		//this.Owner = name;
        //this.Balance = initialBalance; // The "this" qualifier is only required when a local variable or parameter has the same name as the field or property
        //Number = s_accountNumberSeed.ToString();
        //s_accountNumberSeed++;
		Number = s_accountNumberSeed.ToString();
		s_accountNumberSeed++;

		Owner = name;
		MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }

	// The below are methods
	public void MakeDeposit( decimal amount, DateTime date, string note )
	{
		if ( amount <= 0 )
		{
			throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
		}
		var deposit = new Transaction(amount, date, note);
		_allTransactions.Add( deposit );
	}

	public void MakeWithdrawal(decimal amount, DateTime date, string note)
	{
		if ( amount <= 0 )
		{
			throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawl must be positive");
		}
		if (Balance - amount < 0 )
		{
			throw new InvalidOperationException("Not sufficient funds for this withdrawl");
		}
		var withdrawal = new Transaction(-amount, date, note);
		_allTransactions.Add( withdrawal );
	}
	public string GetAccountHistory()
	{
		var report = new System.Text.StringBuilder();

		decimal balance = 0;
		report.AppendLine("Date\t\tAmount\tBalance\tNote");
		foreach ( var item in _allTransactions )
		{
			balance += item.Amount;
			report.AppendLine($"{item.Date.ToShortDateString()}\t{balance}\t{item.Notes}");
		}

		return report.ToString();
	}
}
