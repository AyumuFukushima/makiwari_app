using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    private Rigidbody2D rbody2D;
    public float speed = 1.0f;   // 縦に移動する速度
    public static bool flag = false;
    public static float flagReloadTime;
    float animTime = 1.5f;//アニメーション再生時間
    Animator spiderAnim = null;//くものアニメーションの空
    GameObject fx;
    float fxPositionY=1.0f;//爆発のY座標ずらす距離

    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        fx = (GameObject)Resources.Load("Prefabs/Explode");
    }

    void FixedUpdate()
    {
        rbody2D.velocity = new Vector2(rbody2D.velocity.x,-speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            flag = true;//当たった時に3秒停止フラグ
            flagReloadTime = Time.time;//当たった時の時間
            Destroy(this.gameObject);
            VibrationMng.ShortVibration();//スマホ振動実行
            Instantiate(fx, new Vector3(rbody2D.transform.position.x, rbody2D.transform.position.y-fxPositionY), Quaternion.identity);
        }
        if (other.gameObject.CompareTag("Catch"))
        {
            Destroy (this.gameObject);
        }    
    }

    public void OnClickspider()//くもをタッチしたとき
    {
        spiderAnim=this.gameObject.GetComponent<Animator>();//くもアニメーション取得
        StartCoroutine(spiderTap());
    }
    IEnumerator spiderTap()
    {
        speed *= 0;
        spiderAnim.SetBool("spiderTap", true);//やられたときのモーションを再生
        yield return new WaitForSeconds(animTime);//一定時間やられたときのアニメーション再生
        Destroy (this.gameObject);//くも削除
    }   
}