using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    private CharacterClass player;

    private void Start()
    {
        player = new CharacterClass();
        SetPlayerClass();
        StartCoroutine(RegainHealthOverTime());
    }
    private void Update()
    {
        Debug.Log("Health " + player.health);
        Debug.Log("Armor " + player.armor);
    }

    private void SetPlayerClass()
    {
        player.playerClass = new MageClass();
        player.armor = player.playerClass.armor;
        player.health = player.playerClass.health;
        player.maxHealth = player.playerClass.maxHealth;
        player.healthRegeneration = player.playerClass.healthRegeneration;
        player.damage = player.playerClass.damage;
        player.castingSpeed = player.playerClass.castingSpeed;
        player.walkingSpeed = player.playerClass.walkingSpeed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var damageToHealth = player.armor - 120;
            if (damageToHealth >= 0)
            {
                player.armor = player.TakeDamageToArmor(player.armor, 120);
            }
            else
            {
                player.armor = player.TakeDamageToArmor(player.armor, 120);
                player.health = player.TakeDamageToHealth(player.health, -damageToHealth);
            }
        }
    }

    private IEnumerator RegainHealthOverTime()
    {
        while (true)
        {
            if (player.health < player.maxHealth)
            {
                player.health = player.HealthRegeneration(player.maxHealth, player.health, player.healthRegeneration);
                yield return new WaitForSeconds(1);
            }
            else
            {
                yield return null;
            }
        }
    }
}
