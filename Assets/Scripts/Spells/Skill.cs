using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Skill", menuName = "Skill")]
public class Skill : ScriptableObject
{
    public string skillName;
    public string description;

    public Sprite skillSprite;

    public int manaCost;
    public int damage;
    public float castDuration;
}
