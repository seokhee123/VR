using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public float totalMass = 0;
    //public List<Rigidbody> rb = new List<Rigidbody>();
    public List<GameObject> checkMass = new List<GameObject>();

    void Update()
    {
    }

/*    void addMass()
    {
        for(int i=0;i<checkMass.Count; i++)
        {
            totalMass += checkMass[i].GetComponent<Rigidbody>().mass;
            
        }
        
    }*/
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Scale")
        {
            checkMass.Add(collision.gameObject);
            totalMass += collision.rigidbody.mass;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Scale")
        {
            //checkMass.Find(x => x.name == collision.gameObject.name);
            checkMass.Remove(collision.gameObject);
            totalMass -= collision.rigidbody.mass;
        }
    }
}
