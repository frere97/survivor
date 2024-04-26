using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraEstamina : MonoBehaviour
{

    [Range(0, 40)]
    public int Estamina;
    public int estaminaMax = 20;

    public RectTransform uiBar;

    float unidadePorcentagem;
    float estaminaPorcentagemUnidade;
    float custoDashEstamina = 5;
    
    private void Start()
    {
        unidadePorcentagem = 1f / uiBar.anchorMax.x;
        estaminaPorcentagemUnidade = 100f / estaminaMax;
        
    }

    
    private void Update()
    {

        if (Estamina > estaminaMax) Estamina = estaminaMax;
        else if (Estamina < 0) Estamina = 0;

        float PorcentagemAtualEstamina = Estamina * estaminaPorcentagemUnidade;

        uiBar.anchorMax = new Vector2((PorcentagemAtualEstamina * unidadePorcentagem) / 100f, uiBar.anchorMax.y);
    }

    private void OnValidate()
    {
        if (Estamina > estaminaMax) Estamina = estaminaMax;
        else if (Estamina < 0) Estamina = 0;
    }
}
