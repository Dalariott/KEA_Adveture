using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtk : MonoBehaviour
{

    //Sound vars
    AudioSource _audioSource;
    [SerializeField] AudioClip CollidePlayerAudio;
    [SerializeField] AudioClip collideAudio;


    //Damage vars
    public float enemyDamage;
    public bool attackPlayer;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (attackPlayer) Invoke(nameof(ShutDownAtk), 0.3f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            attackPlayer = true;            
        }

        //_audioSource.PlayOneShot(collideAudio, 0.7F);
    }

    private void OnTriggerExit(Collider collision)
    {
        attackPlayer = false;
    }

    void ShutDownAtk()
    {
        attackPlayer = false;
    }
}
