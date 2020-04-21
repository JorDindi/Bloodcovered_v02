using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    private Vector2 randomPoint;

    public float enemySpeed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Patrol", 0f, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        float step = enemySpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, randomPoint, step);
    }

    private void Patrol()
    {
        Vector2 enemyPostition = new Vector2(transform.position.x, transform.position.y);
        randomPoint = enemyPostition + Random.insideUnitCircle * 4.5f;
    }
}
