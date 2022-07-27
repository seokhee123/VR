using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            //gamemanager.score++;
            Destroy(gameObject);
        }
    }
}
