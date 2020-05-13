using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScripPlataformaVertical : MonoBehaviour
{
    private bool paraBaixo = true;

    public float velocidade = 3f;

    //pontos que a plataforma vai percorrer
    public Transform pontoA;
    public Transform pontoB;
   
    void Update()
    {
        if(transform.position.y > pontoA.position.y)
        {
            paraBaixo = true;
        }
        if (transform.position.y < pontoB.position.y)
        {
            paraBaixo = false;
        }

        if (paraBaixo)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - velocidade * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + velocidade * Time.deltaTime);
        }
    }
}
