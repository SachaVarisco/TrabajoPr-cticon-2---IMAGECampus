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

    [Header("Stats")]
    [SerializeField] private float speed;

    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey(keyUp))
        {
            pos.y += speed * Time.deltaTime * 1000;
        }
        else if (Input.GetKey(keyDown))
        {
            pos.y -= speed * Time.deltaTime * 1000;
        }
        else if (Input.GetKey(keyRight))
        {
            pos.x += speed * Time.deltaTime * 1000;
        }
        else if (Input.GetKey(keyLeft))
        {
            pos.x -= speed * Time.deltaTime * 1000;
        }
        transform.position = pos;
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
