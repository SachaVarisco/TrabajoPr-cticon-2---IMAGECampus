using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_TP3 : MonoBehaviour
{
    [Header("Keys")]
    [SerializeField] private KeyCode keyUp;
    [SerializeField] private KeyCode keyDown;

    [Header("Stats")]
    [SerializeField] private float speed;

    [Header("Movement")]
    private float verticalMove;
    private Vector2 moveInput;

    [Header("Components")]
    private Rigidbody2D rb2D;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKey(keyUp))
        {
            moveInput = new Vector2(0, speed);
        }
        else if (Input.GetKey(keyDown))
        {
            moveInput = new Vector2(0, -speed);
        }
        else
        {
            moveInput = new Vector2(0, 0);
        }
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb2D.MovePosition(rb2D.position + moveInput * Time.fixedDeltaTime);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
