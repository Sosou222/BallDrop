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
        //Remove from exclude Layers
        GetComponent<Rigidbody2D>().excludeLayers &= ~(1 << LayerMask.NameToLayer("GameOver"));

        if (collision.gameObject.TryGetComponent<Ball>(out Ball ball))
        {
            if (ballLevel == maxLevel)
                return;

            if (ball.GetBallLevel() != ballLevel)
                return;

            ContactPoint2D contact = collision.contacts[0];
            BallGenerator.Instance.AddBallToQueue(contact.point, ballLevel + 1);

            int scoreBallLevelMult = 5;
            Globals.AddToScore(scoreBallLevelMult * ballLevel);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("GameOver"))
        {
            Debug.Log("Entered gameover");
            Globals.SetGameover(true);
        }
    }

    public void SetBallLevel(int level)
    {
        ballLevel = level;

        GetComponentInChildren<SpriteRenderer>().sprite = spriteList[level];

        float scale = 0.5f * (level - 1);
        gameObject.transform.localScale = Vector3.one + new Vector3(scale, scale, 0);
    }

    public int GetBallLevel()
    {
        return ballLevel;
    }

    public void SetIsSimulated(bool isSimulated)
    {
        GetComponent<Rigidbody2D>().simulated = isSimulated;
    }
}
