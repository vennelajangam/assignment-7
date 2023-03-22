using System;

class Program
{
    static void Main(string[] args)
    {
        int attempts = 0;

        while (attempts < 5)
        {
            Console.WriteLine("Enter any number from 1-5 :-");
            int input = 0;

            try
            {
                input = Convert.ToInt32(Console.ReadLine());
                if (!IsValidInput(input))
                {
                    throw new InvalidInputException("Invalid input! Please enter a number from 1-5.");
                }

                switch (input)
                {
                    case 1:
                        Console.WriteLine("Enter even number");
                        break;
                    case 2:
                        Console.WriteLine("Enter odd number");
                        break;
                    case 3:
                        Console.WriteLine("Enter a prime number");
                        break;
                    case 4:
                        Console.WriteLine("Enter a negative number");
                        break;
                    case 5:
                        Console.WriteLine("Enter zero");
                        break;
                }

              

            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a number.");
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            attempts++;
        }

        Console.WriteLine("You have played this game for 5 times.");
        Console.ReadLine();
    }

    static bool IsValidInput(int input)
    {
        return input >= 1 && input <= 5;
    }
}

class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message)
    {
    }
}
