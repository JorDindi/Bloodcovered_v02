using UnityEngine;
using System.Collections;

public class FollowPlayerCSharp : MonoBehaviour
{

    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 0f;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, speed); //Lerping to the player while smoothing the camera movement.
    }
}