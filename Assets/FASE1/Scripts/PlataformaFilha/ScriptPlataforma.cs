using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlataforma : MonoBehaviour // script para jogador virar filho da plataforma
{

    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject == player)
        {
            player.transform.parent = transform;
        }
        
    }


    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject == player)
        {
            player.transform.parent = null;
        }

    }
}
