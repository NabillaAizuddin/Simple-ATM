using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public class cardHolder
{
    // what is this -- define what function for your ATM
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    // put under cardHolder
    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getCardNUm()
    {
        return cardNum;
    }

    public int getPin() 
    {   
        return pin; 
    } 

    public string getFirstName() 
    {   
        return firstName;
    }

    public string getLastName() 
    {  
        return lastName;    
    }

    public double getBalance() 
    { 
        return balance;
    }

    // end of defining functions

    public void getFirstName(string newFirstName) 
    {
        firstName = newFirstName;
    }

    public void getLastName(string newLastName) 
    {
        lastName = newLastName;
    }

    public void setBalance(double newbalance)
    {
        balance = newbalance;
    }

    //Main 
    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options..");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw ");
            Console.WriteLine("3. Show balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit");
            double Deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(Deposit + newBalance);
            Console.WriteLine("Thank you for your deposit. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw:  ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //check if user ave enough money
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance");
            } 
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You're good to go. Thank you");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1381298343943897", 1234, "John", "Kennedy", 3000));
        cardHolders.Add(new cardHolder("3829389473894934", 3324, "Lisa", "Lamma", 2000));
        cardHolders.Add(new cardHolder("3092489348392840", 2049, "firj", "fuji", 1123));
        cardHolders.Add(new cardHolder("1219389892348293", 3312, "rena", "kamer", 112.50));

        // Prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card:  ");
        string debitCardNum = "";
        cardHolder CurrentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check agains our database
                CurrentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (CurrentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again");  }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());//check agains our database
                if (CurrentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrrect pin. Please try again. "); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again"); }
        }

        Console.WriteLine("Welcome " + CurrentUser.getFirstName() + " !");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine()); 
            }
            catch { }
            if(option == 1) { deposit(CurrentUser);  }
            else if(option == 2) { withdraw(CurrentUser); }
            else if(option == 3) { balance(CurrentUser); }
            else if(option == 4) { break; }
            else { option = 0; }
        } 
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day.");
    }

 }

    
