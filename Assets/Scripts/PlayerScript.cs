using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    //Variables  
    private float damageEnemy;
    private float healthRegenTime;
    [SerializeField] Stats stat;
    //[SerializeField] GameObject damageCanvas;

    //Awake
    void Awake()
    {
        healthRegenTime = 0;
    }
    
    //Update
    void Update()
    {
        if (stat.currentHealth > stat.maxHealth) stat.currentHealth = stat.maxHealth;
        HealthRegen();    
    }
 
    //Collider detection
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            damageEnemy = collision.gameObject.GetComponent<Weapon>().damage;
            stat.currentHealth -= damageEnemy;
            //damageCanvas.SetActive(true);
            Invoke(nameof(DmgOff), 0.5f);
        }
    }

    //Dmg off
    private void DmgOff()
    {
        damageEnemy = 0;
        //damageCanvas.SetActive(false);
    }

    void HealthRegen()
    {
        stat.healthRegen = stat.maxHealth/100;        
        healthRegenTime += Time.deltaTime;

        if (healthRegenTime >= 5)
        {
            stat.currentHealth += stat.healthRegen;
            healthRegenTime = 0;
        }
    }
}
