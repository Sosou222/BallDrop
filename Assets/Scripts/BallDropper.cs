using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDropper : MonoBehaviour
{
    [SerializeField] private float maxLeft;
    [SerializeField] private float maxRight;
    private float moveSpeed = 4.0f;

    private float timer;

    private Ball ballHolding;


    void Update()
    {
        if (Globals.IsGameOver)
            return;

        UpdatePosition();
        UpdateTimer();
        SpawnBall();
        UpdateBallPosition();
        DropBall();
    }

    private void UpdatePosition()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(Time.deltaTime * moveSpeed, 0, 0);
            if (transform.position.x < maxLeft)
            {
                transform.position = new Vector3(maxLeft, transform.position.y, transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(Time.deltaTime * moveSpeed, 0, 0);
            if (transform.position.x > maxRight)
            {
                transform.position = new Vector3(maxRight, transform.position.y, transform.position.z);
            }
        }
    }

    private void UpdateTimer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private void SpawnBall()
    {
        if(timer <=0 && ballHolding == null)
        {
            int level = Random.Range(1, 4);
            ballHolding = BallGenerator.Instance.GenerateBall(new Vector2(transform.position.x, transform.position.y), level, false);
        }
    }

    private void UpdateBallPosition()
    {
        if (ballHolding == null)
            return;

        ballHolding.gameObject.transform.position = transform.position;
    }

    private void DropBall()
    {
        if (timer > 0)
            return;

        if(Input.GetKeyDown(KeyCode.Space) && ballHolding != null)
        {
            ballHolding.SetIsSimulated(true);
            ballHolding = null;
            float timerMax = 1.0f;
            timer = timerMax;
        }
    }
}
