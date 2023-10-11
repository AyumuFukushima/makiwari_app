using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class TimeupGameManager : MonoBehaviour
{
    public int ResultSceneCount = 15;//豪華リザルトのシーンに切り替わる薪の数
    int woodCount=0;//初期化
    public Text woodCountText;
    // Start is called before the first frame update
    void Start()
    {
        woodCountText = GameObject.Find("WoodCountText").GetComponent<Text>(); // 薪の数のUI Textコンポーネントを取得
        woodCount = PlayerPrefs.GetInt("WoodCount");//ゲーム画面から薪の数を取得。
        UpdateWoodCountText();//薪の数を表示する

            StartCoroutine(LoadNormalResultScene());//リザルト画面に切り替え
    }
        // 薪の数をUI Textに表示するメソッド
    private void UpdateWoodCountText()
    {
        woodCountText.text = woodCount.ToString("D3");
    }


    // 通常リザルト画面に遷移する処理
    private IEnumerator LoadNormalResultScene()
    {
        yield return new WaitForSeconds(3.0f); // 3秒間待機
        SceneManager.LoadScene("Result");
    }
}
