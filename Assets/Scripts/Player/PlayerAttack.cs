using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Sprite deathSprite;
    Animator animator;
    public int enemiesKilledForBlood1;
    public int enemiesKilledForBlood2;
    public int enemiesKilled;
    public bool isVisible = false;


    // Start is called before the first frame update
    void Start()
    {
        enemiesKilled = 0;
        animator = gameObject.GetComponent<Animator>();
        gameObject.GetComponentInChildren<CapsuleCollider2D>().enabled = false;
    }
    
    public void CallHitBoxTrue()
    {
        gameObject.GetComponentInChildren<CapsuleCollider2D>().enabled = true;
    }

    public void CallHitBoxFalse()
    {
        gameObject.GetComponentInChildren<CapsuleCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
        if (enemiesKilled < enemiesKilledForBlood1)
        {
            animator.SetBool("Phase1Blood", false);
            animator.SetBool("Phase2Blood", false);
            isVisible = false;
        }
        else if (enemiesKilledForBlood1 <= enemiesKilled && enemiesKilled < enemiesKilledForBlood2)
        {
            animator.SetBool("Phase1Blood", true);
            animator.SetBool("Phase2Blood", false);
            isVisible = true;
        }
        else
        {
            animator.SetBool("Phase1Blood", true);
            animator.SetBool("Phase2Blood", true);
            isVisible = true;
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            enemiesKilled++;
            Debug.Log(enemiesKilled);
        }
    }
}
