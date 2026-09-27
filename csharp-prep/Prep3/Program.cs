

Console.Write("What is the magic number? ");
int magicNumber = int.Parse(Console.ReadLine());

Console.Write("What is your guess? ");
int guess = int.Parse(Console.ReadLine());

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
}