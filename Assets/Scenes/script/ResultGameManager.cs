using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultGameManager : MonoBehaviour
{
    int woodCount=0;//初期化
    public Text woodCountText;
    // Start is called before the first frame update
    void Start()
    {
        woodCountText = GameObject.Find("WoodCountText").GetComponent<Text>(); // 薪の数のUI Textコンポーネントを取得
        woodCount = PlayerPrefs.GetInt("WoodCount");//ゲーム画面から薪の数を取得。
        UpdateWoodCountText();//薪の数を表示する
    }

    // 薪の数をUI Textに表示するメソッド
    private void UpdateWoodCountText()
    {
        woodCountText.text = woodCount.ToString("D2");
    }
    // Update is called once per frame
}
