using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodTrailEffect : MonoBehaviour
{
    #region Blood Effect Logic
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float _force = 0f;
    void Awake()
    {
        Destroy(this.gameObject, 7f);
        rb.AddForce(Vector2.one * _force);
    }
    #endregion
}
