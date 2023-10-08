using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Boar : MonoBehaviour
{
    private Rigidbody2D rbody2D;
    public float speed = 5f;   // 横に移動する速度
    private bool isRunAway = false;
    public static bool flag = false;
    public static float flagReloadTime;
    GameObject fx;
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
            Instantiate(fx, new Vector3(rbody2D.transform.position.x, rbody2D.transform.position.y), Quaternion.identity);
        }
        if (other.gameObject.CompareTag("Catch"))
        {
            Destroy (this.gameObject);
        }
    }
    public void OnClickBoar()
    {
        if (!isRunAway)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            speed *= -1;
            isRunAway = true;
        }
    }
}