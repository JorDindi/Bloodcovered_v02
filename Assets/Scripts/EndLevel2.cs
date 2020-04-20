using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel2 : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Animator doorAnim;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (player.GetComponent<PlayerAttack>().enemiesKilled == 6)
        {
            doorAnim.SetTrigger("IsOpened2");
            player.GetComponent<PlayerAttack>().enemiesKilled = 0;
        }
    }
}
