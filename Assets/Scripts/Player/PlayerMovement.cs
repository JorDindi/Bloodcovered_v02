using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    [SerializeField] private AudioSource _as;

    Vector2 movement;
    Vector2 mousePos;

    #region Blood Trail Logic
    [SerializeField] private GameObject[] _bloodTrail;
    [SerializeField] private bool isMoving = false;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private float OriginalStartTime = 0f;
    [SerializeField] private float TimePassed = 0f;
    [SerializeField] private float minRandomRange, maxRandomRage = 0f;
    #endregion

    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) 
            || Input.GetKeyDown(KeyCode.D))
        {
            _as.Play();
        }
        
        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S ) || Input.GetKeyUp(KeyCode.A) 
           || Input.GetKeyUp(KeyCode.D))
        {
            _as.Stop();
        }
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
        }

        #region Blood Trail Function
        if (movement.x != 0f || movement.y != 0f)
        {
            isMoving = true;
            if (_playerAttack.enemiesKilledForBlood1 <= _playerAttack.enemiesKilled || _playerAttack.enemiesKilled 
                >= _playerAttack.enemiesKilledForBlood2)
            {
                if (TimePassed <= 0)
                {
                    int randomBloodEffect = Random.Range(0, _bloodTrail.Length);
                    Vector3 bloodPos = new Vector3(Random.Range(minRandomRange,maxRandomRage), 
                        Random.Range(minRandomRange,maxRandomRage));
                    Instantiate(_bloodTrail[randomBloodEffect],transform.position - bloodPos,
                        Quaternion.identity);
                    TimePassed = OriginalStartTime;
                }
            }
        }
        else
        {
            isMoving = false;
        }

        if (TimePassed <= 0)
        {
            TimePassed = OriginalStartTime;
        }
        else
        {
            TimePassed -= Time.deltaTime;
        }

        #endregion

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);



        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
