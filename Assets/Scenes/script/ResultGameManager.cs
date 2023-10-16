using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultGameManager : MonoBehaviour
{
    int woodCount=0;//初期化
    public Text woodCountText;
    public List<GameObject> gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        woodCountText = GameObject.Find("WoodCountText").GetComponent<Text>(); // 薪の数のUI Textコンポーネントを取得
        woodCount = PlayerPrefs.GetInt("WoodCount");//ゲーム画面から薪の数を取得。
        UpdateWoodCountText();//薪の数を表示する

        int i = woodCount switch//woodCountに応じた値をいれる。
        {
            >= 90 => 4,//90以上なら4
            >= 80 => 3,//80以上なら3
            >= 60 => 2,//60以上なら2
            >= 30 => 1,//30以上なら1
            _  => 0//そのほか
        };
        gameObjects[i].SetActive(true);
    }

    // 薪の数をUI Textに表示するメソッド
    private void UpdateWoodCountText()
    {
        woodCountText.text = woodCount.ToString();
    }
    // Update is called once per frame
}
