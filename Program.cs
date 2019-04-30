using System;

namespace masterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Play Mastermind!");
            
            string name = GetName();

            do
            {
                PlayGame(name);
                Console.WriteLine("\nWould you like to play again? Enter 'y' for Yes or 'n' for No.");
            }
            while (Console.ReadLine().ToUpper() == "Y");
        }

        private static string GetName()
        {
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Welcome, {0}. Enjoy the game!!\n ", name);
            return name;
        }

        public static int[] GenerateNumbers(int numbers)
        {
            int everyNumber;
            int[] randomNumber = new int[numbers];
            Random rand = new Random();

            for (int i = 0; i < numbers; i++)
            {
                everyNumber = rand.Next(1, 5);
                randomNumber[i] = everyNumber;
                Console.Write(everyNumber);
            }
            Console.WriteLine();
            return randomNumber;
        }

        
        public static int[] GetUserGuess(int playerNumber)
        {
            int code = 0;
            int[] playerGuess = new int[playerNumber];
            for (int i = 0; i < playerNumber; i++)
            {
                Console.Write("Digit {0}: ", (i + 1));
                while (!int.TryParse(Console.ReadLine(), out code) || code < 1 || code > 6)
                    Console.WriteLine("This is an Invalid number!");
                playerGuess[i] = code;
            }
            Console.WriteLine();
            Console.Write("Your guess: ");
            for (int i = 0; i < playerNumber; i++)
            {
                Console.Write(playerGuess[i] + " ");
            }
            Console.WriteLine();
            
            return playerGuess;
        }

        //Split array: Assign '+' to hits and '-' for every correct number wrong position.
        public static int CountHits(int[] generatedArray, int[] userArray)
        {
            int hits = 0;

            for (int i = 0; i < generatedArray.Length; i++)
            {
                if (generatedArray[i] == userArray[i])
                    hits++;
            }

            Console.WriteLine("Results: {0} +, {1} -", hits, generatedArray.Length - hits);
            return hits;
        }

        //Play Function
        private static void PlayGame(string name)
        {
        int numberCount = 4;
        int[] generatedArray = GenerateRandomNumbers(numberCount);

        bool won = false;
        for (int allowedAttempts = numberCount; allowedAttempts > 0 && !won; allowedAttempts--)
        {
            Console.WriteLine("\nEnter your guess ({0} more guesses to crack the code)", allowedAttempts);

            int[] userArray = GetUserGuess(numberCount);

            if (CountHits(generatedArray, userArray) == numberCount)
                won = true;
        }

        if (won)
            Console.WriteLine("You win, {0}!", name);
        else
            Console.WriteLine("Oh no, {0}! You couldn't break the code!", name);

        Console.Write("The correct code is: ");
        for (int j = 0; j < numberCount; j++)
            Console.Write(generatedArray[j] + " ");
        Console.WriteLine();
    }


    public static int[] GenerateRandomNumbers(int playerNumber)
    {
        int eachNumber;
        int[] randomNumber = new int[playerNumber];
        Random rnd = new Random();

        Console.Write("PC Code: ");
        for (int i = 0; i < playerNumber; i++)
        {
            eachNumber = rnd.Next(1, 7);
            randomNumber[i] = eachNumber;
            Console.Write(eachNumber);
        }
        Console.WriteLine();
        return randomNumber;
    }

    }
}
