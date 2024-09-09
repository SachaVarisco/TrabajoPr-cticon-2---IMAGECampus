using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PU_BallSpeed : MonoBehaviour
{
    [SerializeField] private BallBounce ball;

    [Header ("Advice")]
    [SerializeField] private Sprite slow;
    [SerializeField] private Sprite fast;
    [SerializeField] private GameObject advice;
    private Image image;


    private float initSpeed;
    private void Awake() {
        image = advice.GetComponent<Image>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        int index = Random.Range(1, 4);
        if (index % 2 == 0)
        {
            image.sprite = slow;
            advice.SetActive(true);
            ball.speedIncrease -= 0.2f;
        }
        else
        {
            image.sprite = fast;
            advice.SetActive(true);
            ball.speedIncrease += 0.2f;
        }
        gameObject.SetActive(false);
    }
}
