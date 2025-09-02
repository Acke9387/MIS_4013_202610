
Console.WriteLine("Please input the lower bound value <<");
string answer = Console.ReadLine();
int lowerBound = 0;

lowerBound = ValidateInput(answer);

//try
//{
//    result = int.Parse(a);
//}
//catch (FormatException ex)
//{
//    Console.WriteLine("Please enter a number and not a string");
//}
//catch (OverflowException ex)
//{
//    Console.WriteLine("Your value exceeds the limits");
//}
//catch (Exception ex)
//{
//    Console.WriteLine("I don't know what went wrong.");
//}

Console.WriteLine("Please input the upper bound value <<");
answer = Console.ReadLine();
int upperBound = ValidateInput(answer, "Invalid input for upper bound, please try again <<");

for (int i = 0; i < int.MaxValue; i++)
{
    //data_type variable_name = value
    Random r = new Random();
    var rando = r.Next(lowerBound, upperBound + 1); // Generate a random number between 1-5

    Console.WriteLine($"Generated a random number with the value {rando}");
    int guess;
    int count = 0;

    do
    {
        Console.WriteLine($"Please guess a number between {lowerBound} and {upperBound} <<");
        string usersGuess = Console.ReadLine();
        //int guess = Convert.ToInt32(usersGuess);
        guess = ValidateInput(usersGuess, "Invalid input for guess, please try again <<");
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

    Console.WriteLine("Do you want to try your luck again? yes or no <<");
    answer = Console.ReadLine();

    if (answer != "yes") // (a =="no")
    {
        break;
        i = int.MaxValue;
        return;
    }
}

Console.WriteLine("Thank you for playing our game, come back soon!");


///
static int ValidateInput(string a, string msg = "Invalid input for lower bound, please try again <<")
{
    int result;
    while (int.TryParse(a, out result) == false)
    {
        Console.WriteLine(msg);
        a = Console.ReadLine();
    }

   return result;
}