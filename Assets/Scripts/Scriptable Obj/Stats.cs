using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Stats : ScriptableObject
{     
    public float maxHealth;
    public float currentHealth;
    public string totalHealthText;
    public float healthRegen;
    public float maxXpPlayer;
    public float currentXpPlayer;
    public float strenghtPlayer;
    public float healthModifier;
    public int playerLevel;   
}
