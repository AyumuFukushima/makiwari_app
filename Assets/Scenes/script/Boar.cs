using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : MonoBehaviour
{
    private Rigidbody2D rbody2D;
    public float speed = 5f;   // 横に移動する速度
    public static bool flag = false;
    public static float flagReloadTime;
    float animTime = 1.0f;//アニメーション再生時間
    Animator boarAnim = null;//いのししのアニメーションの空
    GameObject fx;
    float fxPositionX=1.0f;//爆発のX座標ずらす距離

    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        fx = (GameObject)Resources.Load("Prefabs/Explode");
    }

    void FixedUpdate()
    {
        rbody2D.velocity = new Vector2(speed, rbody2D.velocity.y);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            flag = true;//当たった時に3秒停止フラグ
            flagReloadTime = Time.time;//当たった時の時間
            Destroy(this.gameObject);
            VibrationMng.ShortVibration();//スマホ振動実行
            Instantiate(fx, new Vector3(rbody2D.transform.position.x+fxPositionX, rbody2D.transform.position.y), Quaternion.identity);
        }
        if (other.gameObject.CompareTag("Catch"))
        {
            Destroy (this.gameObject);
        }
    }

    public void OnClickBoar()//いのししやられアニメーション再生
    {
        boarAnim=this.gameObject.GetComponent<Animator>();//いのししアニメーション取得
        StartCoroutine(BoarTap());
    }
    IEnumerator BoarTap()
    {
        speed *= 0;
        boarAnim.SetBool("boarTap", true);//やられたときのモーションを再生
        yield return new WaitForSeconds(animTime);//一定時間やられたときのアニメーション再生
        Destroy (this.gameObject);//いのしし削除
    }   
}