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
            fovSprite.color = new Color(240f/255f, 0f/255f, 0f/255f, 195f/255f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && playerAttack.isVisible == true)
        {
            fovSprite.color = new Color(188f/255f, 235f/255f, 241f/255f, 130f/255f);
        }
    }
}
