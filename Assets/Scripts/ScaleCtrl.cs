using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCtrl : MonoBehaviour
{
    public int sum;

    private void Update()
    {
        float x = transform.position.y;
        x -= sum * 0.1f;
        transform.position.y = x;
    }
}
