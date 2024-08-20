using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [Header("Keys")]
    [SerializeField] private KeyCode keyChangeColor;

    [Header("Components")]
    private SpriteRenderer spriteRen;

    void Awake()
    {
        spriteRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(keyChangeColor))
        {
            spriteRen.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
        }
    }
}
