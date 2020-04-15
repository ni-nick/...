using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJogador : MonoBehaviour
{

    public Transform posisaoJogador;

    void Start()
    {
    
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, posisaoJogador.position, 10 * Time.deltaTime);
    }
}
