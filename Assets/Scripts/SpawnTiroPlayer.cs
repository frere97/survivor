using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiroPlayer : MonoBehaviour
{
    public GameObject bala;
    public float velocidadeBala;
    public float cadenciaDeTiro = 0.3f;
    bool PodeAtirar;
    void Start()
    {
        PodeAtirar = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && PodeAtirar)
        {
            StartCoroutine(Atira());
        }
    }

    IEnumerator Atira()
    {
        PodeAtirar = false;

        Bala bullet = Instantiate(bala,transform.position, transform.rotation).GetComponent<Bala>();
        bullet.velocity = velocidadeBala; 
        yield return new WaitForSeconds(cadenciaDeTiro);
        PodeAtirar = true;
    }


}
