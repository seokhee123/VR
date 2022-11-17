using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRange : MonoBehaviour
{
    public Transform[] targetPos;
    public GameObject Cube;
    public GameObject cubeEffect;
    public GameObject spawnPoint;
    public GameObject DropL;
    public GameObject DropR;
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
        StartCoroutine(StartGame());
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

    int stagenum;
    IEnumerator StartGame()
    {
        while (true)
        {
            stagenum = Random.Range(0, 4);
            if (stagenum == 0)
            {
                Stage1();
            }
            else
            {
                Stage2();
            }
            yield return new WaitForSeconds(2.0f);
        }
    }

    void Stage1()
    {
        int i = Random.Range(0, 6);
        Instantiate(Cube, targetPos[i].position, Quaternion.identity);
    }

    void Stage2()
    {
        GameObject DroplObj = Instantiate(Cube, DropL.transform.position, Quaternion.identity);
        //DroplObj.GetComponent<Rigidbody>();
    }

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
