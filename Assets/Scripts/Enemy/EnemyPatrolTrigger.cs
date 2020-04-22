using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolTrigger : MonoBehaviour
{
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        InvokeRepeating("Patrol", 0f, 10f);
    }

    private void Patrol()
    {
        animator.SetTrigger("Patrol");
    }
}
