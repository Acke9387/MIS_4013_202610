
//data_type variable_name = value
Random r = new Random();

var rando = r.Next(1, 5 + 1); // Generate a random number between 1-5

Console.WriteLine($"Generated a random number with the value {rando}");
int guess;
int count = 0;

do
{
    Console.WriteLine("Please guess a number between 1 and 5 <<");
    string usersGuess = Console.ReadLine();
    //int guess = Convert.ToInt32(usersGuess);
    guess = int.Parse(usersGuess);
    count++;
    //count = count + 1;
    //count += 1;
    Console.WriteLine($"You guessed {usersGuess}");

    //if (rando == guess)
    //{
    //	Console.WriteLine("Congratulations you guessed correctly!");
    //}
    //else
    //{
    //	Console.WriteLine("Sorry, you guessed incorrectly!");
    //} 
    if (rando != guess)
    {
        if (guess > rando)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Sorry, you guessed too high!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Sorry, you guessed too low!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    

} while (guess != rando);

Console.WriteLine($"Congratulations you guessed correctly and it only took {count} attempts!");

//Console.WriteLine("Generated a random number with the value " + rando + " ");
