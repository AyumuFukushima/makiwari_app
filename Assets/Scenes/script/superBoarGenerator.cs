using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superBoarGenerator : MonoBehaviour
{

    public ParameterTable parameter;
    private float minGenerateFrame;//最小出現間隔
    private float maxGenerateFrame;//最大出現間隔

    GameObject boar;
    Vector3 boarPosition;
    int generateFrame;
    int frame = 0;

    void Start()
    {
        maxGenerateFrame = parameter.superBoarMaxGenerateFrame;//最大出現間隔
        minGenerateFrame = parameter.superBoarMinGenerateFrame;//最小出現間隔
        boar = (GameObject)Resources.Load("Prefabs/superboar");
        boarPosition = Camera.main.ViewportToWorldPoint(new Vector3(-0.1f, 0.28f));
        boarPosition.z = 0;
        generateFrame = (int)Random.Range(minGenerateFrame, maxGenerateFrame);
    }

    void Update()
    {
        ++frame;
        if (frame > generateFrame)
        {
            Instantiate(boar, boarPosition, Quaternion.identity);//イノシシ生成
            generateFrame = (int)Random.Range(minGenerateFrame, maxGenerateFrame);
            frame = 0;
        }
    }
}