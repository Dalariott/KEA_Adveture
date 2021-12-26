using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Stats playerStat;

    //HP bar    
    [SerializeField] Text currentHealth;
    [SerializeField] Slider healthBar;

    //Xp bar
    [SerializeField] Text currentXP;
    [SerializeField] Slider xpBar;

    //Time
    [SerializeField] Text time;

    //Singular Stats
    [SerializeField] Text playerLevel, strenghtPlayer, healthRegen;

    void Start()
    {
        healthBar.minValue = 0;
        healthBar.maxValue = playerStat.maxHealth;
    }


    void Update()
    {
        healthBar.maxValue = playerStat.maxHealth;
        healthBar.value = playerStat.currentHealth;
        currentHealth.text = playerStat.currentHealth.ToString() +"/"+playerStat.maxHealth.ToString();

        xpBar.maxValue = playerStat.maxXpPlayer;
        xpBar.value = playerStat.currentXpPlayer;
        currentXP.text = playerStat.currentXpPlayer.ToString() + "/" + xpBar.maxValue.ToString();

        time.text = System.DateTime.Now.ToString("HH:mm:ss");

        playerLevel.text = playerStat.playerLevel.ToString();
        strenghtPlayer.text = playerStat.strenghtPlayer.ToString();
        healthRegen.text = playerStat.healthRegen.ToString();
    }
}
