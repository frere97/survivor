using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecuperaVida : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player>()  != null)
        {
            if(Player.Instance.vida < Player.Instance.VidaMax)
            {
                Player.Instance.vida++;
                Player.Instance.AtualizaVida();
            }
            Destroy(this.gameObject);
        }
    }
}
