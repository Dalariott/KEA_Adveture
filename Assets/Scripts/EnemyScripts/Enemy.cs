using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //Variables
    AudioSource _audioSource;
    Animator _anim;

    //Serailize Variables    
    [SerializeField] GameObject windowLoot;
    [SerializeField] EnemyStats stat;
    [SerializeField] Stats playerStat;
    [SerializeField] int xpReward;

    //Private
    private bool _inSight, _inRangeAttack;
    private float damageWeapon;
    private Transform _playerPosition;
    private UnityEngine.AI.NavMeshAgent _ownNavMesh;
    private float dmgCount;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _ownNavMesh = GetComponent<NavMeshAgent>();
    }

    void Awake()
    {
        _ownNavMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        dmgCount = 0f;
        currentHealth = stat.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        DeathObject();   
        Range();
    }

    //Comapare Ranges
    private void Range()
    {        
        _inSight = Physics.CheckSphere(transform.position, stat._sightRange, stat.playerLayer);   
        _inRangeAttack = Physics.CheckSphere(transform.position, stat._attackRange, stat.playerLayer);

        if (_inSight && _inRangeAttack) 
        {            
            AttackRange();
            if (dmgCount < 4.5)
            {
                _anim.SetBool("Attack", false);
                dmgCount += Time.deltaTime;
            }
            else if (dmgCount > 4.5)
            {
                _anim.SetBool("Attack", true);
                dmgCount = 0;
            }            
        }

        if (_inSight && !_inRangeAttack)
        {            
            ChasePlayer();
        }   
        
        if (!_inSight && !_inRangeAttack)
        {
            _anim.SetBool("Fight", false);
            _anim.SetBool("Walk", false);
            _anim.SetBool("Idle", true);
            _ownNavMesh.ResetPath();
        }
    }


    //Chase the player to fucking kill him >:)
    private void ChasePlayer()
    {
        _playerPosition = GameObject.Find("Camera (head)").transform;
        _anim.SetBool("Fight", false);
        _anim.SetBool("Walk", true);
        _ownNavMesh.destination = _playerPosition.position;
    }


    //Method that detect the triggers to animate
    /*private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            Vector3 weaponPosition = collision.gameObject.GetComponent<Transform>().position;
            float pointClosestWeapon = TransformDot(collision.ClosestPoint(weaponPosition));
            if (pointClosestWeapon <= 6.6f && pointClosestWeapon >= 6.41f)
            {
                _anim.SetBool("Fight", false);
                _anim.SetBool("Walk", false);
                _anim.SetBool("DamageFront", false);
                _anim.SetBool("DamageLeft", true);

            }
            else if (pointClosestWeapon >= 6.1f && pointClosestWeapon <= 6.41f)
            {               
                _anim.SetBool("Fight", false);
                _anim.SetBool("Walk", false);
                _anim.SetBool("DamageFront", false);
                _anim.SetBool("DamageLeft", true);
            }
            else if (pointClosestWeapon >= 6.61f && pointClosestWeapon <= 6.7f)
            {
                _anim.SetBool("Fight", false);
                _anim.SetBool("Walk", false);
                _anim.SetBool("DamageLeft", false);
                _anim.SetBool("DamageFront", true);
            }       

        }
        
    }*/

    //Colider for damage
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Weapon")
        {
            _anim.SetBool("DamageFront", true);
            damageWeapon = col.gameObject.GetComponent<Weapon>().damage;
            DmgReceived(damageWeapon);
            Invoke(nameof(DmgOff), 0.5f);
        }

    }

    //Transforms and divide the collider on two sides Left and Right 
    private float TransformDot(Vector3 closestPoint)
    {
        Vector3 rightSide = transform.right;
        float setDot = Vector3.Dot(rightSide.normalized, closestPoint.normalized);
        //split in 2
        setDot = (setDot * 10);
        Debug.Log($"Dot: {setDot}");
        return setDot;
    }

    private void DmgOff()
    {
        damageWeapon = 0;
        _anim.SetBool("DamageFront", false);
        _anim.SetBool("DamageLeft", false);
    }

    //Method to calculate the damage received
    private void DmgReceived(float dmg)
    {
        currentHealth -= dmg;
        _anim.SetBool("Fight", false);
        _anim.SetBool("Walk", false);
        _audioSource.PlayOneShot(stat.damageReceived, 0.4F);        
    }

    //Method to destroy the object
    private void DestroyObject()
    {
        Destroy(gameObject);

        playerStat.currentXpPlayer += xpReward;
        
        
    }

    //Method that kills the enemy
    private void DeathObject()
    {
        if (currentHealth <= 0)
        {
            Invoke(nameof(DestroyObject), 2);
            _audioSource.PlayOneShot(stat.destroyMyself, 0.1F);
            _anim.Play("Destroy");
            //windowLoot.SetActive(true);            
        }
    }
   

    //Method that makes the enemy attack the player
    private void AttackRange()
    {
        if (_playerPosition) // we get sure the target is here
        {
            var rotationAngle = Quaternion.LookRotation(_playerPosition.position - transform.position); // we get the angle has to be rotated
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * 5f); // we rotate the rotationAngle 
            _anim.SetBool("Walk", false);
            _anim.SetBool("Fight", true);            
        }

        
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + (Vector3.up * 0.1f), stat._attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + (Vector3.up * 0.1f), stat._sightRange);
    }
}
