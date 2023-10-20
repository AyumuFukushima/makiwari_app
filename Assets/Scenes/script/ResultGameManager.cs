using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultGameManager : MonoBehaviour
{
    public ParameterTable parameter;

    int woodCount=0;//初期化
    public Text woodCountText;
    public List<GameObject> gameObjects;

    //薪割り数に応じたリザルト画面表示
    private int veryGoodResult;
    private int GoodResult;
    private int NormalResult;
    private int BadResult;
    private int veryBadResult;

    // Start is called before the first frame update
    void Start()
    {
        //薪割り数に応じたリザルト画面表示
        veryGoodResult = parameter.veryGoodResult;
        GoodResult = parameter.GoodResult;
        NormalResult = parameter.NormalResult;
        BadResult = parameter.BadResult;

        woodCountText = GameObject.Find("WoodCountText").GetComponent<Text>(); // 薪の数のUI Textコンポーネントを取得
        woodCount = PlayerPrefs.GetInt("WoodCount");//ゲーム画面から薪の数を取得。
        UpdateWoodCountText();//薪の数を表示する

        int i;
        //woodCountに応じたリザルトを表示させる。
        switch(woodCount)
        {
            case var _ when woodCount >= veryGoodResult:
                i = 4;
                break;
            case var _ when woodCount >= GoodResult:
                i = 3;
                break;
            case var _ when woodCount >= NormalResult:
                i = 2;
                break;
            case var _ when woodCount >= BadResult:
                i = 1;
                break;
            default:
                i = 0;
                break;
        }
        gameObjects[i].SetActive(true);
    }

    // 薪の数をUI Textに表示するメソッド
    private void UpdateWoodCountText()
    {
        woodCountText.text = woodCount.ToString();
    }
    // Update is called once per frame
}
