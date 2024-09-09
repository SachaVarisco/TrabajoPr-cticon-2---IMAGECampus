using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallBounce : MonoBehaviour
{
    [Header("Base stats")]
    private Vector3 initScale;
    private float initSpeed;

    [Header("Speed")]
    private Vector3 lastVel;

    [SerializeField] private float initialSpeed;
    public float speedIncrease;
    private float xDirection;

    private Vector3 direction;


    [Header("Score")]
    [SerializeField] private TextMeshProUGUI p1ScoreTxt;
    [SerializeField] private TextMeshProUGUI p2ScoreTxt;
    private int p1Score;
    private int p2Score;
    private int hitCounter;

    [Header("Advice")]
    [SerializeField] private Sprite goal;
    [SerializeField] private GameObject advice;
    private Image image;


    [Header("Components")]
    private Rigidbody2D rb2D;

    private void Awake()
    {
        initSpeed = speedIncrease;
        initScale = transform.localScale;

        rb2D = GetComponent<Rigidbody2D>();
        image = advice.GetComponent<Image>();
        p1Score = 0;
        p2Score = 0;
        Invoke("StartBall", 2);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetBall();
        }
    }
    private void FixedUpdate()
    {

        rb2D.velocity = Vector2.ClampMagnitude(rb2D.velocity, initialSpeed + (speedIncrease * hitCounter));
        lastVel = rb2D.velocity;
    }

    private void StartBall()
    {
        rb2D.velocity = new Vector2(-1, 0) * (initialSpeed + speedIncrease * hitCounter);
    }

    private void ResetBall()
    {
        speedIncrease = initSpeed;
        transform.localScale = initScale;
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
        switch (other.gameObject.layer)
        {
            case 6: //Player
                PlayerBounce(other.transform);
                break;
            case 8: //Obstacles
                direction = Vector3.Reflect(lastVel.normalized, other.contacts[0].normal);
                rb2D.velocity = direction * Mathf.Max(lastVel.magnitude, 1f);
                break;
            case 7: // Walls
                WallBounce(other.transform);
                break;
            case 10: //Goal
                if (transform.position.x < 0)
                {
                    p1Score++;
                    p1ScoreTxt.text = p1Score.ToString();
                }
                else
                {
                    p2Score++;
                    p2ScoreTxt.text = p2Score.ToString();
                }
                image.sprite = goal;
                advice.SetActive(true);
                ResetBall();
                break;

            case 9: //Shields
                if (transform.position.x > 0)
                {
                    xDirection = -1;
                }
                else
                {
                    xDirection = 1;
                }
                direction = Vector3.Reflect(lastVel.normalized, other.contacts[0].normal);
                rb2D.velocity = direction * Mathf.Max(lastVel.magnitude, 1f);
                break;


            default:
                break;
        }
    }








}
