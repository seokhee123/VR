using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scale : MonoBehaviour
{
    
    public TextMeshPro text;

    public float totalMass = 0;
    //public List<Rigidbody> rb = new List<Rigidbody>();
    public List<GameObject> checkMass = new List<GameObject>();
    public GameObject topDoor;
    public GameObject rightDoor;
    public GameObject leftDoor;

    //public Vector3 origin = new Vector3(0, 0, 0);

    public Transform topPos;
    public Transform topOrigin;

    private void Awake()
    {
        //text = GetComponent<TMPro.TextMeshProUGUI>();
    }
    void Update()
    {
        //top.transform.position = topDoor.transform.position;
        if(totalMass >= 3)
        {
            topDoor.transform.position = Vector3.MoveTowards(topDoor.transform.position, topPos.position , 5 * Time.deltaTime);
            Debug.Log("¹ßµ¿");
        }
        else
        {
            topDoor.transform.position = Vector3.MoveTowards(topDoor.transform.position, topOrigin.position , 3 * Time.deltaTime);
            
        }

    }

/*    void addMass()
    {
        for(int i=0;i<checkMass.Count; i++)
        {
            totalMass += checkMass[i].GetComponent<Rigidbody>().mass;
            
        }
        
    }
*/
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Scale")
        {
            checkMass.Add(collision.gameObject);
            totalMass += collision.rigidbody.mass;
            text.text = totalMass.ToString();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Scale")
        {
            //checkMass.Find(x => x.name == collision.gameObject.name);
            checkMass.Remove(collision.gameObject);
            totalMass -= collision.rigidbody.mass;   
            text.text = totalMass.ToString();
        }
    }
}
