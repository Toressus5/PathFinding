using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass
{
    public string playerName { get; set; }
    public int playerLevel { get; set; }
    public CharacterClass playerClass { get; set; }

    public int armor { get; set; }
    public int health { get; set; }
    public int maxHealth { get; set; }
    public int healthRegeneration { get; set; }
    public int damage { get; set; }
    public int castingSpeed { get; set; }
    public int walkingSpeed { get; set; }


    public int HealthRegeneration(int maxPlayerHealth, int playerHealth, int healthRegeneration)
    {
        playerHealth = playerHealth + healthRegeneration;
        return playerHealth;
    }

    public int TakeDamageToArmor(int armor, int damageDealt)
    {
        armor = Mathf.Max(0, armor - damageDealt);
        return armor;
    }

    public int TakeDamageToHealth(int playerHealth, int damageDealt)
    {
        health = Mathf.Max(0, playerHealth - damageDealt);
        return health;
    }
}
