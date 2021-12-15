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
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Collider detection
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon Enemy")
        {
            damageEnemy = collision.gameObject.GetComponent<EnemyAtk>().enemyDamage;
            currentHealth -= damageEnemy;
            Invoke(nameof(DmgOff), 0.5f);
        }
    }

    //Dmg off
    private void DmgOff()
    {
        damageEnemy = 0;
    }
}
