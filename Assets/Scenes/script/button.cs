using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    private bool buttonflag = true; // ボタン押下フラグ
    private float allowTime = 0.7f; // 次ボタンを押せるまでの時間
    private float reloadTime; // ボタンが押せるようになる時刻

    void Update()
    {
        if (!buttonflag)
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
        if (buttonflag)
        {
            GameObject axe = GameObject.Find("axe");
            axe.GetComponent<Animator>().SetTrigger("on");

            buttonflag = false;
            reloadTime = Time.time; // 現在時刻の取得
        }
    }
}