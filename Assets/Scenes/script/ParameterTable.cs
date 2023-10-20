using UnityEngine;

[CreateAssetMenu( menuName = "MyGame/Create ParameterTable", fileName = "ParameterTable" )]
public class ParameterTable : ScriptableObject
{
    //いのししのパラメータ
    [Header("boar Settings")]  
    public float boarMinGenerateFrame;
    public float boarMaxGenerateFrame;
    public float boarSpeed;

    //へびのパラメータ
    [Header("snake Settings")] 
    public float snakeMinGenerateFrame;
    public float snakeMaxGenerateFrame;
    public float snakeSpeed;

    //くものパラメータ
    [Header("spider Settings")]  
    public float spiderMinGenerateFrame;
    public float spiderMaxGenerateFrame;
    public float spiderSpeed;
    
    [Header("GameTime Settings")]  
    public float time;

    [Header("Result Settings")]  
    public int veryGoodResult;
    public int GoodResult;
    public int NormalResult;
    public int BadResult;  
} // class ParameterTable