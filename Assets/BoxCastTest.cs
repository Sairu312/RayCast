using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCastTest : MonoBehaviour
{
    RaycastHit hit;

    [SerializeField]
    bool isEnable = false;

    private void OnDrawGizmos()
    {
        if (isEnable == false)
            return;

        var scale = transform.lossyScale.x * 0.5f;

        var isHit = Physics.BoxCast(transform.position,
                                    Vector3.one * scale,
                                    -transform.up,
                                    out hit,
                                    transform.rotation);

        if(isHit){
            Gizmos.DrawRay(transform.position, -transform.up * hit.distance);
            Gizmos.DrawWireCube(transform.position - transform.up * hit.distance,
                                Vector3.one * scale * 2);
        }else{
            Gizmos.DrawRay(transform.position, -transform.up * 100);
        }

        Debug.Log(hit.distance);
    }
}