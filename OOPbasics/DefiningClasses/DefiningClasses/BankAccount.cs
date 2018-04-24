
using System;

public class BankAccount
{
    private int id;
    private double balance;
    private string name;
    public int ID
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
    public double Balance
    {
        get { return this.balance; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Amount cannot be less then 0");
            }
            this.balance = value;
        }
    }
    public void Deposit(double amount)
    {
        this.Balance += amount;
    }
    public void Withdraw(double amount)
    {
        this.Balance -= amount;
    }

    public override string ToString()
    {
        return $"Account ID{this.id}, balance {this.balance:f2}";
    }
}


