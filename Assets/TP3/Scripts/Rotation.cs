using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float rotationSpeed;

    [Header("Keys")]
    [SerializeField] private KeyCode keyRotRight;
    [SerializeField] private KeyCode keyRotLeft;

    void Update()
    {
        if (Input.GetKey(keyRotLeft))
        {
            transform.Rotate(new Vector3(0f, 0f, rotationSpeed * Time.deltaTime * 1000));
        }
        else if (Input.GetKey(keyRotRight))
        {
            transform.Rotate(new Vector3(0f, 0f, -rotationSpeed * Time.deltaTime * 1000));
        }
    }
}
