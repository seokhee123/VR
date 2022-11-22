using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRange : MonoBehaviour
{
    public Transform[] targetPos;
    public GameObject Drop;
    public GameObject Cube;
    public GameObject cubeEffect;
    public GameObject spawnPoint;
    public GameObject DropL;
    public GameObject DropR;
    BoxCollider spawnCollider;

    [Header("Stage Check")]
    [Tooltip("Stage Number")] public int check;
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
        gameObject.transform.position = Drop.transform.position;
        while (true)
        {
            stagenum = Random.Range(0, 4);
            if (stagenum == 0)
            {
                Stage1();
            }
            else if (stagenum == 1)
            {
                Stage2();
            }
            else if(stagenum == 2)
            {
                Stage3();
            }
            else
            {
                Stage4();
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
        //GameObject DroplObjL = Instantiate(Cube, DropL.transform.position, Quaternion.identity);
        //DroplObj.GetComponent<Rigidbody>();
    }

    void Stage3()
    {
        GameObject DropObjR = Instantiate(Cube, DropR.transform.position, Quaternion.identity);
    }

    void Stage4()
    {
        GameObject DrawL = Instantiate(Cube, DropL.transform.position, Quaternion.identity);
        DrawL.GetComponent<Rigidbody>().AddForce(300, 300, 0);
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
