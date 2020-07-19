using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlataforma : MonoBehaviour // script para jogador virar filho da plataforma
{

    public GameObject terra;

    private void OnCollisionEnter2D(Collision2D collider2D)
    {
        if(collider2D.gameObject == terra)
        {
            terra.transform.parent = transform;
        }
        
    }


    private void OnCollisionExit2D(Collision2D collider2D)
    {
        if (collider2D.gameObject == terra)
        {
            terra.transform.parent = null;
        }

    }
}
