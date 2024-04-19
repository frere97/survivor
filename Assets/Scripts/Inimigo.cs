using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    Rigidbody2D rb;
    public float Velocidade = 400;
    public int vida = 1;
    public int dano = 1;

    public GameObject itemRecuperaVidaPrefab;
    void Start()
    {
        transform.position =  new Vector3(transform.position.x,transform.position.y, 0);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = (Player.Instance.transform.position - transform.position) / 2;
    }

    public void LevaDano(int DanoRecebido)
    {

        vida -= DanoRecebido;

        if (vida <= 0) {
            Morre();
        }
    }

    void Morre()
    {
        if (Random.Range(0, 10) <= (Player.Instance.VidaMax - Player.Instance.vida) * 2)   
        {
            Instantiate(itemRecuperaVidaPrefab, transform.position, transform.rotation);
        }
        GerenteDeInimigos.Instance.MataInimigo();
        Destroy(this.gameObject);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            StartCoroutine(collision.gameObject.GetComponent<Player>().LevaDano(dano));
        }
    }
}
