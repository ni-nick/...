using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJogador : MonoBehaviour
{

    public float velocidadeInimigo;
    private Transform posisaoJogador;

    void Start()
    {
        posisaoJogador = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {
        if (posisaoJogador.gameObject != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, posisaoJogador.position, velocidadeInimigo * Time.deltaTime);
        }
    }
}
