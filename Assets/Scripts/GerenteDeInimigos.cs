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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstanciaInimigo()
    {
        for(int i = 0; i < InimigosParaInstanciar; i++)
        {
            Vector3 PosicaoParaInstanciar = Spawners[Random.Range(0, Spawners.Count - 1)].position;
            Instantiate(InimigoPrefab, PosicaoParaInstanciar, Quaternion.identity);
        }
    }
}
