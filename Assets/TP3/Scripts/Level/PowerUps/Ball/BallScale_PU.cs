using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScale_PU : MonoBehaviour
{
    [SerializeField] private Transform ball;
    private Vector3 initBall;
    [Header ("Advice")]
    [SerializeField] private Sprite grow;
    [SerializeField] private Sprite shrink;
    [SerializeField] private GameObject advice;
    private Image image;
    private void Awake()
    {
        image = advice.GetComponent<Image>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            SetBallScale();
        }
    }

    private void SetBallScale()
    {
        int index = Random.Range(1, 4);
        if (index % 2 == 0)
        {
            image.sprite = grow;
            advice.SetActive(true);
            ball.localScale += new Vector3(0.1f, 0.1f, 0);
        }
        else
        {
            image.sprite = shrink;
            advice.SetActive(true);
            ball.localScale -= new Vector3(0.1f, 0.1f, 0);
        }
        gameObject.SetActive(false);
    }
}
