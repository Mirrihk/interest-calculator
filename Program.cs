// This is a program that can calculate simple and compound interest.
// For compound interest this program will also display an amortization table.
// This can be used to determine the costs of simple interest loans like a car loan or a mortgage.
// It can also be used to see how long it would take to pay of a credit card or student loan.
// We can also use the compound interest calculator to see how much interest we would earn on a savings / invenstment account.

using System;

namespace Interest_Calculators
{
    // Structure to define variables used in both simple and compound interest calculations
    struct BasicInput 
    {
        public double principal, rate, interest, total;
    }

    // Main program class
    class Program 
    {
        static void Main(string[] args)
        {
            int selection;  // Variable to store user input of menu selection

            // Title and welcome message
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Welcome to my interest calculator!");
            Console.WriteLine("----------------------------------");
            Console.ResetColor();

            do
            {
                // Menu to select simple or compound interest calaculator
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Please select an option from the menu below:");
                Console.WriteLine();
                Console.WriteLine("1. Simple Interest");
                Console.WriteLine("2. Compound Interest");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                Console.ResetColor();

                // User selection
                Console.Write("Enter your selection: ");
                selection = Convert.ToInt32(Console.ReadLine());

                if (selection == 1) // Simple Interest calculator
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("You have selected Simple Interest");
                    Console.WriteLine();
                    Console.ResetColor();

                    // Variables for simple interest calculator
                    int months;
                    double payment;

                    // Link to Structure
                    BasicInput userinput; 

                    // Ask for information about the loan
                    Console.Write("Enter the amount you are borrowing: $ "); 
                        userinput.principal = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the interest rate: ");
                        userinput.rate = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the number of months you are borrowing for: ");
                        months = Convert.ToInt32(Console.ReadLine());

                    // Calculate the interest, total amount to be paid, and payments
                    userinput.interest = userinput.principal * (userinput.rate / 100);
                    userinput.total = userinput.principal + userinput.interest;
                    payment = userinput.total / months;

                    // Display the results
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine();
                    Console.WriteLine($"The total interest is: $ {userinput.interest:N2}");
                    Console.WriteLine($"The total amount you will pay is: $ {userinput.total:N2}");
                    Console.WriteLine($"The monthly payment is: $ {payment:N2}");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.Write("Press Enter to continue");
                }

                else if (selection == 2) // Compound Interest calculator
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have selected Compound Interest");
                    Console.WriteLine();
                    Console.ResetColor();

                    // Variables for compound interest calculator
                    int years, periods;

                    // Link to Structure
                    BasicInput userinput; 

                    // Ask for information about the loan or investment
                    Console.Write("Enter the initial amount: $ ");
                        userinput.principal = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the interest rate: ");
                        userinput.rate = Convert.ToDouble(Console.ReadLine()) / 100;
                    Console.Write("Enter the number of years: ");
                        years = Convert.ToInt32(Console.ReadLine());
                    Console.Write("How many times is interest calculated per year? ");
                        periods = Convert.ToInt32(Console.ReadLine());

                    // Calculate the interest and total amount to be paid
                    userinput.total = userinput.principal * Math.Pow((1 + (userinput.rate / periods)), (periods * years));
                    userinput.interest = userinput.total - userinput.principal;

                    // Display the results
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine();
                    Console.WriteLine($"The total interest is: $ {userinput.interest:N2}");
                    Console.WriteLine($"The new value is: $ {userinput.total:N2}");
                    Console.WriteLine();
                    
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Amortization Table");
                    Console.ResetColor();

                    // Display the amortization table year by year by looping through the calculation
                    for (int i = 1; i <= years; i++) 
                        {
                            userinput.total = userinput.principal * Math.Pow((1 + (userinput.rate / periods)), (periods * i));
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine($"The total after year {i} is: $ {userinput.total:N2}");
                            Console.ResetColor();
                        }
    
                    Console.Write("Press Enter to continue");
                }

                else if (selection == 3) // Exit program
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine();
                    Console.WriteLine("Thank you for using my interest calculator!");
                    Console.WriteLine();
                    Console.ResetColor();
                    Environment.Exit(0);
                }

                else // Invalid selection error control
                {
                    Console.WriteLine("Invalid selection, please try again.");
                }

                Console.ReadLine();
                
            } while (selection != 3);
        }
    }
}
