using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject BalaInimigo; // Prefab do projétil
    public Transform InimigoQueAtira; // Ponto de onde os projéteis serão disparados
    public float Forca = 10f; // dANO aplicado ao projétil ao disparar
    public float intervaloDeTiro = 1f; // Intervalo de tempo entre cada disparo
    private float tempoParaProximoDisparo = 0f; // Tempo até o próximo disparo
    public int Dano = 1; // Dano da bala 


    void Update()
    {
        // Verifica se já passou tempo suficiente para disparar novamente
        if (Time.time >= tempoParaProximoDisparo)
        {
            Disparar(); // Chama a função para disparar
            tempoParaProximoDisparo = Time.time + intervaloDeTiro; // Atualiza o tempo para o próximo disparo
        }
    }

    void Disparar()
    {
        // Instancia um novo projétil no ponto de disparo
        GameObject novoProjetil = Instantiate(BalaInimigo, InimigoQueAtira.position, InimigoQueAtira.rotation);

        // Obtém o componente Rigidbody do projétil
        Rigidbody2D rbProjetil = novoProjetil.GetComponent<Rigidbody2D>();

        // Aplica uma força ao projétil para fazê-lo se mover
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
