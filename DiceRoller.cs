using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    // Number of die to use (Eg: D20) in the simulation
    public int DieCount = 6;

    void Start()
    {
        // Create a new dice object with a number of sides equal to DieCount.
        Dice die = new Dice(DieCount);

        // Roll multiple dice and log the result.
        int rollResult = die.RollMultiple(DieCount);
        Debug.Log($"Rolling {DieCount} dice: {rollResult}");

        // Roll multiple dice with a modifier and log the result.
        int rollWithModifier = die.RollMultiple(DieCount) + 5;
        Debug.Log($"Rolling {DieCount} dice with a modifier of 5: {rollWithModifier}");

        // Calculate and log the probability of rolling a 1.
        double probabilityOfOne = die.ProbabilityOfNumber(1);
        Debug.Log($"Probability of rolling a 1: {probabilityOfOne:P2}");

        // Calculate and log the probability of rolling the maximum number on the dice.
        double probabilityOfMax = die.ProbabilityOfNumber(DieCount);
        Debug.Log($"Probability of rolling a {DieCount}: {probabilityOfMax:P2}");

        // Log the distribution of results over a large number of rolls to analyze randomness.
        die.LogRolls(10000);

        // Example of rolling a single die with a modifier.
        int singleRollWithModifier = die.RollWithModifier(3);
        Debug.Log($"Rolling a single die with a modifier of 3: {singleRollWithModifier}");

        // Example of checking the probability of rolling the lowest possible number.
        double probabilityOfMin = die.ProbabilityOfNumber(1);
        Debug.Log($"Probability of rolling the minimum number (1): {probabilityOfMin:P2}");
    }

}