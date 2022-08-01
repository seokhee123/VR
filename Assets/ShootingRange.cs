using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRange : MonoBehaviour
{
    public Transform[] targetPos;
    public GameObject Cube;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            StartCoroutine("StartGame");
        }
    }

    IEnumerator StartGame()
    {
        
        for(int i = 0; i < 6; i++)
        {
            Instantiate(Cube, targetPos[i].position ,Quaternion.identity);
        }
        gameObject.SetActive(false);
        yield return null;
    }
}
