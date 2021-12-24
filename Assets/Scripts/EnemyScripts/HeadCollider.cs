using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollider : Enemy
{

    //[SerializeField] EnemyStats stat;

    //Method that detect the triggers from the collider
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            // damageWeapon = collision.gameObject.GetComponent<Weapon>().damage;
            //DmgReceived(damageWeapon);
            Debug.Log("Si");
        }

    }
}
