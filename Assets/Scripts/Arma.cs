using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject BalaInimigo; // Prefab do proj�til
    public Transform InimigoQueAtira; // Ponto de onde os proj�teis ser�o disparados
    public float Forca = 10f; // dANO aplicado ao proj�til ao disparar
    public float intervaloDeTiro = 1f; // Intervalo de tempo entre cada disparo
    private float tempoParaProximoDisparo = 0f; // Tempo at� o pr�ximo disparo
    public int Dano = 1; // Dano da bala 


    void Update()
    {
        // Verifica se j� passou tempo suficiente para disparar novamente
        if (Time.time >= tempoParaProximoDisparo)
        {
            Disparar(); // Chama a fun��o para disparar
            tempoParaProximoDisparo = Time.time + intervaloDeTiro; // Atualiza o tempo para o pr�ximo disparo
        }
    }

    void Disparar()
    {
        // Instancia um novo proj�til no ponto de disparo
        GameObject novoProjetil = Instantiate(BalaInimigo, InimigoQueAtira.position, InimigoQueAtira.rotation);

        // Obt�m o componente Rigidbody do proj�til
        Rigidbody2D rbProjetil = novoProjetil.GetComponent<Rigidbody2D>();

        // Aplica uma for�a ao proj�til para faz�-lo se mover
        rbProjetil.AddForce(InimigoQueAtira.right * Forca, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<InimigoQueAtira>())
        {
            StartCoroutine(collision.gameObject.GetComponent<Player>().LevaDano(Dano));
        }
    }

}
