using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGenerator : MonoBehaviour
{
    public ParameterTable parameter;
    [HideInInspector]
    public float minGenerateFrame;//最小出現間隔
    [HideInInspector]
    public float maxGenerateFrame;//最大出現間隔

    GameObject snake;
    Vector3 snakePosition;
    int generateFrame;
    int frame = 0;

    void Start()
    {
        maxGenerateFrame = parameter.snakeMaxGenerateFrame;//最大出現間隔
        minGenerateFrame = parameter.snakeMinGenerateFrame;//最小出現間隔
        snake = (GameObject)Resources.Load("Prefabs/hebi");
        snakePosition = Camera.main.ViewportToWorldPoint(new Vector3(-0.1f, 0.14f));
        snakePosition.z = 0;
        generateFrame = (int)Random.Range(minGenerateFrame, maxGenerateFrame);
    }

    void Update()
    {
        ++frame;

        if (frame > generateFrame)
        {
            Instantiate(snake, snakePosition, Quaternion.identity);//ヘビ生成
            generateFrame = (int)Random.Range(minGenerateFrame, maxGenerateFrame);
            frame = 0;
        }
    }
}
