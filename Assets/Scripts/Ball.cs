using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private List<Sprite> spriteList = new List<Sprite>();

    private int ballLevel = 1;
    private const int maxLevel = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Ball>(out Ball ball))
        {
            if (ballLevel == maxLevel)
                return;

            if (ball.GetBallLevel() != ballLevel)
                return;

            ContactPoint2D contact = collision.contacts[0];
            BallGenerator.Instance.AddBallToQueue(contact.point, ballLevel + 1);

            Destroy(gameObject);
        }
    }

    public void SetBallLevel(int level)
    {
        ballLevel = level;

        GetComponentInChildren<SpriteRenderer>().sprite = spriteList[level];
    }

    public int GetBallLevel()
    {
        return ballLevel;
    }
}
