using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum EnemyState
{
    TestObj,
    Zombie,
    Target
}

public class Enemy : MonoBehaviour
{
    NavMeshAgent nav;
    public EnemyState enemyState;
    public int zombieHp;
    Animator animator;
    public void Start()
    {
        animator = GetComponent<Animator>();
        zombieHp = 3;
    }
    public void ObjControll()
    {
        switch (enemyState)
        {
            case EnemyState.Target: // 타겟 obj
                Destroy(gameObject);
                break;
            case EnemyState.Zombie: // 좀비 obj
                zombieHp--;
                Debug.Log("좀비");
                Debug.Log(zombieHp);
                if (zombieHp == 0)
                {
                    animator.SetBool("isDead", true);
                    Invoke("Destroy",3f);
                }
                break;
        }
    }


    public void Destory()
    {
        Destroy(gameObject);
    }
}
