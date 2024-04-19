using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenteDeInimigos : MonoBehaviour
{
    
    public GameObject InimigoPrefab;
    public static GerenteDeInimigos Instance;
    public List<Transform> Spawners;
    public int InimigosParaInstanciar;
    public int InimigosJaInstanciadosNoRound;
    public int InimigosRestantes;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }
    
    public void MataInimigo()
    {
        InimigosRestantes--;
        UI.Instance.SetInimigosRestantes();
        ChecaInimigosRestantes();
    }
    public void ChecaInimigosRestantes()
    {
        if(InimigosRestantes <= 0)
        {
            GameManager.Instance.AtualizaRound();
        }
    }

    public void AtualizaInimigosRoundAtual()
    {
        InimigosRestantes = InimigosParaInstanciar;
        StartCoroutine(InstanciaInimigo());
    }

    public IEnumerator InstanciaInimigo()
    {
        for(int i = 0; i < InimigosParaInstanciar; i++)
        {
            Vector3 PosicaoParaInstanciar = Spawners[Random.Range(0, Spawners.Count - 1)].position;
            Instantiate(InimigoPrefab, PosicaoParaInstanciar, Quaternion.identity);
            InimigosJaInstanciadosNoRound++;
            yield return new WaitForSeconds(Random.Range(0f, 2f));
        }
    }
}
