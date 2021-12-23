using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Weapon : MonoBehaviour
{

    //Sound vars
    AudioSource _audioSource;
    [SerializeField] AudioClip CollideEnemyAudio;
    [SerializeField] AudioClip collideAudio; 
    private Behaviour bhvr;


    //Damage vars
    public float damage;

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
        }

    }
}
