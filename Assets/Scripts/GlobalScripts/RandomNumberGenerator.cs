using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumberGenerator : MonoBehaviour
{
    public int RandomNumber(int numberOne, int numberTwo)
    {
        int rand = Random.Range(numberOne, numberTwo);
        return rand;
    }
}
