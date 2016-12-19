using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{

    public int maxPlatforms = 25;
    public GameObject platform1;
    public GameObject platform2;
    public GameObject platform3;
    public GameObject finalPlatform;
    public float horizontalMin = 4f;
    public float horizontalMax = 8.5f;
    public float verticalMin = -4f;
    public float verticalMax = 5f;

    private Vector2 originPosition;

    // Use this for initialization
    void Start()
    {
        originPosition = transform.position;

        Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i < maxPlatforms; i++)
        {
            GameObject platform = platform1;
            int rndNum = Random.Range(1, 7);
            if (rndNum == 1)
                platform = platform2;
            if (rndNum == 2)
                platform = platform3;


            Vector2 randomPosition = originPosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
            Instantiate(platform, randomPosition, Quaternion.identity);
            originPosition = randomPosition;
        }

        Vector2 lastPosition = originPosition + new Vector2(20, -30);
        Instantiate(finalPlatform, lastPosition, Quaternion.identity);
    }


}