using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    RaycastHit hit;
    float maxDistance = 50f;
    bool floorCheck = false;
    bool isGameStart;
    bool targetCheck = false;
    int num;

    public float speed = 40;
    public GameObject bullet;
    public Transform barrel;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Awake()
    {
        //num = GetComponent<ShootingRange>().check;
    }
    public void Fire()
    {
        //GameObject spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
        //spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
        audioSource.PlayOneShot(audioClip);
        //Destroy(spawnedBullet, 2);
        if (Physics.Raycast(barrel.transform.position, barrel.transform.forward * maxDistance, out hit, maxDistance))
        {
            if (hit.collider.gameObject.name == "Shooting Start")
            {
                hit.collider.gameObject.GetComponent<ShootingRange>().StartCoroutine("StartGame");
            }
            else if (hit.collider.gameObject.name == "Cube")
            {
                
                Destroy(hit.collider.gameObject);
            }
            else
            {
                floorCheck = false;
                targetCheck = false;
            }
        }
    }

    private void Update()
    {
        
        Debug.DrawRay(barrel.transform.position, barrel.transform.forward * maxDistance, Color.blue, 0.3f);

    }

}
