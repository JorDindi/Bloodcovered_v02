using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Animator doorAnim;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (player.GetComponent<PlayerAttack>().enemiesKilled == 5)
        {
            doorAnim.SetTrigger("IsOpened");
            player.GetComponent<PlayerAttack>().enemiesKilled = 0;
        }
    }
}
