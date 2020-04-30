using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour
{
   [SerializeField] private Text restartText;
   [SerializeField] private PlayerMovement playerMov;
   [SerializeField] private SpriteRenderer playerSprite;
   [SerializeField] private PlayerAttack _playerAttack;
   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.CompareTag("Projectile"))
      {
         restartText.enabled = true;
         playerMov.enabled = false;
         playerSprite.enabled = false;
         _playerAttack.enabled = false;
         if (Input.GetKeyDown(KeyCode.R))
         {
            SceneManager.LoadScene("CurrentWorkingScene", LoadSceneMode.Single);
         }
      }
   }
}
