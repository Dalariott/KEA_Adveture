using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    //Animator _anim;
    [SerializeField] Stats stat;
    Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        //_anim = GetComponent<Animator>();
        healthBar = GetComponent<Slider>();
        healthBar.minValue = 0;
    }  

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = stat.maxHealth;
        healthBar.value = stat.currentHealth;

    }
}
