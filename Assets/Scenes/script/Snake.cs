using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float speed = 3f;   // 横に移動する速度

    private Rigidbody2D rbody2D;
    private BoxCollider2D col = null;
    private bool isDead = false;

    public GameObject fx;

    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
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
        /*
        if (other.gameObject.CompareTag("Catch"))
        {
            Destroy (this.gameObject);
        }
        */
    }

    public void OnClickSnake()
    {
        if (!isDead)
        {
            speed = 0f;
            col.enabled = false;
            isDead = true;
        }
    }
}