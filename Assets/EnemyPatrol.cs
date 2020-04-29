using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : StateMachineBehaviour
{
    private Vector2 randomPoint;
    private Transform transform;
    private Transform targetForConeVision;
    public float coneVisionAngle = 5.0f;

    public float enemySpeed = .8f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transform = animator.gameObject.GetComponent<Transform>();
        Vector2 enemyPostition = new Vector2(transform.position.x, transform.position.y);
        randomPoint = enemyPostition + Random.insideUnitCircle * 4.5f;

        //set targetForConeVision reference from scene
        if (targetForConeVision == null)
            targetForConeVision = animator.gameObject.GetComponent<EnemyController>().targetForConeVision;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float step = enemySpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, randomPoint, step);

        //ConeVision
        Vector3 targetDir = targetForConeVision.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);

        if (angle < coneVisionAngle)
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
