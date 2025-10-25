using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a random number generator
        Random randomGenerator = new Random();
        string playAgain = "yes";

        // Loop the entire game as long as user says yes
        while (playAgain.ToLower() == "yes")
        {
            // Generate a random magic number between 1 and 100
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;  // initialize guess to something that isn't the magic number
            int guessCount = 0; // track number of guesses

            Console.WriteLine("Welcome to the Guess My Number game!");
            Console.WriteLine("I have chosen a number between 1 and 100.");

            // Loop until the user guesses correctly
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            // Ask if the user wants to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
            Console.WriteLine(); // blank line for spacing
        }

        Console.WriteLine("Thanks for playing! Goodbye.");
    }
}
