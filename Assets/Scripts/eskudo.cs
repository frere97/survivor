using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eskudo : MonoBehaviour
{
    public bool eskudoAtivo = false;
    public float TempoEskudo = 7f;
    public bool PodeAtivaEskudo = false;

    public void Ativa()
    {

        //o escudo ta ativando paizao o problema nao é aqui.
        Debug.Log("eskudo");
        eskudoAtivo = true;
        this.gameObject.SetActive(true);


    }


    public IEnumerator Desativa()
    {
        if (eskudoAtivo == true)
        {
            yield return new WaitForSeconds(TempoEskudo);
            this.gameObject.SetActive(false);
        }
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            StartCoroutine(Desativa());
        }



    }

    //nao serve pra nada filhao.
    public bool ativo
    {
        get { return this.gameObject.activeSelf; }

    }

    public Collider2D Collider { get; internal set; }






}