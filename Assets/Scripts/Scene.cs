using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
    public Transform beatPos;
    public Transform mazePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeatRoom()
    {
        transform.position = new Vector3(beatPos.position.x, beatPos.position.y, beatPos.position.z);
    }

    public void MazeRoom()
    {
        transform.position = new Vector3(mazePos.position.x,mazePos.position.y,mazePos.position.z);
    }
    
}
