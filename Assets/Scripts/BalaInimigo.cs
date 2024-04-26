using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BalaInimigo : MonoBehaviour
{

    Rigidbody2D rb;
    public float velocity = 500;
    public int Dano = 1;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyBullet());
    }


    void FixedUpdate()
    {
        rb.velocity = transform.up * velocity;
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            StartCoroutine(collision.gameObject.GetComponent<Player>().LevaDano(Dano));
        }
    }

}


