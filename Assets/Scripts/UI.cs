using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public static UI Instance;

    public Image vidaPlayer;

    public TMP_Text TextoRoundAtual;

    public TMP_Text TextoInimigosRestantes;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    public void SetInimigosRestantes() {
        TextoInimigosRestantes.text = "inimigos: " + GerenteDeInimigos.Instance.InimigosRestantes;

    }

    public void SetRoundAtual()
    {
        TextoRoundAtual.text = "Round: " + GameManager.Instance.RoundAtual;
    }

    public void AtualizaVidaPlayer(float vidaAtual, float vidaMax)
    {
        vidaPlayer.fillAmount = vidaAtual / vidaMax;
    }
}
