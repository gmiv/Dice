using System;
using UnityEngine;

public class Dice
{
    // Number of sides on the dice. This property is read-only outside this class.
    public int NumberOfSides { get; private set; }

    // Random number generator for dice rolling.
    // System.Random is used here instead of Unity's Random for better control over the seed and reproducibility.
    private System.Random rng = new System.Random();

    // Constructor for the Dice class.
    // Initializes a new dice with a specific number of sides.
    // 'sides' must be at least 2 for a valid dice.
    public Dice(int sides)
    {
        if (sides < 2)
            throw new ArgumentException("Dice must have at least 2 sides.");
        NumberOfSides = sides;
    }

    // Roll a single die and return the result.
    // It will return a random integer between 1 and NumberOfSides.
    public int Roll()
    {
        return rng.Next(1, NumberOfSides + 1);
    }

    // Roll multiple dice of the same type and return the cumulative result.
    // 'count' specifies how many times the dice should be rolled.
    public int RollMultiple(int count)
    {
        int total = 0;
        for (int i = 0; i < count; i++)
        {
            total += Roll();
        }
        return total;
    }

    // Roll a single die and apply a modifier to the result.
    // 'modifier' is added to the result of the dice roll.
    public int RollWithModifier(int modifier)
    {
        return Roll() + modifier;
    }

    // Calculate the probability of rolling a specific number.
    // Returns 0 if the number is outside the possible dice results.
    public double ProbabilityOfNumber(int number)
    {
        if (number < 1 || number > NumberOfSides)
            return 0;
        return 1.0 / NumberOfSides;
    }

    // Log the distribution of roll outcomes over a specified number of rolls to help analyze randomness.
    // 'numRolls' specifies how many rolls to log.
    // Useful for debugging or demonstrating the randomness of the dice.
    public void LogRolls(int numRolls)
    {
        int[] results = new int[NumberOfSides];
        for (int i = 0; i < numRolls; i++)
        {
            int result = Roll();
            results[result - 1]++;
        }

        Debug.Log("Roll Distribution:");
        for (int i = 0; i < results.Length; i++)
        {
            Debug.Log($"Number {i + 1}: {results[i]} times ({(double)results[i] / numRolls * 100:F2}%)");
        }
    }

    // Comment about potential future enhancements for detecting biases in the dice rolls.
    // For instance, using statistical tests like the Chi-squared test to assess the goodness of fit.
}
