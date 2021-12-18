using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Variables       
    public float maxHealth;
    public float currentHealth;
    private float damageEnemy;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth;
    }

    //Collider detection
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            damageEnemy = collision.gameObject.GetComponent<Weapon>().damage;
            currentHealth -= damageEnemy;
            
            Invoke(nameof(DmgOff), 0.5f);
            Debug.Log("Life" + currentHealth);
        }
    }

    //Dmg off
    private void DmgOff()
    {
        damageEnemy = 0;
    }
}
