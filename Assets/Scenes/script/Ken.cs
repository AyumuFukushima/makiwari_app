using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ken : MonoBehaviour
{
    GameObject makiObj;
    GameObject makiPrefab;
    Animator makiAnim = null;
    float respawnTime = 0.2f;//薪再生成のインターバル

    //---------------------------------------
    //イノシシ衝突の制御は"1"を付ける
    public bool flag1;
    public float flagReloadTime1;
    private float flagAllowTime1 = 3f; // 次モーションが再生されるまでの時間
    //---------------------------------------
    //ここにヘビの制御の宣言書く予定



    
    //---------------------------------------

    bool isBlinking = false; // 点滅中かどうかを管理するフラグ
    Color originalColor; // キャラクターの元の色

    Rigidbody2D rbody2D;
    Animator kenAnim = null;

    public AudioClip sound1;
    public AudioClip sound2;
    AudioSource audioSource;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        kenAnim = GetComponent<Animator>();

        makiObj = (GameObject)Resources.Load("Prefabs/maki_standing");
        makiPrefab = Instantiate(makiObj);
        makiAnim = makiPrefab.GetComponent<Animator>();
        makiAnim.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animator/makiAnimator");
        originalColor = GetComponent<SpriteRenderer>().color; // キャラクターの元の色を保存

        audioSource = GetComponent<AudioSource>();

        spriteRenderer = GetComponent<SpriteRenderer>();
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
        spriteRenderer.sortingOrder = -1;//ケンさん待機の絵のレイヤーを後ろにする
        if (!audioSource.isPlaying) // オーディオが再生中でない場合のみ再生
        {
            audioSource.PlayOneShot(sound1);//ダメージ音再生
        }

        StartCoroutine(BlinkCharacter());
        float FlagPastTime = Time.time - flagReloadTime1;
        if (FlagPastTime > flagAllowTime1)
        {
            flag1 = false;
            Boar.flag = false;
            audioSource.PlayOneShot(sound2);//復活音再生
            spriteRenderer.sortingOrder = 2;//ケンさん再表示
        }
    }
}

    public void Makiwari()
    {
        StartCoroutine(Tap());
    }

    IEnumerator Tap()
    {
     if (flag1==false) //
     {
        kenAnim.SetBool("tap", true);
        yield return new WaitForSeconds(respawnTime);//薪の再生成まで操作受け付けない
        kenAnim.SetBool("tap", false);
     }
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
    IEnumerator BlinkCharacter()
 {
    isBlinking = true; // 点滅中フラグをセット
    SpriteRenderer characterRenderer = GetComponent<SpriteRenderer>();
    float blinkInterval = 0.2f; // 点滅の間隔

    while (flag1)
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