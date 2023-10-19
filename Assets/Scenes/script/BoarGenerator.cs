using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarGenerator : MonoBehaviour
{
    public float minGenerateFrame;//最小出現間隔
    public float maxGenerateFrame;//最大出現間隔

    GameObject boar;
    Vector3 boarPosition;
    int generateFrame;
    int frame = 0;

    void Start()
    {
        boar = (GameObject)Resources.Load("Prefabs/eto_remake_inoshishi");
        boarPosition = Camera.main.ViewportToWorldPoint(new Vector3(-0.1f, 0.25f));
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