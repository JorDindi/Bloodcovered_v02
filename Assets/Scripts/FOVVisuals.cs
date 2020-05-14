using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVVisuals : MonoBehaviour
{
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private SpriteRenderer fovSprite;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && playerAttack.isVisible == true)
        {
            fovSprite.color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && playerAttack.isVisible == true)
        {
            fovSprite.color = Color.yellow;
        }
    }
}
