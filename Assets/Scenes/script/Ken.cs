using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ken : MonoBehaviour
{
    GameObject makiObj;
    GameObject makiPrefab;
    Animator makiAnim = null;
    float respawnTime = 0.2f;//薪再生成のインターバル

    Rigidbody2D rbody2D;
    Animator kenAnim = null;

    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        kenAnim = GetComponent<Animator>();

        makiObj = (GameObject)Resources.Load("Prefabs/maki_standing");
        makiPrefab = Instantiate(makiObj);
        makiAnim = makiPrefab.GetComponent<Animator>();
        makiAnim.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animator/makiAnimator");
    }

    public void Makiwari()
    {
        StartCoroutine(Tap());
    }

    IEnumerator Tap()
    {
        kenAnim.SetBool("tap", true);
        yield return new WaitForSeconds(respawnTime);//薪の再生成まで操作受け付けない
        kenAnim.SetBool("tap", false);
    }

     // プレハブから薪を生成する関数
    void SpawnWood()
    {
        makiPrefab = Instantiate(makiObj);
        makiAnim = makiPrefab.GetComponent<Animator>();
        makiAnim.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animator/makiAnimator");
        makiAnim.SetBool("break", false);
    }

    public IEnumerator MakiBreak()//斧が薪に当たった時の処理
    {
        makiAnim.SetBool("break", true);

        //SEを再生
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }

        GameManager GameManager = FindObjectOfType<GameManager>();
        if (GameManager != null)
            {
                GameManager.IncreaseWoodCount(); // 薪の数を増やす
            }
        yield return new WaitForSeconds(respawnTime);//respawnTIme待つ
        SpawnWood();//生成
    }
}
