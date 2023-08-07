using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSystem
{
    public int Roll(int numberOfDiece, int sidesOfDice)
    {
        if (numberOfDiece <= 0 || sidesOfDice <= 0)
        {
            Debug.LogError("Number of dice and sides of diece must be greater than 0");
            return 0;
        }
        int sum = 0;
        for (int i = 0; i < numberOfDiece; i++)
        {
            sum += Random.Range(1, sidesOfDice + 1);
        }
        return sum;
    }
}
