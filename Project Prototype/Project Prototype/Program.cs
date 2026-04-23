using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Prototype
{
    internal class Program
    {
        static void Main(string[] args) // Local events venue 
        {
            // display welcome message /

            // login//
            namespace ATMMach
    {
        internal class Program
        {
            static void Main(string[] args) // ATM Machine
            {
                // Business Rules:
                // The ATM Machine will have a welcome screen. The user have to login before able to continue using the ATM.
                // Once login, the user will have 3 options, check balance, withdraw money, and top up mobile credit.
                // There must also be an option to exit the ATM and get back the ATM Card.
                // After user complete each options, they will be able to go back to the main menu.

                // Welcome Screen (DONE)
                welcome_Msg();

                // Login process before they can proceed
                // Get the user PIN number and ATM Card
                Console.WriteLine("Please Insert your ATM Card");

                
                int limit = 3; // control variable
                int mistakeCount = 0; // how many times the user has key in the PIN in correctly

                while (mistakeCount < limit)  // within 3 tries
                {
                    Console.Write("Key in the PIN number: ");
                    // store the PIN number into variable
                    int userPIN = int.Parse(Console.ReadLine()
    
                

                // check the PIN number whether it matches (ASSUME the PIN number is 5688)
                if (userPIN == 5688)
                {  // if login success, provide user with the option they can do
                    Console.WriteLine("PIN IS CORRECT...");

                    int userOption = 0; // create a initial value for the variable to store user option

                    // Repeat showing the menu until the user decide to exit
                    while (userOption <= 4)
                    {
                        option_menu(); // list all the options available
                                       // get the user option and store in a variable
                        userOption = int.Parse(Console.ReadLine());
                        // depending on the option chosen, perform the task
                        if (userOption == 1)
                        { // if the user chose to check balance
                            Console.WriteLine("Checking balance....... to be implemented");
                        }
                        else if (userOption == 2)
                        { // if the user chose to withdraw money
                            Console.WriteLine("Withdraw money ....... to be implemented");
                        }
                        else if (userOption == 3)
                        { // if the user chose to top up mobile credit
                            Console.WriteLine("Top up mobile credit ....... to be implemented");
                        }
                        else if (userOption == 4)
                        { // if the user wants to exit the ATM
                            Console.WriteLine("THANK YOU ... Good Bye");
                            //Environment.Exit(1);
                            break;
                        }
                        else
                        { // any other input apart from the above condition will be categorise here
                            Console.WriteLine("Invalid option!!!");
                        }
                    } // closing while

                }// if ( userPIN == 5688 )
                else
                {  // if login fail, display error msg, then exit the system and take away the ATM card
                    Console.WriteLine("Invalid PIN number...");
                }



                Console.WriteLine("\n\nPress any key to exit...");
                Console.ReadKey();

            } // closing MAIN  (built-in to have Environment.Exit(1); to exit the application entirely)

            // function to display welcome message
            static void welcome_Msg()
            {
                Console.WriteLine("========================");
                Console.WriteLine("==    ^^ ATM ^^       ==");
                Console.WriteLine("==       MACHINE      ==");
                Console.WriteLine("========================");
            } // closing welcome_Msg()

            // function to display the options
            static void option_menu()
            {
                Console.WriteLine("[1] Check Balance");
                Console.WriteLine("[2] Withdraw Money");
                Console.WriteLine("[3] Top Up Mobile Credit");
                Console.WriteLine("[4] Exit the ATM and get back my card");
                Console.Write("Enter your choice: ");
            }

        } // closing PROGRAM
    } // closing ATMACH


}
    }
}
