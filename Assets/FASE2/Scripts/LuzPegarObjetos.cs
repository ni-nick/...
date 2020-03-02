using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzPegarObjetos : MonoBehaviour
{
    public Material material;
    void Start()
    {
        
        foreach(GameObject objeto in Object.FindObjectsOfType(typeof(GameObject)))
        { 
            if(objeto.tag != "MainCamera" && objeto.GetComponent<SpriteRenderer>() != null)
            {
                objeto.GetComponent<SpriteRenderer>().material = material;
            }
        }
    }
}
