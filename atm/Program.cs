using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("******* Welcome to the ATM *******");
        Console.WriteLine("___________________________________");
        Console.WriteLine("");

        string json = File.ReadAllText("CardOwners.json");
        CardHolder[]? cardOwners = JsonSerializer.Deserialize<CardHolder[]>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? Array.Empty<CardHolder>();

        Console.Write("Please enter your PIN: ");
        string? enteredPin = Console.ReadLine();

        if (enteredPin != null)
        {
            CardHolder? ownerDetails = GetOwnerDetails(cardOwners, enteredPin);

            if (ownerDetails != null)
            {
                Console.WriteLine($"Welcome, {ownerDetails.Name}");
                Console.WriteLine($"Card Number: {ownerDetails.CardNumber}");

                bool quit = false;
                while (!quit)
                {
                    try
                    {
                        Console.WriteLine("\nWhat would you like to do?");
                        Console.WriteLine("___________________________________");
                        Console.WriteLine("");
                        Console.WriteLine("1. Make deposit");
                        Console.WriteLine("2. Withdraw money");
                        Console.WriteLine("3. Check balance");
                        Console.WriteLine("4. Change Debit Card Pin");
                        Console.WriteLine("5. Request New Debit Card");
                        Console.WriteLine("6. Quit");
                        Console.WriteLine("___________________________________");

                        Console.Write("Enter your choice: ");
                        string? choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "1":
                                MakeDeposit(ownerDetails);
                                break;

                            case "2":
                                WithdrawMoney(ownerDetails);
                                break;

                            case "3":
                                Console.WriteLine($"Your balance is: {ownerDetails.Balance}");
                                break;

                            case "4":
                                ChangePin(ownerDetails);
                                break;

                            case "5":
                                RequestNewCard(ownerDetails);
                                break;

                            case "6":
                                Console.WriteLine("Thank you. Have a nice day!");
                                quit = true;
                                break;

                            default:
                                Console.WriteLine("Invalid option. Please select a valid menu option.");
                                break;
                        }

                        UpdateCardOwnersFile(cardOwners);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid PIN. Access denied.");
            }
        }
    }

    static void MakeDeposit(CardHolder ownerDetails)
    {
        Console.WriteLine("How much are you depositing?");
        if (double.TryParse(Console.ReadLine(), out double depositAmount) && depositAmount > 0)
        {
            ownerDetails.DepositAmount(depositAmount);
            Console.WriteLine($"Your new balance is: {ownerDetails.Balance}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid positive number.");
        }
    }

    static void WithdrawMoney(CardHolder ownerDetails)
    {
        Console.WriteLine("How much money would you like to withdraw?");
        if (double.TryParse(Console.ReadLine(), out double withdrawAmount))
        {
            ownerDetails.WithdrawAmount(withdrawAmount);
            Console.WriteLine($"Your new balance is: {ownerDetails.Balance}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    static void ChangePin(CardHolder ownerDetails)
    {
        Console.WriteLine($"Please enter a new 4 digit pin number:");
        string? newPin = Console.ReadLine();
        if (newPin != null && newPin.Length == 4)
        {
            ownerDetails.ChangePinNumber(newPin);
            Console.WriteLine("Your pin number has been changed. Please keep it in a safe place.");
        }
        else
        {
            Console.WriteLine("Invalid pin. Please enter a 4 digit number.");
        }
    }

    static void RequestNewCard(CardHolder ownerDetails)
    {
        Console.WriteLine($"Requesting new debit card number...");
        ownerDetails.RequestNewDebitCard();
        Console.WriteLine($"Your new debit card number is: {ownerDetails.CardNumber}");
    }

    static void UpdateCardOwnersFile(CardHolder[] cardOwners)
    {
        string updatedJson = JsonSerializer.Serialize(cardOwners);
        File.WriteAllText("CardOwners.json", updatedJson);
    }

    static CardHolder? GetOwnerDetails(CardHolder[]? cardOwners, string pin)
    {
        if (cardOwners != null)
        {
            return cardOwners.FirstOrDefault(owner => owner?.Pin == pin);
        }
        return null;
    }
}
