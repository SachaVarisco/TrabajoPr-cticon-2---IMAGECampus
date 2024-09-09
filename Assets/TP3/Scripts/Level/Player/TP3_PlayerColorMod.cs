using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP3_PlayerColor : MonoBehaviour
{
    private SpriteRenderer  SR;
    private void Awake() {
        SR = GetComponent<SpriteRenderer>();
    }
    public void SetColor(float color){
        SR.color = Color.HSVToRGB(color, 1, 1);
    }
}

