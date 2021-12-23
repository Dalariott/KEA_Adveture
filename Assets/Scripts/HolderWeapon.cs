using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderWeapon : MonoBehaviour
{
    [SerializeField] GameObject Weapon;
    public Transform objPosition;
    bool check = true;

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find(Weapon.name) && check)
        {
            Instantiate(Weapon, objPosition.position, objPosition.rotation);
            check = false;
        }
        
    }
}
