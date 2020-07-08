using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanterna : MonoBehaviour
{
    public Light luz;


    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            luz.enabled = !luz.enabled;
        } 
    }
}
