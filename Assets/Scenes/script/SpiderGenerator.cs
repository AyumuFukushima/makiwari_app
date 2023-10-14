using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderGenerator : MonoBehaviour
{
    public float minGenerateFrame;//最小出現間隔
    public float maxGenerateFrame;//最大出現間隔

    GameObject spider;
    Vector3 spiderPosition;
    int generateFrame;
    int frame = 0;

    void Start()
    {
        spider = (GameObject)Resources.Load("Prefabs/spider");
        spiderPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.75f, 1.3f));
        spiderPosition.z = 0;
    }

    void Update()
    {
        ++frame;
        generateFrame = (int)Random.Range(minGenerateFrame, maxGenerateFrame);

        if (frame > generateFrame)
        {
            Instantiate(spider, spiderPosition, Quaternion.identity);//ヘビ生成
            frame = 0;
        }
    }
}
