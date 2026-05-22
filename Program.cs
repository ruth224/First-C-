using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project_Prototype
{
    internal class Program
    {
        static void Main(string[] args) // Yard Venue Management system 
        {
            // Task:
            // The Yard is a multi-purpose office and events venue in Manchester,
            // they would like to run more evening events and are commissioning a system which digitises some of their currently manual tasks.
            // You will create a console prototype using C# which implements the essential and desirable features listed below. 

            // Welcome Screen using a function 
            welcome_Msg();


            // Login process before they can proceed
            if (!CustomerLogin())
            {
                // changes the background colour to red when the user's access is denied 
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("\nAccess Denied. Exiting...");
                Console.WriteLine("Press any key to exit...");
                // makes the program wait until a button is pressed before the program exits 
                Console.ReadKey();
                // Used to stop here and give the value back to the system to exit 
                return;

            }

            int userOption = 0; // create a initial value for the variable to store user option 1-6

            // Repeat showing the menu until the user decide to exit
            // Used a nested while loop (pre-defined) continues until the statement is FALSE or the user exits 
            while (userOption != 6)
            {
                
                option_menu(); // list all the options available
                               // get the user option and store in a variable
                               // "int.Parse", converts the variable string into an integer so they are able to choose
                               // "Console.ReadLine", allows the user to input the numerical choices another way is "Console.Write"
                userOption = int.Parse(Console.ReadLine());
                // depending on the option chosen, perform the task
                if (userOption == 1)
                { // if the user selects cost of venue per person (DF1)
                 // "Console.Clear", this clears the code above and brings up the code below
                    Console.Clear();
                    CalculateBookingCost();
                }
                else if (userOption == 2)
                { // if the user chose to register attendance
                    Console.Clear();
                    Registration();
                    Console.WriteLine("Please register attendance");

                }
                else if (userOption == 3)
                { // if the user chooses to visit Yard's website 
                    Console.Clear();
                    Website();
                    Console.WriteLine("Here is a link to our website");
                }
                else if (userOption == 4)
                { // if the user chose to view attendance monitoring
                    Console.Clear();
                    Attendancemonitor();
                    Console.WriteLine("Attendance monitoring");
                }
                else if (userOption == 5)
                { // if the user chose to report an incident 
                    Console.Clear();
                    IncidentReport();
                    Console.WriteLine("Incident report");

                }
                else if (userOption == 6)
                { // if the user wants to exit the Venue system
                    Console.WriteLine("THANK YOU ... GoodBye");
                    //Environment.Exit(1);
                    // stops the program and closes it once the user select that option
                    break;
                }
                else
                { // any other input apart from the above condition will be categorise here
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option!!!");
                }
            } // closing while
            // prints the systems use 
            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();

        } // closing MAIN  (built-in to have Environment.Exit(1); to exit the application entirely)


        // Function for Attendance monitoring DF2 
        // "Static void", helps to execute the code, nothing can exist in it until the code is inputted 
        static void Attendancemonitor()
        {
            // Display the status
            // A variable to to show the current number of customers in the venue
            // Plus the max capcity of the venue 
            int current = 0;
            int max = 300;

            // A while loop 
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n========== ATTENDANCE MONITOR ==========");
                // Description to add to the current and max capacity of the venue 
                Console.WriteLine("Current: " + current + "/" + max);
                Console.WriteLine("Type '+' to add, '-' to remove, or ';' to quit");

                // Allows user to input into the variable store 
                string input = Console.ReadLine();

                // If user/ receptionist has added the capicity of the customers uses that input to exit back to main menu 
                if (input == ";") break;
                
                // Converts the user input into an interger/ whole number 
                // "Out int" is used to add to the original variable helping to trigger the "current" variable to change when the "number" is added
                if (int.TryParse(input, out int number))
                {
                    // Reassigns the number to add to the current capcity
                    current = current + number;

                    // This blocks the current number from going below 0 or above max (300)
                    if (current < 0)
                        current = 0;
                    if (current > max)
                        current = max;
                }
                else
                {
                    // If not within the constraints gives an invalid output 
                    Console.WriteLine("Invalid input!");
                }
            }

            // Closes the monitor after exit 
            Console.WriteLine(" Attendance monitor closed.");
        }

        // Function for users to write an incident report 
        static void IncidentReport()
        {
            Console.WriteLine("\n=== INCIDENT REPORT LOG ===");
            Console.WriteLine("Severity (minor or major):");
            // Allows the user to input the severity of the incident 
            string severity = Console.ReadLine();

            Console.WriteLine("Describe the incident:");
            // Allows the user to input a description of the situation 
            string message = Console.ReadLine();
            
            // Converts the users date and time that the incident was reported 
            string time = DateTime.Now.ToString();

            // Collects the data stored from the three variable in a "report" variable 
            // "\n", puts the code on a new line 
            string report = "Time: " + time + "\n" +
                            "Severity: " + severity + "\n" +
                            "Details: " + message;
            // The details of the variable is relayed for the user/ customer to see
            Console.WriteLine($"{report}");
            
            // The data saved in a file 
            // Data is closed after going back to the main menu
            File.WriteAllText("incident.txt", report);
            Console.WriteLine("Incident saved to incident.txt");


        }

        // Function for attendee registration DF4

        static void Registration()
        {
            // learnt from linkedin learning C# course 
            // Makes it possible to add new attendees 
            
            // This string uses a list parameter to store names 
            List<string> names = new List<string>();
            
            // stores the users phone numbers 
            List<string> phones = new List<string>();
            
            // stores the users ages 
            List<int> ages = new List<int>();

            // only runs if components are true (undefined nested loop)
            while (true)
            {
                // Gives user 3 options when registering 
                Console.Clear();
                Console.WriteLine("========== REGISTRATION ==========");
                Console.WriteLine("[1] Add attendee");
                Console.WriteLine("[2] Display attendees");
                Console.WriteLine("[3] Exit");
                Console.Write("Choice: ");

                string choice = Console.ReadLine();

                // User must input Name, Phone number & Age 
                if (choice == "1")
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Phone (11 digits): ");
                    string phone = Console.ReadLine();
                  

                    Console.Write("Age: ");
                    int age = int.Parse(Console.ReadLine());

                    // The list links the string to the variable for the user/ receptionist to add new attendees
                    names.Add(name);
                    phones.Add(phone);
                    ages.Add(age);

                    // Shows the full information to be seen clearly before being saved/ stored in the variable 
                    Console.WriteLine("\n================================");
                    Console.WriteLine("DETAILS");
                    Console.WriteLine($"Name: {name}");
                    Console.WriteLine($"Phone: {phone}");
                    Console.WriteLine($"Age: {age}");
                    Console.WriteLine(" You are officially registered!");
                    Console.WriteLine("================================");
                    Console.ReadKey();
                }
                else if (choice == "2")
                {
                    // Shows a list of the attendees that have registered with their full detail
                    Console.Clear();
                    Console.WriteLine("========== ATTENDEES ==========\n");

                    // Decision statement "if" there are no customers in attendance yet 
                    if (names.Count == 0)
                    {
                        Console.WriteLine("No attendees registered yet.");
                    }
                    else
                    {
                        // For loop, keeps going until the iteration stops 
                        // Starts from 0 "int i = 0", displaying the first person e.g. names [0]
                        // Goes through every person in the list until there is none left " i < names.Count; i++"
                        
                        for (int i = 0; i < names.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. Name: {names[i]}");
                            Console.WriteLine($"   Phone: {phones[i]}");
                            Console.WriteLine($"   Age: {ages[i]}\n");
                        }
                    }

                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                }
                else if (choice == "3")
                {
                    // Stops adding to the attendees
                    break;
                }
            }
        }


        // Function for users to follow the URL DF3
        static void Website()
        {
            // 3 options for the user to choose from 
            Console.WriteLine("\n========== WEBSITE & SEARCH ==========");
            Console.WriteLine("[1] Open Venue Website");
            Console.WriteLine("[2] Google Search");
            Console.WriteLine("[3] Exit");
            Console.Write("Enter your choice: ");
            
            // Creates a variable for the user to input the 3 numbers 
            string choice = Console.ReadLine();

            // Goes to Yard's company website 
            if (choice == "1")
            {// Opens the company website directing the URL
                System.Diagnostics.Process.Start("https://theyardmcr.com/");
                Console.WriteLine(" Opening website...");
            }

            // Allows the user to search for it to be shown in the web browser 
            else if (choice == "2")
            {
                Console.Write("Search for: ");
                string search = Console.ReadLine();
                // Opens Google for the inputted search to be translated in the web browser 
                System.Diagnostics.Process.Start("https://www.google.com/search?q=" + search);
                Console.WriteLine(" Searching...");
            }
            // Exits the section back to main menu 
            else if (choice == "3")
            {
                Console.WriteLine(" Exiting...");
            }
            else
            {
                // Gives a number not listed and tries again 
                Console.WriteLine(" Invalid choice.... Try again");
            }
        }




        // Function to calculate booking cost with adults and children (DF1)
        // Using Decsions (if/else)  
        static void CalculateBookingCost()
        // "M" stands for a decimal values 
        // " Const decimal", creates a fixed value that the output should be in decimal form 
        {
            // Child and adult pricing 
            const decimal CHILD_PRICE = 7.50m;
            const decimal ADULT_PRICE = 12.00m;
            const decimal TWO_FOR_ONE = 12.00m;

            // Booking calculator 
            Console.WriteLine("\n=== BOOKING COST CALCULATOR ===");
            Console.WriteLine("\n You can get a 2 for 1 deal, for adults");

            // Gets the number of adults
            Console.Write("How many adults? ");

            // creates a variable for the number of adults 
            int adults = int.Parse(Console.ReadLine());
            // variable for overall adult price
            decimal adultTotal;
            
            // if the number of adults equals 2 then they qualify for a discount 
            if (adults >= 2)
            {
                Console.WriteLine("You can get a 2 for 1 deal, for adults");
                Console.WriteLine($"Two for the price of one £{TWO_FOR_ONE}");

                // Creates a "pairs" variable that divides the pricing of 2 adults 
                int pairs = adults / 2;
                // The "leftover" variable gives the remainder through modulus 
                int leftover = adults % 2;
                // times the 2 for 1 and adds it the left over and price to get the overall total 
                //  e.g ( 2 * 12) + (1 * 12) = £36.00
                adultTotal = (pairs * TWO_FOR_ONE) + (leftover * ADULT_PRICE);
            }
            
            else
            {
                // They recieve the normal price 
                // £12.00 x 2 
                adultTotal = adults * ADULT_PRICE;
            }

            // Gets the number of children
            Console.Write("How many children? ");
            int children = int.Parse(Console.ReadLine());

            // Calculate costs of both children & adults 
            decimal childTotal = children * CHILD_PRICE;
            decimal overallTotal = adultTotal + childTotal;

            // Displays a total cost break downbreakdown
            Console.WriteLine("\n--- Total cost ---");
            // if the adults are 2 they qualify for the 2 for 1 deal 
            if (adults == 2)
            {
                // "$" used to input the variable into the sentence 
                // "F2" shows how many decimal places are wanted after the interger, "F2" are 2 decimal places 
                // 2 for 1 deal price
                Console.WriteLine($"Adults ({adults}) with 2 for 1 deal = £{adultTotal:F2}");
            }
            else
            {
                // Without the 2 for 1 deal 
                Console.WriteLine($"Adults ({adults}) x £{ADULT_PRICE} = £{adultTotal:F2}");
            }
            Console.WriteLine($"Children ({children}) x £{CHILD_PRICE} = £{childTotal:F2}");
            Console.WriteLine($"---");
            // Showss complete total 
            Console.WriteLine($"TOTAL: £{overallTotal:F2}");
            Console.WriteLine("======================\n");
        }

        // Function for customer login with name and password (EF3)
        static bool CustomerLogin()
        {
            // predefined variables for the username and password 
            string validUsername = "admin";
            string validPassword = "pw";

            int limit = 3; //Gives the user maximum login attempts
            int mistakeCount = 0; // counting up to 3 attempts 

            // "Limit" is bigger than "mistakecount" 
            while (mistakeCount < limit)
            {
                Console.WriteLine("\n=== CUSTOMER LOGIN ===");
                // Enters username 
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();

                // Enters password 
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                // Verify credentials
                // The password is "pw" and username is "admin"
                if (username == validUsername && password == validPassword)
                {
                    // If correct changes the words to green 
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n LOGIN SUCCESSFUL");
                    Console.WriteLine($"Welcome, {username}!\n");
                    // Allows the useer acces to the main menu
                    return true;
                }
                else
                {
                    // If incorrect changes words to red when surpassed "mistakecount"
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    mistakeCount++;
                    Console.WriteLine($"\n INVALID ");
                    // Outputs the attempts used 
                    Console.WriteLine($"Attempt {mistakeCount} of {limit}");

                    if (mistakeCount < limit)
                    {
                        // Outputs the attempts remaining 
                        Console.WriteLine($"You have {limit - mistakeCount} attempts remaining.\n");
                    }
                }
            }
            // Users no longer has any attempts left 
            Console.WriteLine("\n LOGIN FAILED - You have exceeded the maximum login attempts.");
            // Blocks user access to main menu 
            return false;
            // Exits program 
        }

        // function to display welcome message ( EF1)
        static void welcome_Msg()
        {
            // Displays the company system message 
            Console.WriteLine("========================");
            Console.WriteLine("==    YARD VENUE  ^==");
            Console.WriteLine("== MANAGEMENT SYSTEM  ==");
            Console.WriteLine("========================");
        } // closing welcome_Msg()

        // function to display the options (EF2)
        static void option_menu()
        {
            // Gives user instructions of what to do in the program 
            // 5 different function listed for the the user to input 
            Console.WriteLine(" Welcome to the Main menu :) \n");
            Console.WriteLine(" Please select the following \n");

            Console.WriteLine("[1] Cost");
            Console.WriteLine("[2] Registration ");
            Console.WriteLine("[3] Vist Our Website ");
            Console.WriteLine("[4] Attendance Monitoring ");
            Console.WriteLine("[5] Incident Report");
            Console.WriteLine("[6] Exit ");
            Console.Write("Enter your choice: ");
        }



    } // closing PROGRAM
} // closing namespace Project_Prototype

