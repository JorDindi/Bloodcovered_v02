using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muzzleFlash : MonoBehaviour
{
    [SerializeField] private Sprite FlashSprite;

    [SerializeField] private int FramesToFlash = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoFlash());
    }

    IEnumerator DoFlash()
    {
        var renderer = GetComponent<SpriteRenderer>();
        var originalSprite = renderer.sprite;
        renderer.sprite = FlashSprite;
        
        var framesFlashed = 0;
        while (framesFlashed < FramesToFlash)
        {
            framesFlashed++;
            yield return null;
        }
        renderer.sprite = originalSprite;
    }
}
