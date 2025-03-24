using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class BallGenerator : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    public static BallGenerator Instance { get; private set; }

    private Dictionary<Vector2, int> ballPointAndLevel = new Dictionary<Vector2, int>();

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        GenerateBallsInDictionary();
    }

    public void AddBallToQueue(Vector2 point,int level)
    {
        ballPointAndLevel[point] = level;
    }

    private void GenerateBallsInDictionary()
    {
        foreach(var entry in ballPointAndLevel)
        {
            GenerateBall(entry.Key, entry.Value, true);
        }

        ballPointAndLevel.Clear();
        
    }

    public Ball GenerateBall(Vector2 point, int level, bool isSimulated)
    {
        GameObject ballObject = Instantiate(ballPrefab);
        ballObject.transform.position = point;

        Ball ball = ballObject.GetComponent<Ball>();
        ball.SetBallLevel(level);
        ball.SetIsSimulated(isSimulated);

        return ball;
    }
}
