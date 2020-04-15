using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    Animator animator;
    public int enemiesKilled;
    // Start is called before the first frame update
    void Start()
    {
        enemiesKilled = 0;
        animator = gameObject.GetComponent<Animator>();
        gameObject.GetComponentInChildren<CapsuleCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    private void Attack()
    {
        gameObject.GetComponentInChildren<CapsuleCollider2D>().enabled = true;
        animator.SetTrigger("Attack");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            enemiesKilled++;
            Debug.Log(enemiesKilled);
        }
    }
}
