using UnityEngine;

[CreateAssetMenu( menuName = "MyGame/Create ParameterTable", fileName = "ParameterTable" )]
public class ParameterTable : ScriptableObject
{
    //いのししのパラメータ
    [Header("boar Settings")]  
    public float boarMinGenerateFrame;
    public float boarMaxGenerateFrame;
    public float boarSpeed;

    //スーパーいのししのパラメータ
    [Header("super boar Settings")]  
    public float superBoarMinGenerateFrame;
    public float superBoarMaxGenerateFrame;
    public float superBoarSpeed;

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

    [Header("後半の敵のポップ時間設定")] 
    public float tempoUpTime;
    public float boarMinPop;
    public int boarTempoUpSpeed;
    public float boarMaxPop;
    public float snakeMinPop;
    public float snakeMaxPop;
    public int snakeTempoUpSpeed;
    public float spiderMinPop;
    public float spiderMaxPop;
    public int spiderTempoUpSpeed;

} // class ParameterTable