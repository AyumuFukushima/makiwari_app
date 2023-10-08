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
        boarPosition = Camera.main.ViewportToWorldPoint(new Vector3(-0.1f, 0.2f));
        boarPosition.z = 0;
    }

    void Update()
    {
        ++frame;
        generateFrame = (int)Random.Range(minGenerateFrame, maxGenerateFrame);

        if (frame > generateFrame)
        {
            Instantiate(boar, boarPosition, Quaternion.identity);
            frame = 0;
        }
    }
}