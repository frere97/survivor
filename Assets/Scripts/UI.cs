using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static UI Instance;

    public Image vidaPlayer;

    public TMP_Text TextoRoundAtual;

    public TMP_Text TextoInimigosRestantes;

    public GameObject TelaDeMorte;

    public TMP_Text TextoRoundDeMorte;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    private void Start()
    {
        TelaDeMorte.SetActive(false);
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

    public void LigaTelaDeMorte()
    {
        TelaDeMorte.SetActive(true);
        TextoRoundDeMorte.text = "" + GameManager.Instance.RoundAtual;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Reload()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }
}
