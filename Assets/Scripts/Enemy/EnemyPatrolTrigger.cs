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
        if (isPlaying(animator, "Idle"))
            animator.SetTrigger("Patrol");
    }

    bool isPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName))
            return true;
        else
            return false;
    }
}
