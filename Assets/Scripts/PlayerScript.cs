using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    //Variables  
    private float damageEnemy;
    private float healthRegenTime;
    private float percentageHealth;
    [SerializeField] private ParticleSystem particleXP;
    [SerializeField] private ParticleSystem lvlUp;
    [SerializeField] Stats playerStat;


    //Awake
    void Awake()
    {
        healthRegenTime = 0;
    }
    
    //Update
    void Update()
    {        
        HealthRegen();
        StatsLevel();
        LvlUp();
    }
 
    //Collider detection
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "WepEnemy")
        {
            damageEnemy = collision.gameObject.GetComponent<Weapon>().damage;
            playerStat.currentHealth -= damageEnemy;
            Invoke(nameof(DmgOff), 0.5f);
        }
    }

    //Verify Stats lvl
    private void StatsLevel()
    {
        //Health
        if (playerStat.currentHealth > playerStat.maxHealth) playerStat.currentHealth = playerStat.maxHealth;
        if (playerStat.currentHealth < 0) playerStat.currentHealth = 0;
        playerStat.maxHealth = ((playerStat.playerLevel + 1) * 10) + playerStat.healthModifier;

        //Health %
        percentageHealth = Mathf.Ceil((playerStat.currentHealth * 100) / playerStat.maxHealth);
        playerStat.totalHealthText = percentageHealth.ToString() + "%";
        

        //XP
        if (playerStat.currentXpPlayer < 0) playerStat.currentXpPlayer = 0;
        playerStat.maxXpPlayer = ((playerStat.playerLevel + 1) * 50);

    }

    //Dmg off
    private void DmgOff()
    {
        damageEnemy = 0;
    }

    private void LvlUp()
    {
        float xpCalc = Mathf.Floor(playerStat.currentXpPlayer / 50);
        int currentLevel = Mathf.RoundToInt(xpCalc);
        if (currentLevel > playerStat.playerLevel)
        {
            particleXP.Play();
            playerStat.playerLevel += 1;
            lvlUp.Play();
        }
    }


    private void HealthRegen()
    {
        playerStat.healthRegen = playerStat.maxHealth/100;        
        healthRegenTime += Time.deltaTime;

        if (healthRegenTime >= 5)
        {
            playerStat.currentHealth += playerStat.healthRegen;
            healthRegenTime = 0;
        }
    }
}
