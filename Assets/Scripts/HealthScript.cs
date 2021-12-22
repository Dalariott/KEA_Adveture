using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    //Animator _anim;
    [SerializeField] EnemyStats enemyStat;
    [SerializeField] Stats playerStat;
    [SerializeField] TextMeshProUGUI totalHealth;
    Slider healthBar;
    private float percentageHealth;

    // Start is called before the first frame update
    void Start()
    {        
        healthBar = GetComponent<Slider>();
        healthBar.minValue = 0;
    }  

    // Update is called once per frame
    void Update()
    {
        if (enemyStat)
        {
            healthBar.maxValue = enemyStat.maxHealth;
            healthBar.value = enemyStat.currentHealth;
            percentageHealth = Mathf.Ceil((enemyStat.currentHealth * 100) / enemyStat.maxHealth);
            totalHealth.text = percentageHealth.ToString() + "%";
        }
        else
        {
            healthBar.maxValue = playerStat.maxHealth;
            healthBar.value = playerStat.currentHealth;
            percentageHealth = Mathf.Ceil((playerStat.currentHealth * 100) / playerStat.maxHealth);
            totalHealth.text = percentageHealth.ToString() + "%";
        }

        
        

    }
}
