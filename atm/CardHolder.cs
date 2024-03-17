using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class CardHolder
{
    public string Pin { get; private set; }
    public string Name { get; private set; }
    public string CardNumber { get; private set; }
    public double Balance { get; private set; }

    public CardHolder(string pin, string name, string cardNumber, double balance)
    {
        Pin = pin;
        Name = name;
        CardNumber = cardNumber;
        Balance = balance;
    }

    public void DepositAmount(double amount)
    {
        if (amount > 0)
            Balance += amount;
        else
            throw new InvalidOperationException("Deposit amount must be positive.");
    }

    public void WithdrawAmount(double amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
        }
        else
        {
            throw new InvalidOperationException("Insufficient balance");
        }
    }

    public void ChangePinNumber(string newPin)
    {
        Pin = newPin;
    }

    public void RequestNewDebitCard()
    {
        Random rand = new Random();
        long newCardNumber = (long)(rand.NextDouble() * 9000000000000000) + 1000000000000000;
        CardNumber = newCardNumber.ToString();
    }
}
