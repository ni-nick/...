using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlataforma2 : MonoBehaviour // script para jogador virar filho da plataforma
{

    public GameObject player2;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject == player2)
        {
            player2.transform.parent = transform;
        }
        
    }


    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject == player2)
        {
            player2.transform.parent = null;
        }

    }
}
