using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControll : MonoBehaviour
{
    [Header("Rotation")]
    private int rotation;
    private Quaternion iniRot;
    void OnEnable()
    {
        iniRot = new Quaternion(0,0,0,0);
        rotation = Random.Range(-45, 45);
        transform.Rotate(0, 0, rotation);
    }

    private void OnDisable() {
        transform.localRotation = iniRot;
    }


}
