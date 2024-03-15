using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json; 

class AddressBook
{
    public string Name { get; set; } = string.Empty; 
    public string PhoneNumber { get; set; } = string.Empty; 
    public string EmailAddress { get; set; } = string.Empty; 

    public string? UpdateContactsOption(string field) 
    {
        Console.Write($"Enter new {field} (Press Enter to skip): ");
        string? userOption = Console.ReadLine();
        return string.IsNullOrEmpty(userOption) ? null : userOption;
    }

    public bool DeleteContactOption()
    {
        Console.Write("Confirm contact deletion (Y/N): ");
        return Console.ReadLine()?.Trim().ToLower() == "y"; 
    }
}

class ContactList
{
    private List<AddressBook> contacts;

    public ContactList()
    {
        contacts = new List<AddressBook>();
    }

    public void AddContact()
    {
        Console.Write("Please enter your full name: ");
        string name = Console.ReadLine()?.Trim() ?? ""; 
        Console.Write("Please enter your phone number: ");
        string phoneNumber = Console.ReadLine()?.Trim() ?? ""; 
        Console.Write("Please enter your email address: ");
        string emailAddress = Console.ReadLine()?.Trim() ?? ""; 

        AddressBook contact = new AddressBook { Name = name, PhoneNumber = phoneNumber, EmailAddress = emailAddress };
        contacts.Add(contact);
        SaveContacts();
    }

    public void SearchContact()
    {
        Console.Write("Enter the contact name to search: ");
        string name = Console.ReadLine()?.Trim().ToUpper() ?? ""; 
        var foundContacts = contacts.Where(contact => contact.Name.ToUpper() == name).ToList();

        if (foundContacts.Any())
        {
            foreach (var contact in foundContacts)
            {
                Console.WriteLine($"Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.EmailAddress}");
            }
        }
        else
        {
            Console.WriteLine("Please check the entered name and try again.");
        }
    }

    public void ViewContacts()
    {
        foreach (var contact in contacts)
        {
            Console.WriteLine($"Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.EmailAddress}");
        }
    }

    public void UpdateContacts()
    {
        Console.Write("Enter the contact name to update: ");
        string name = Console.ReadLine()?.Trim().ToUpper() ?? ""; 
        var foundContact = contacts.FirstOrDefault(contact => contact.Name.ToUpper() == name);

        if (foundContact != null)
        {
            string? phoneNumber = foundContact.UpdateContactsOption("phone number"); 
            string? emailAddress = foundContact.UpdateContactsOption("email address"); 

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                foundContact.PhoneNumber = phoneNumber!;
            }
            if (!string.IsNullOrEmpty(emailAddress))
            {
                foundContact.EmailAddress = emailAddress!;
            }

            SaveContacts();
            Console.WriteLine("Contact has been updated successfully");
        }
        else
        {
            Console.WriteLine("Please check the entered name and try again.");
        }
    }

    public void DeleteContact()
    {
        Console.Write("Please enter the contact to delete: ");
        string name = Console.ReadLine()?.Trim().ToUpper() ?? ""; 
        var foundContact = contacts.FirstOrDefault(contact => contact.Name.ToUpper() == name);

        if (foundContact != null)
        {
            if (foundContact.DeleteContactOption())
            {
                contacts.Remove(foundContact);
                SaveContacts();
                Console.WriteLine("The contact has been successfully deleted.");
            }
            else
            {
                Console.WriteLine("The deletion of the contact has been cancelled.");
            }
        }
        else
        {
            Console.WriteLine("Please check the entered name and try again.");
        }
    }

    public void SaveContacts()
    {
        // Serialize contacts list to JSON
        string json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText("contact_list.json", json);
    }

    public void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("\n********** Welcome to Address Book **********");
            Console.WriteLine("_____________________________________________");
            Console.WriteLine();
            Console.WriteLine("1. Add contact\n2. View list of contacts\n3. Search for contacts\n" +
                              "4. Update contacts\n5. Delete contacts\n6. Exit");
            Console.WriteLine("_____________________________________________");
            Console.WriteLine();
            Console.Write("Select an option: ");
            string menuOption = Console.ReadLine()?.Trim().ToLower() ?? ""; 

            switch (menuOption)
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    ViewContacts();
                    break;
                case "3":
                    SearchContact();
                    break;
                case "4":
                    UpdateContacts();
                    break;
                case "5":
                    DeleteContact();
                    break;
                case "6":
                    Console.WriteLine("Exiting. Thank you for using our Address Book!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ContactList contactList = new ContactList();
        contactList.MainMenu();
    }
}
