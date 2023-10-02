using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Boar : MonoBehaviour
{
    private Rigidbody2D rbody2D;
    public float speed = 4f;
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
            //SEを再生
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
            DestroyBoar();
            GameObject axe = GameObject.Find("axe");
            axe.GetComponent<Animator>().SetTrigger("off");
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            DestroyBoar();
            Destroy(other.gameObject);
        }
    }
    private void DestroyBoar()
    {
        Destroy(this.gameObject);
        Instantiate(fx, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
    }
    public void OnClickBoar()
    {
        if (!isRunAway)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            speed *= -1;
            isRunAway = true;
        }
    }
}