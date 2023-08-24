using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : MonoBehaviour
{
    private Rigidbody2D rbody2D;

    public float speed = 5f;   // 横に移動する速度

    private bool isRunAway = false;

    public GameObject fx;

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
            Destroy(this.gameObject);
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