using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaPlayerColetavel : MonoBehaviour

{
    public static ArmaPlayerColetavel Instance;

    private void Awake()
    {
       if( Instance == null)
        { 
        Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }

        this.gameObject.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            this.gameObject.SetActive(false);
            
        }
        
    }

    
}

