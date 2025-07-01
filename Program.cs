using System;

namespace InterestCalculators
{
    struct BasicInput
    {
        public double principal, rate, interest, total;
    }

    class Program
    {
        static void Main(string[] args)
        {
            int selection;

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("📈 Welcome to the Interest Calculator 📉");
            Console.WriteLine("----------------------------------------");
            Console.ResetColor();

            do
            {
                DisplayMenu();
                selection = ReadInt("Enter your selection (1-3): ");

                switch (selection)
                {
                    case 1:
                        RunSimpleInterest();
                        break;
                    case 2:
                        RunCompoundInterest();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("\nThanks for using the Interest Calculator. Goodbye!");
                        Console.ResetColor();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("⚠️ Invalid selection. Please try again.");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();

            } while (selection != 3);
        }

        static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Simple Interest 💵");
            Console.WriteLine("2. Compound Interest 🧮");
            Console.WriteLine("3. Exit ❌");
            Console.ResetColor();
        }

        static void RunSimpleInterest()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n🧾 Simple Interest Calculator");
            Console.ResetColor();

            BasicInput input;
            input.principal = ReadDouble("Enter the amount you are borrowing: $ ");
            input.rate = ReadDouble("Enter the annual interest rate (in %): ");
            int months = ReadInt("Enter the number of months: ");

            input.interest = input.principal * (input.rate / 100);
            input.total = input.principal + input.interest;
            double monthlyPayment = input.total / months;

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\n💰 Total interest: ${input.interest:N2}");
            Console.WriteLine($"📊 Total amount paid: ${input.total:N2}");
            Console.WriteLine($"📆 Monthly payment: ${monthlyPayment:N2}");
            Console.ResetColor();
        }

        static void RunCompoundInterest()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n📈 Compound Interest Calculator");
            Console.ResetColor();

            BasicInput input;
            input.principal = ReadDouble("Enter the initial amount: $ ");
            input.rate = ReadDouble("Enter the annual interest rate (in %): ") / 100;
            int years = ReadInt("Enter the number of years: ");
            int periodsPerYear = ReadInt("How many times is interest applied per year? ");

            // Compound Interest Formula: A = P(1 + r/n)^(nt)
            input.total = input.principal * Math.Pow((1 + input.rate / periodsPerYear), periodsPerYear * years);
            input.interest = input.total - input.principal;

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\n📈 Total interest earned: ${input.interest:N2}");
            Console.WriteLine($"🏦 Final amount: ${input.total:N2}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n📅 Amortization Table:");
            Console.ResetColor();

            for (int i = 1; i <= years; i++)
            {
                double yearlyTotal = input.principal * Math.Pow((1 + input.rate / periodsPerYear), periodsPerYear * i);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Year {i}: ${yearlyTotal:N2}");
                Console.ResetColor();
            }
        }

        static double ReadDouble(string prompt)
        {
            double value;
            do
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out value) && value >= 0)
                    return value;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("⚠️ Invalid input. Please enter a positive number.");
                Console.ResetColor();
            } while (true);
        }

        static int ReadInt(string prompt)
        {
            int value;
            do
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value > 0)
                    return value;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("⚠️ Invalid input. Please enter a positive whole number.");
                Console.ResetColor();
            } while (true);
        }
    }
}
