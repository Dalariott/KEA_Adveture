using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    //Sound vars
    AudioSource _audioSource;
    [SerializeField] AudioClip CollideEnemyAudio;
    [SerializeField] AudioClip collideAudio;
    
    
    //Damage vars
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _audioSource.PlayOneShot(CollideEnemyAudio, 0.6F);
        }

        _audioSource.PlayOneShot(collideAudio, 0.7F);
    }
}
