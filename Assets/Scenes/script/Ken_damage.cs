using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ken_damage : MonoBehaviour
{
    public bool flag1;
    public float flagReloadTime1;
    private float flagAllowTime1 = 3f; // 次モーションが再生されるまでの時間

    public bool flag2;
    public float flagReloadTime2;
    private float flagAllowTime2 = 3f; // 次モーションが再生されるまでの時間}

    public bool flag3;
    public float flagReloadTime3;
    private float flagAllowTime3 = 3f; // 次モーションが再生されるまでの時間
    
    public bool flag4;
    public float flagReloadTime4;
    private float flagAllowTime4 = 3f; // 次モーションが再生されるまでの時間
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
        if (!flag1)
     {
        flag1 = Boar.flag; // 衝突flag呼び出し
        flagReloadTime1 = Boar.flagReloadTime; // 衝突flagTime呼び出し
     }
        
       if (flag1)
     {
        
        StartCoroutine(BlinkCharacter());
        spriteRenderer.sortingOrder = 2;//ダメージケンさん表示
        float FlagPastTime = Time.time - flagReloadTime1;
        if (FlagPastTime > flagAllowTime1)
        {
            flag1 = false;
            Boar.flag = false;
            spriteRenderer.sortingOrder = -1;//ダメージケンさん再表示
        }
     } 


      if (!flag2)
     {
        flag2 = Snake.flag; // 衝突flag呼び出し
        flagReloadTime2 = Snake.flagReloadTime; // 衝突flagTime呼び出し
     }
        
       if (flag2)
     {
        
        StartCoroutine(BlinkCharacter());
        spriteRenderer.sortingOrder = 2;//ダメージケンさん表示
        float FlagPastTime = Time.time - flagReloadTime2;
        if (FlagPastTime > flagAllowTime2)
        {
            flag2 = false;
            Snake.flag = false;
            spriteRenderer.sortingOrder = -1;//ダメージケンさん再表示
        }
     } 
     if (!flag3)
     {
        flag3 = Spider.flag; // 衝突flag呼び出し
        flagReloadTime3 = Spider.flagReloadTime; // 衝突flagTime呼び出し
     }
        
       if (flag3)
     {
        
        StartCoroutine(BlinkCharacter());
        spriteRenderer.sortingOrder = 2;//ダメージケンさん表示
        float FlagPastTime = Time.time - flagReloadTime3;
        if (FlagPastTime > flagAllowTime3)
        {
            flag3 = false;
            Spider.flag = false;
            spriteRenderer.sortingOrder = -1;//ダメージケンさん再表示
        }
     } 
      if (!flag4)
     {
        flag4 = superBoar.flag; // 衝突flag呼び出し
        flagReloadTime4 = superBoar.flagReloadTime; // 衝突flagTime呼び出し
     }
        
       if (flag4)
     {
        
        StartCoroutine(BlinkCharacter());
        spriteRenderer.sortingOrder = 2;//ダメージケンさん表示
        float FlagPastTime = Time.time - flagReloadTime4;
        if (FlagPastTime > flagAllowTime3)
        {
            flag4 = false;
            superBoar.flag = false;
            spriteRenderer.sortingOrder = -1;//ダメージケンさん再表示
        }
      } 
    }
    IEnumerator BlinkCharacter()
 {
    isBlinking = true; // 点滅中フラグをセット
    SpriteRenderer characterRenderer = GetComponent<SpriteRenderer>();
    float blinkInterval = 0.2f; // 点滅の間隔

    while (flag1 || flag2 || flag3 || flag4)
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
