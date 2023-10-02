using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class button : MonoBehaviour
{
    private bool buttonflag = true; // ボタン押下フラグ
    private float allowTime = 0.7f; // 次ボタンを押せるまでの時間
    private float reloadTime; // ボタンが押せるようになる時刻
    public PlayableDirector playableDirector;//kenさんのモーション関係

    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();//kenさんのモーション関係
    }

    void Update()
    {
        if (!buttonflag)//毎フレームボタン入力許可が降りているかの確認
        {
            float pastTime = Time.time - reloadTime;
            if (pastTime > allowTime)
            {
                buttonflag = true;
            }
        }
    }

    public void OnClick() // ボタンがクリックされたときに、斧のモーションを再生する。
    {
        if (buttonflag)//ボタンの入力許可が降りているか
        {
           PlayTimeline();//kenさんモーション実行

            GameObject axe = GameObject.Find("axe");
            axe.GetComponent<Animator>().SetTrigger("on");
            
            buttonflag = false;
            reloadTime = Time.time; // 現在時刻の取得
        }
    }
    void PlayTimeline()//kenさんモーション実行
    {
        playableDirector.Play();
    }
}