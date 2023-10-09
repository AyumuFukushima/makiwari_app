using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGenerator : MonoBehaviour
{
    public float minGenerateFrame;//最小出現間隔
    public float maxGenerateFrame;//最大出現間隔

    GameObject snake;
    Vector3 snakePosition;
    int generateFrame;
    int frame = 0;

    void Start()
    {
        snake = (GameObject)Resources.Load("Prefabs/hebi");
        snakePosition = Camera.main.ViewportToWorldPoint(new Vector3(-0.1f, 0.24f));
        snakePosition.z = 0;
    }

    void Update()
    {
        ++frame;
        generateFrame = (int)Random.Range(minGenerateFrame, maxGenerateFrame);

        if (frame > generateFrame)
        {
            Instantiate(snake, snakePosition, Quaternion.identity);//ヘビ生成
            frame = 0;
        }
    }
}
