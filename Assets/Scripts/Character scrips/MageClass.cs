using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageClass : CharacterClass
{
    public MageClass()
    {
        armor = 100;
        maxHealth = 100;
        health = 100;
        healthRegeneration = 1;
        damage = 10;
        castingSpeed = 10;
        walkingSpeed = 10;
    }
}
