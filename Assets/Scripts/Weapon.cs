using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;
using NaughtyAttributes;

public class Weapon : MonoBehaviour
{


    private Behaviour bhvr;
    [SerializeField] ParticleSystem particleHitEnemy;

    //Sound vars
    AudioSource _audioSource;
    [SerializeField] AudioClip CollideEnemyAudio;
    [SerializeField] AudioClip collideAudio; 
   
   //Damage vars
    public float damage;
    private float damageInit = 2f;
    [SerializeField] EnemyStats enemyStat;
    [SerializeField] Stats playerStat;


    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        bhvr = GetComponent<ParentConstraint>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _audioSource.PlayOneShot(CollideEnemyAudio, 0.6F);
            particleHitEnemy.Play();
            Invoke(nameof(FXOff), 0.3f);
        }       

    }

    private void DamagePlayer()
    {
        if (enemyStat)
        {
            
        }
        else
        {
            damage = (damageInit * playerStat.strenghtPlayer) / 2f;
        }
    }

    void FXOff()
    {
        particleHitEnemy.Stop();
    }
}
