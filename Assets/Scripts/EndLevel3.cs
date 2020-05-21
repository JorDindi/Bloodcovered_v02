using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel3 : MonoBehaviour
{
    public GameObject player;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (player.GetComponent<PlayerAttack>().enemiesKilled == 3)
        {
            SceneManager.LoadScene("EndScene", LoadSceneMode.Single);
        }
    }
}
