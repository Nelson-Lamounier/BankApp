using System;

namespace Classes; // The namespace declaration provides a way to logically organize the code

public class BankAccount // Defines the class, or type. There are 5 members on this class
{
    //Static fields start with s_ prefix / That is a member declaration
    private static int s_accountNumberSeed = 1234567890; // It's private, which means it can only be accessed by code inside the BankAccount class. It is also static, which means it's shared by all objects in the class.
    // Those are properties
    public string Number { get; } 
	public string Owner { get; set; }
	public decimal Balance { get; }

	// Define constructor that assigned values - Constructor is a member that has the same name as the class. It is used to initialize objects of that class type.
	public BankAccount(string name, decimal initialBalance)
	{
		this.Owner = name;
		this.Balance = initialBalance; // The "this" qualifier is only required when a local variable or parameter has the same name as the field or property
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
    }

	// The below are methods
	public void MakeDeposit( decimal amount, DateTime date, string note )
	{
	}

	public void MakeWithdrawal(decimal amount, DateTime date, string note)
	{

	}	
}
