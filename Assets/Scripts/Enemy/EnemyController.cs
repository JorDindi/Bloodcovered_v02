using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class EnemyController : MonoBehaviour
{
    public Sprite deathSprite;
    private Animator animator;
    public Transform firePoint;
    public GameObject projectilePrefab;
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private AudioSource _as;
    public Transform targetForConeVision;
    public Component aiDestinationSetterSript;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 6.5f);

        // If it hits something...
        if (hit.collider != null && hit.collider.tag == "Player")
        {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            Debug.Log("Player detected, distance is " + distance);
            animator.SetTrigger("Attack");
            //gameObject.GetComponent<EnemyShoot>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AttackPoint")
        {
            ps.Play();
            _as.Play();
            GetComponent<SpriteRenderer>().sprite = deathSprite;
            GetComponent<SpriteRenderer>().sortingOrder = -2;
            Destroy(GetComponent<CapsuleCollider2D>());
            animator.SetBool("IsDead", true);

            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.7f);
            Vector3 scale = new Vector3( 0.8f, 0.8f, 0.8f );
            transform.localScale = scale;
        }
    }
}
