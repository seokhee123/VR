using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] LayerMask layermask;
    //Scene scene;
    RaycastHit hit;
    float distance = 7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * distance, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out hit, distance, layermask))
        {
            GameObject.Find("XR Origin").GetComponent<Scene>().MazeRoom();
        }
    }
}
