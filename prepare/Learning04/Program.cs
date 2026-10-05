
using System;

// Test the three constructors
Fraction fraction1 = new Fraction();
Fraction fraction2 = new Fraction(5);
Fraction fraction3 = new Fraction(3, 4);
Fraction fraction4 = new Fraction(1, 3);

// Display the fractions and decimal values
Console.WriteLine(fraction1.GetFractionString());
Console.WriteLine(fraction1.GetDecimalValue());

Console.WriteLine(fraction2.GetFractionString());
Console.WriteLine(fraction2.GetDecimalValue());

Console.WriteLine(fraction3.GetFractionString());
Console.WriteLine(fraction3.GetDecimalValue());

Console.WriteLine(fraction4.GetFractionString());
Console.WriteLine(fraction4.GetDecimalValue());

// Test getters and setters
Fraction testFraction = new Fraction();

testFraction.SetTop(6);
testFraction.SetBottom(7);

Console.WriteLine();
Console.WriteLine("Testing Getters and Setters:");
Console.WriteLine($"Top: {testFraction.GetTop()}");
Console.WriteLine($"Bottom: {testFraction.GetBottom()}");
Console.WriteLine($"Fraction: {testFraction.GetFractionString()}");

// Practice using random fractions
Console.WriteLine();
Console.WriteLine("Random Fractions:");

Random random = new Random();

Fraction randomFraction = new Fraction();

for (int i = 1; i <= 20; i++)
{
    int top = random.Next(1, 11);
    int bottom = random.Next(1, 11);

    randomFraction.SetTop(top);
    randomFraction.SetBottom(bottom);

    Console.WriteLine(
        $"Fraction {i}: string: {randomFraction.GetFractionString()} Number: {randomFraction.GetDecimalValue()}"
    );
}