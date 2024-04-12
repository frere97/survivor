using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Bala : MonoBehaviour
{
    Rigidbody2D rb;
    public float velocity = 500;
    // Start is called before the first frame update
    public int danoDaArma = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyBullet());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.up * velocity;
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<Player>())
        {
            if (collision.GetComponent<Inimigo>())
            {
                collision.GetComponent<Inimigo>().LevaDano(danoDaArma);
            }
            Destroy(gameObject);
        }
    }
}
