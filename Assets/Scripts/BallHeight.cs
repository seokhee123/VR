using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallHeight : MonoBehaviour
{
    public int w;
    public ScaleCtrl sc;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.tag == "Scale")
        {
            sc.sum += w;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        sc.sum -= w;
    }
}
