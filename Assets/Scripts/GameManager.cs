using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int RoundAtual = 0;


    public static GameManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }
    void Start()
    {
        AtualizaRound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtualizaRound()
    {
        RoundAtual++;
        GerenteDeInimigos.Instance.InimigosParaInstanciar = 2 * RoundAtual + (3 + Player.Instance.vida + Random.Range(0, 3));
        GerenteDeInimigos.Instance.AtualizaInimigosRoundAtual();
        UI.Instance.SetRoundAtual();
        UI.Instance.SetInimigosRestantes();
    }
}
