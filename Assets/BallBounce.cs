using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float initialSpeed;
    [SerializeField] private float speedIncrease;
    private float xDirection;

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI p1Score;
    [SerializeField] private TextMeshProUGUI p2Score;
    private int hitCounter;

    [Header("Components")]
    private Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Invoke("StartBall", 2);
    }
    private void FixedUpdate()
    {
        rb2D.velocity = Vector2.ClampMagnitude(rb2D.velocity, initialSpeed + (speedIncrease * hitCounter));
    }

    private void StartBall()
    {
        rb2D.velocity = new Vector2(-1, 0) * (initialSpeed + speedIncrease * hitCounter);
    }

    private void ResetBall()
    {
        rb2D.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
        hitCounter = 0;
        Invoke("StartBall", 2);
    }

    private void PlayerBounce(Transform obj)
    {
        hitCounter++;

        float yDirection;
        if (transform.position.x > 0)
        {
            xDirection = -1;
        }
        else
        {
            xDirection = 1;
        }
        yDirection = (transform.position.y - obj.position.y) / obj.GetComponent<Collider2D>().bounds.size.y;
        if (yDirection == 0)
        {
            yDirection = 0.25f;
        }
        rb2D.velocity = new Vector2(xDirection, yDirection) * (initialSpeed + speedIncrease * hitCounter);
    }
    private void WallBounce(Transform wall)
    {

        float yDirection;
        if (transform.position.y > 0)
        {
            yDirection = -1;
        }
        else
        {
            yDirection = 1;
        }


        rb2D.velocity = new Vector2(xDirection, yDirection) * (initialSpeed + speedIncrease * hitCounter);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Goal")
        {
            if (transform.position.x < 0)
            {
                Debug.Log("Punto para P1");
            }
            else
            {
                Debug.Log("Punto para P2");
            }
            ResetBall();
        }

        if (other.gameObject.tag == "Player")
        {
            PlayerBounce(other.transform);
        }
        if (other.gameObject.tag == "Wall")
        {
            WallBounce(other.transform);
        }


    }



}
