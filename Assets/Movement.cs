using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Keys")]
    public KeyCode keyUp;
    public KeyCode keyDown;
    public KeyCode keyRight;
    public KeyCode keyLeft;
    public KeyCode keyRotRight;
    public KeyCode keyRotLeft;
    public KeyCode keyChangeColor;

    [Header("Stats")]
    public float speed;

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
            pos.y += speed;
        }
        else if (Input.GetKey(keyDown))
        {
            pos.y -= speed;
        }
        else if (Input.GetKey(keyRight))
        {
            pos.x += speed;
        }
        else if (Input.GetKey(keyLeft))
        {
            pos.x -= speed;
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
}
