using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ken_damage : MonoBehaviour
{
    public bool flag;
    public float flagReloadTime;
    private float flagAllowTime = 3f; // 次モーションが再生されるまでの時間
    private SpriteRenderer spriteRenderer;

    bool isBlinking = false; // 点滅中かどうかを管理するフラグ
    Color originalColor; // キャラクターの元の色


    void Start()
    {
     spriteRenderer = GetComponent<SpriteRenderer>();
     originalColor = GetComponent<SpriteRenderer>().color; // キャラクターの元の色を保存
    }

    void Update()
    {
        if (!flag)
    {
        flag = Boar.flag; // 衝突flag呼び出し
        flagReloadTime = Boar.flagReloadTime; // 衝突flagTime呼び出し
    }
        
       if (flag)
    {
        Debug.Log(flag);
        StartCoroutine(BlinkCharacter());
        spriteRenderer.sortingOrder = 2;//ダメージケンさん表示
        float FlagPastTime = Time.time - flagReloadTime;
        if (FlagPastTime > flagAllowTime)
        {
            flag = false;
            Boar.flag = false;
            spriteRenderer.sortingOrder = -1;//ダメージケンさん再表示
        }
    } 
    }
    IEnumerator BlinkCharacter()
 {
    isBlinking = true; // 点滅中フラグをセット
    SpriteRenderer characterRenderer = GetComponent<SpriteRenderer>();
    float blinkInterval = 0.2f; // 点滅の間隔

    while (flag)
    {
        characterRenderer.color = new Color(1f, 1f, 1f, 0f); // キャラクターを透明にする
        yield return new WaitForSeconds(blinkInterval);
        characterRenderer.color = originalColor; // 元の色に戻す
        yield return new WaitForSeconds(blinkInterval);
    }

    isBlinking = false; // 点滅中フラグをクリア
    characterRenderer.color = originalColor; // 最終的に元の色に戻す
 }
}
