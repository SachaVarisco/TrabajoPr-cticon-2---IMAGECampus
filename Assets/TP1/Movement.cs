using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Keys")]
    [SerializeField] private KeyCode keyUp;
    [SerializeField] private KeyCode keyDown;
    [SerializeField] private KeyCode keyRight;
    [SerializeField] private KeyCode keyLeft;
    [SerializeField] private KeyCode keyRotRight;
    [SerializeField] private KeyCode keyRotLeft;
    [SerializeField] private KeyCode keyChangeColor;

    [Header("Stats")]
    [SerializeField] private float speed;

    [Header("Components")]
    private SpriteRenderer spriteRen;

    void Awake()
    {
        spriteRen = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey(keyUp))
        {
            pos.y += speed * Time.deltaTime;
        }
        else if (Input.GetKey(keyDown))
        {
            pos.y -= speed * Time.deltaTime;
        }
        else if (Input.GetKey(keyRight))
        {
            pos.x += speed * Time.deltaTime;
        }
        else if (Input.GetKey(keyLeft))
        {
            pos.x -= speed * Time.deltaTime;
        }
        transform.position = pos;
        if (Input.GetKeyDown(keyRotLeft))
        {
            transform.Rotate(new Vector3(0f, 0f, 10f));
        }
        else if (Input.GetKeyDown(keyRotRight))
        {
            transform.Rotate(new Vector3(0f, 0f, -10f));
        }

        if (Input.GetKeyUp(keyChangeColor))
        {
            spriteRen.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
        if (newSpeed < 1.5f)
        {
            speed = newSpeed;
        }
    }
}
