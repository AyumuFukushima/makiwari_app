using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timeLimitInSeconds = 60f; // 制限時間（秒）
    private float currentTime = 0f;
    private bool isTimeUp = false;
    public Text timeText; // UI Textコンポーネントを格納する変数

    private int woodCount = 0; // 薪の数を管理する変数
    public Text woodCountText; // UI Textコンポーネントを格納する変数

    // Start is called before the first frame update
    void Start()
    {
         //制限時間を設定したら、初期値も同じにする
        currentTime = timeLimitInSeconds;
        woodCountText = GameObject.Find("WoodCountText").GetComponent<Text>(); // 薪の数のUI Textコンポーネントを取得
        timeText = GameObject.Find("TimeText").GetComponent<Text>();// UI Textコンポーネントを取得
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
    }

    private void OnTimeUp()
    {
        // ここに制限時間が終了したときの処理を書く
        PlayerPrefs.SetInt("WoodCount", woodCount);//薪の数をリザルト画面に渡す。

        //SEを再生
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }

        //薪の数によってリザルト画面の表示を変更する。
        if(woodCount>=15){//薪を割った数が15以上なら豪華リザルトに遷移
            SceneManager.LoadScene("RichResult");//豪華リザルト画面に遷移
        }
         if(woodCount<=14){//薪を割った数が14以下なら通常リザルトに遷移
            SceneManager.LoadScene("Result");//リザルト通常画面に遷移
        }
    }

    
     //時間をUI Textに表示するメソッド
    private void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timeText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    // 薪の数をUI Textに表示するメソッド
    private void UpdateWoodCountText()
    {
        woodCountText.text = "Wood: " + woodCount.ToString();
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
