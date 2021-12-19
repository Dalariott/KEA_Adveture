using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject objPrefab;
    [SerializeField] Transform objPosition;

    void Start()
    {
        
            Instantiate(objPrefab, objPosition.position, objPosition.rotation);
        
        
    }
}
