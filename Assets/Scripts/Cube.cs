using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    //public Material capMaterial;
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * 2;
    }

    /*void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Saber")
        {
            GameObject[] gameObjects = MeshCut.Cut(gameObject, transform.position, Vector3.down, capMaterial);
        }
    }*/
}
