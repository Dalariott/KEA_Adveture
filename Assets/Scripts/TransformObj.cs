using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformObj : MonoBehaviour
{
    public GameObject objPrefab;
    public Transform objPosition;
    private int smashed, anvil;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (smashed >= 3 && anvil >=1)
        {
            Instantiate(objPrefab, objPosition.position, objPosition.rotation);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Anvil")
        {
            anvil = +1;
            Debug.Log("I am touching the Anvil");           
            
        }

        if (collision.gameObject.tag == "Hammer")
        {
            smashed += 1;
            Debug.Log("I am touching the Hammer");
        }
    }

}
