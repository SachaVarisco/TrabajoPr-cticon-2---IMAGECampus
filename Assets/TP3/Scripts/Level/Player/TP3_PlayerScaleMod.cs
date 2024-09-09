using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP3_PlayerScaleMod : MonoBehaviour
{
    public void SetScaleY(float scale){
        transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
    }
}
