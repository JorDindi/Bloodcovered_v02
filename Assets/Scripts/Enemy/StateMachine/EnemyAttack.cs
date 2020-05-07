using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAttack : StateMachineBehaviour
{
    //public Transform firePoint;
    public GameObject projectilePrefab;
    private AIDestinationSetter aiDestinationSetterSript;
    public float nextTimeToShoot;
    private float shootTimer;
    //private bool canShoot = true;

    Transform transform;
    Transform firePoint;

    public float projectileForce = 20f;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        //set aiDestinationSetterSript reference from scene and start chasing
        if (aiDestinationSetterSript == null)
            aiDestinationSetterSript = animator.gameObject.GetComponentInParent<AIDestinationSetter>();
        aiDestinationSetterSript.enabled = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        shootTimer += Time.deltaTime;

        if (shootTimer > nextTimeToShoot)
        {
            Transform transform = animator.gameObject.GetComponentInChildren<Transform>();
            Transform firePoint = transform.Find("FirePoint");
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * projectileForce, ForceMode2D.Impulse);

            shootTimer = 0;
            //nextTimeToShoot += Time.time;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}


    //void Shoot()
    //{

    //        StartCoroutine(Reload());
    //    }

    //}

    //void Reload()
    //{
    //    invoke()
    //}

    //IEnumerator Reload()
    //{
    //    yield return new WaitForSeconds(1.5f);
    //}
}
