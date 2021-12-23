using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu]
public class EnemyStats : ScriptableObject
{
    //Variables
    AudioSource _audioSource;
    Animator _anim;

    //Serailize Variables   
    public float _sightRange, _attackRange;
    public LayerMask playerLayer, groundLayer;
    [SerializeField] TextMeshPro textDmg;
    [SerializeField] GameObject windowLoot;
    //Sound
    public AudioClip damageReceived;
    public AudioClip destroyMyself;
    public AudioClip idle;

    //Stats
    public float maxHealth;
    public float currentHealth;

    
}
