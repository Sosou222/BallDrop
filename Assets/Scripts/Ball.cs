using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private List<Sprite> spriteList = new List<Sprite>();

    private int ballLevel = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Ball>(out Ball ball))
        {
            if (ball.GetBallLevel() != ballLevel)
                return;


            ContactPoint2D contact = collision.contacts[0];
            Debug.Log(contact.point);

            Destroy(gameObject);
        }
    }

    public void SetBallLevel(int level)
    {
        ballLevel = level;
    }

    public int GetBallLevel()
    {
        return ballLevel;
    }
}
