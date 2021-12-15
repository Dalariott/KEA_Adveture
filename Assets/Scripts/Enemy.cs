using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    //Variables
    AudioSource _audioSource;
    Animator _anim;

    //Serailize Variables   
    [SerializeField] float _health, _sightRange, _attackRange;
    [SerializeField] GameObject _enemyWeapon;
    [SerializeField] Transform _player;
    [SerializeField] UnityEngine.AI.NavMeshAgent _ownNavMesh;
    [SerializeField] LayerMask playerLayer, groundLayer;
    [SerializeField] TextMeshPro textDmg;
        //Sound
    [SerializeField] AudioClip damageReceived;
    [SerializeField] AudioClip destroyMyself;
    [SerializeField] AudioClip Idle;
    //Private
    private bool _atkPlayer, _inSight, _inRangeAttack;
    private string stringDmg;    
    private float damageWeapon;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();           
    }

    void Awake()
    {
        _player = GameObject.Find("Player").transform;
        _ownNavMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        DeathObject();        
        TextDamage();
        Attack();
        Range();
    }

    //Comapare Ranges
    private void Range()
    {
        _inSight = Physics.CheckSphere(transform.position, _sightRange, playerLayer);
        _inRangeAttack = Physics.CheckSphere(transform.position, _attackRange, playerLayer);

        if (_inSight && _inRangeAttack) AttackRange();
        if (_inSight && !_inRangeAttack) ChasePlayer();        
        if (!_inSight && !_inRangeAttack);
    }

    //Display text on the UI
    void TextDamage()
    {
        if (damageWeapon != 0)
        {
            textDmg.gameObject.SetActive(true);
            textDmg.text = stringDmg + " dmg";
        }
        else
        {
            textDmg.gameObject.SetActive(false);
        }
    }

    //Method that detect the triggers from the collider
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            damageWeapon = collision.gameObject.GetComponent<Weapon>().damage;
            DmgReceived(damageWeapon);
            Invoke(nameof(OffTextDmg), 0.1f);
        }
    }

    //Method to calculate the damage received
    private void DmgReceived(float dmg)
    {
        _health -= dmg;
        stringDmg = (dmg).ToString();
        _anim.SetBool("Damage", true);
        _audioSource.PlayOneShot(damageReceived, 0.9F);
    }

    //Mehtod to set off the text UI for the damage
    void OffTextDmg()
    {
        damageWeapon = 0;        
        _anim.SetBool("Damage", false);
    }

    //Method to destroy the object
    private void DestroyObject()
    {
        Destroy(gameObject);
    }

    //Method that kills the enemy
    private void DeathObject()
    {
        if (_health <= 0)
        {
            Invoke(nameof(DestroyObject), 2);
            _audioSource.PlayOneShot(destroyMyself, 0.1F);
            _anim.SetBool("Destroy", true);
        }
    }

    //Chase the player to fucking kill him >:)
    private void ChasePlayer()
    {
        _ownNavMesh.SetDestination(_player.position);     
    }

    //Method that makes the enemy attack the player
    private void AttackRange()
    {
        _ownNavMesh.SetDestination(transform.position);
        transform.LookAt(_player.transform);      
        
    }

    private void Attack()
    {
        _atkPlayer = _enemyWeapon.GetComponent<EnemyAtk>().attackPlayer;
        if (_atkPlayer == true)
        {
            _anim.SetBool("Attack", true);
        }
        else
        {
            //_audioSource.PlayOneShot(Idle, 0.7F);
            _anim.SetBool("Attack", false);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + (Vector3.up * 0.5f), _attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + (Vector3.up * 1.5f), _sightRange);
    }
}