using Pathfinding;
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

    Path path;
    Seeker seeker;
    int currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        animator = gameObject.GetComponent<Animator>();
        seeker = GetComponentInParent<Seeker>();
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
        if (hit.collider != null && hit.collider.tag == "Player" && hit.collider.gameObject.GetComponent<PlayerAttack>().isVisible)
        {
            Debug.Log(hit.collider.gameObject.GetComponent<PlayerAttack>().isVisible);
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            Debug.Log("Player detected, distance is " + distance);
            animator.SetTrigger("EnemyAttack");
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
        }
    }

    public void MoveTo(Vector2 target)
    {
        seeker.StartPath(transform.position, target, OnPathComplete);
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
}
