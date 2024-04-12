using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    Rigidbody2D rb;
    public float Velocidade = 400;
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
}
