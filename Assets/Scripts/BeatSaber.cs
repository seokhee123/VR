using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSaber : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 previousPos;
    public Material capMaterial;
    //private GameObject[] sides;
    //public GameObject laser;
    //public GameObject laser;
    // Start is called before the first frame update
    void Start()
    {
       
        //sides = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.up,out hit, 2, layer))
        {
            //Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * hit.distance, Color.red);
            if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
            {
                GameObject[] gameObjects = MeshCut.Cut(hit.transform.gameObject, hit.transform.position, transform.forward, capMaterial);
                for(int i =0; i<gameObjects.Length; i++)
                {
                    gameObjects[i].AddComponent<Rigidbody>();
                }
                //Destroy(hit.transform.gameObject, 3f);
                //Destroy(gameObjects[0], 3f);
                
                
                //Destroy(hit.transform.gameObject);
                //CMeshSlicer.SlicerWorld(hit.transform.gameObject, Vector3.Angle(transform.position - previousPos, hit.transform.up), previousPos , capMaterial);

            }
        }
        previousPos = transform.position;
    }
}
