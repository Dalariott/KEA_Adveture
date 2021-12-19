using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Variables       
    private float maxHealth;
    private float damageEnemy;
    [SerializeField] Stats stat;

    //Awake
    void Awake()
    {
        maxHealth = 10;
        stat.currentHealth = maxHealth;
    }
    
    //Update
    void Update()
    {
        stat.maxHealth = maxHealth;        
    }
 
    //Collider detection
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            damageEnemy = collision.gameObject.GetComponent<Weapon>().damage;
            stat.currentHealth -= damageEnemy;            
            Invoke(nameof(DmgOff), 0.5f);
        }
    }

    //Dmg off
    private void DmgOff()
    {
        damageEnemy = 0;
    }
}
