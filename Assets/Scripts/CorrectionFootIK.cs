using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectionFootIK : MonoBehaviour
{
    [SerializeField] Transform body = default;
    [SerializeField] LayerMask terrainLayer = default;
    [SerializeField] float footSpacing;
    Vector3 oldPosition, currentPosition, newPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = currentPosition;
        Ray ray = new Ray(body.position + (body.right * footSpacing), Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit info, 10, terrainLayer.value))
        {
            
            newPosition = info.point + (body.forward);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(newPosition, 0.01f);
    }
}
