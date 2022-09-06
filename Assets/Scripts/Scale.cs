using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public float totalMass = 0;
    public Rigidbody rb;
    public List<GameObject> checkMass = new List<GameObject>();

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Scale")
        {
            checkMass.Add(collision.gameObject);
            //rb = checkMass.GetComponent<Rigidbody>();
            totalMass += rb.mass;
        }
    }
}
