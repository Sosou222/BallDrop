using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    public static BallGenerator Instance { get; private set; }

    private Dictionary<Vector2, int> ballPointAndLevel = new Dictionary<Vector2, int>();

    private void Start()
    {
        if(Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
    }

    private void Update()
    {
        GenerateBall();
    }

    public void AddBallToQueue(Vector2 point,int level)
    {
        ballPointAndLevel[point] = level;
    }

    private void GenerateBall()
    {
        foreach(var entry in ballPointAndLevel)
        {
            GameObject ballObject = Instantiate(ballPrefab);
            ballObject.transform.position = entry.Key;

            Ball ball = ballObject.GetComponent<Ball>();
            ball.SetBallLevel(entry.Value);
        }

        ballPointAndLevel.Clear();
        
    }
}
