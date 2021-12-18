using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    //Animator _anim;
    private float getHealthPlayer;
    private float healthPlayer;
    private float getCurrentHealthPlayer;
    [SerializeField] GameObject _playerAttribute;
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
        getHealthPlayer = _playerAttribute.GetComponent<PlayerScript>().maxHealth;
        healthBar.maxValue = getHealthPlayer;
        getCurrentHealthPlayer = _playerAttribute.GetComponent<PlayerScript>().currentHealth;
        healthBar.value = getCurrentHealthPlayer;

    }
}
