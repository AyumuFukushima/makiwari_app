using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderGenerator : MonoBehaviour
{
    public ParameterTable parameter;
    private float minGenerateFrame;//最小出現間隔
    private float maxGenerateFrame;//最大出現間隔

    GameObject spider;
    Vector3 spiderPosition;
    int generateFrame;
    int frame = 0;

    void Start()
    {
        maxGenerateFrame = parameter.spiderMaxGenerateFrame;//最大出現間隔
        minGenerateFrame = parameter.spiderMinGenerateFrame;//最小出現間隔
        spider = (GameObject)Resources.Load("Prefabs/spider");
        spiderPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.75f, 1.3f));
        spiderPosition.z = 0;
        generateFrame = (int)Random.Range(minGenerateFrame, maxGenerateFrame);
    }

    void Update()
    {
        ++frame;

        if (frame > generateFrame)
        {
            Instantiate(spider, spiderPosition, Quaternion.identity);//ヘビ生成
            generateFrame = (int)Random.Range(minGenerateFrame, maxGenerateFrame);
            frame = 0;
        }
    }
}
