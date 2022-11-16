using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRange : MonoBehaviour
{
    public Transform[] targetPos;
    public GameObject Cube;
    public GameObject cubeEffect;
    public GameObject spawnPoint;
    BoxCollider spawnCollider;

    public int check;
    public int stage = 0;
    public bool isGameStart = false;

    public void Awake()
    {
        spawnCollider = spawnPoint.GetComponent<BoxCollider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("StartGame");
        }
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
        for (int i = 0; i < 6; i++)
        {
            Instantiate(Cube, targetPos[i].position, Quaternion.identity);
        }
        yield return null;
        //yield return StartCoroutine("Stage1");
        //if(stage == 1)
        //yield return StartCoroutine("Stage2");

    }

    IEnumerator Stage1()
    {
        yield return null;
        // int one = 0;
        for (int i = 0; i < 6; i++)
        {
            Instantiate(Cube, targetPos[i].position, Quaternion.identity);
        }
        //stage++;

    }

    /*IEnumerator Stage2()
    {
        SecondSpawn();
        yield return new WaitForSeconds(1.0f);
    }

    void SecondSpawn()
    {
        Instantiate(Cube, Return_RandomPosition(), Quaternion.identity);

    }*/


    // Box 콜라이더의 랜덤 포지션 반환 x,z   y = 0
    Vector3 Return_RandomPosition()
    {
        Vector3 originPos = spawnPoint.transform.position;
        float spawn_x = spawnCollider.bounds.size.x;
        float spawn_z = spawnCollider.bounds.size.z;

        spawn_x = Random.Range((spawn_x / 2) * -1, spawn_x / 2);
        spawn_z = Random.Range((spawn_z / 2) * -1, spawn_z / 2);
        Vector3 RandomPos = new Vector3(spawn_x, 0f, spawn_z);

        Vector3 respawnPoint = originPos + RandomPos;
        return respawnPoint;
    }
}
