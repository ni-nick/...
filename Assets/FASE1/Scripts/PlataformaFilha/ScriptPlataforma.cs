using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlataforma : MonoBehaviour // script para jogador virar filho da plataforma
{

    public GameObject terra;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject == terra)
        {
            terra.transform.parent = transform;
        }
        
    }


    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject == terra)
        {
            terra.transform.parent = null;
        }

    }
}
