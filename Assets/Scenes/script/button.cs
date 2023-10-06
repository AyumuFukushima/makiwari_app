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
    public bool flag;
    public float flagReloadTime;
    private float flagAllowTime = 3f; // 次モーションが再生されるまでの時間
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();//kenさんのモーション関係
    }
    void Update()
    {
        Debug.Log(flag);
        if(!flag){
        flag = Boar.flag;//衝突flag呼び出し
        flagReloadTime = Boar.flagReloadTime;//衝突flagTime呼び出し
        }
        if(flag){
            float FlagPastTime = Time.time - flagReloadTime;
            if (FlagPastTime > flagAllowTime)
            {
                flag = false;
                Boar.flag=false;
            }
        }
        if (!buttonflag)//毎フレームボタン入力許可が降りているかの確認
        {
            float pastTime = Time.time - reloadTime;
            if (pastTime > allowTime)
            {
                buttonflag = true;
            }
        }
    }
    public void OnClick()
{
    if (flag==false) //
    {
        if(buttonflag)
        {
        PlayTimeline(); // kenさんモーション実行
        GameObject axe = GameObject.Find("axe");
        axe.GetComponent<Animator>().SetTrigger("on");
        buttonflag = false;
        reloadTime = Time.time; // 現在時刻の取得
        }
    }
}
    void PlayTimeline()//kenさんモーション実行
    {
        playableDirector.Play();
    }
}