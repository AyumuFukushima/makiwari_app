using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ParameterTable parameter;
    private float timeLimitInSeconds; // 制限時間（秒）
    private float tempoUpTime;//敵が強くなる時間
    private float boarMinPop; // いのししポップまでの最短時間（敵が強くなる）
    private float boarMaxPop;//いのししポップまでの最長時間（敵が強くなる）
    private float snakeMinPop; // へびポップまでの最短時間（敵が強くなる）
    private float snakeMaxPop;//へびポップまでの最長時間（敵が強くなる）
    private float spiderMinPop; // くもポップまでの最短時間（敵が強くなる）
    private float spiderMaxPop;//くもポップまでの最長時間（敵が強くなる）
    private float currentTime = 0f;
    private bool isTempoUp = false;
    private bool isTimeUp = false;
    public Text timeText; // UI Textコンポーネントを格納する変数
    public Outline outline;

    private int woodCount = 0; // 薪の数を管理する変数
    public Text woodCountText; // UI Textコンポーネントを格納する変数
    private BoarGenerator BoarGenerator;
    private SnakeGenerator SnakeGenerator;
    private SpiderGenerator SpiderGenerator;
    private int seconds;
    public int Seconds
{
    get { return seconds; }
}
    // Start is called before the first frame update
    void Start()
    {
        BoarGenerator =GetComponent<BoarGenerator>();//BoarGeneratorコンポーネントを取得
        SnakeGenerator =GetComponent<SnakeGenerator>();//SnakeGeneratorコンポーネントを取得
        SpiderGenerator =GetComponent<SpiderGenerator>();//SpiderGeneratorコンポーネントを取得

        timeLimitInSeconds = parameter.time;// 制限時間
        tempoUpTime = parameter.tempoUpTime;// 敵が強くなる時間

        boarMinPop = parameter.boarMinPop;// いのししポップまでの最短時間（敵が強くなる）
        boarMaxPop = parameter.boarMaxPop;// いのししポップまでの最長時間（敵が強くなる）
        snakeMinPop = parameter.snakeMinPop;// へびポップまでの最短時間（敵が強くなる）
        snakeMaxPop = parameter.snakeMaxPop;// へびポップまでの最長時間（敵が強くなる）
        spiderMinPop = parameter.spiderMinPop;// くもポップまでの最短時間（敵が強くなる）
        spiderMaxPop = parameter.spiderMaxPop;// くもポップまでの最長時間（敵が強くなる）
        Application.targetFrameRate = 30;
         //制限時間を設定したら、初期値も同じにする
        currentTime = timeLimitInSeconds;
        woodCountText = GameObject.Find("WoodCountText").GetComponent<Text>(); // 薪の数のUI Textコンポーネントを取得
        timeText = GameObject.Find("TimeText").GetComponent<Text>();// UI Textコンポーネントを取得
        outline = GameObject.Find("TimeText").GetComponent<Outline>();
        UpdateWoodCountText(); // 薪の数を表示する
        UpdateTimeText(); // 時間を表示する
    }

    // Update is called once per frame
    void Update()
    {
         if (!isTimeUp)
        {
            // 制限時間が0になるまでカウントダウン
            currentTime -= Time.deltaTime;
            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isTimeUp = true;
                // 制限時間が終了したときの処理を記述
                OnTimeUp();
            }
            UpdateTimeText();// 時間を表示する
        }
        if(!isTempoUp)
        {
            if(currentTime <= tempoUpTime){//tempoUpTimeより下回ると敵が強くなる
                BoarGenerator.minGenerateFrame=boarMinPop;
                BoarGenerator.maxGenerateFrame=boarMaxPop;
                SnakeGenerator.minGenerateFrame=snakeMinPop;
                SnakeGenerator.maxGenerateFrame=snakeMaxPop;
                SpiderGenerator.minGenerateFrame=spiderMinPop;
                SpiderGenerator.maxGenerateFrame=spiderMaxPop;

                isTempoUp = true;
            }
        }
    }

    private void OnTimeUp()
    {
        // ここに制限時間が終了したときの処理を書く
        PlayerPrefs.SetInt("WoodCount", woodCount);//薪の数をリザルト画面に渡す。

        SceneManager.LoadScene("Timeup");//timeup画面に遷移

        //SEを再生
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
        SceneManager.LoadScene("Timeup");//timeup画面に遷移
    }
    

    
     //時間をUI Textに表示するメソッド
    private void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        seconds = Mathf.FloorToInt(currentTime % 60f);
        if(minutes>0){//分を秒に変換する。
            seconds=seconds+minutes*60;
        }
        if(seconds<=10){//10秒以下ならカウントの色を赤色、アウトラインの色を白に変更する。
            timeText.color = Color.red;
            outline.effectColor = Color.white;
            timeText.text = string.Format("のこり"+seconds);
        }else{
        timeText.text = string.Format("のこり"+seconds);
        }
    }
    
    // 薪の数をUI Textに表示するメソッド
    private void UpdateWoodCountText()
    {
        woodCountText.text = woodCount.ToString("D3");
    }

     // 薪の数を増やす関数
    public void IncreaseWoodCount()
    {
        woodCount++;

        UpdateWoodCountText(); // 薪の数を表示を更新する
    }

    public void GameRetry()
    {
        SceneManager.LoadScene("game");
    }
}
