using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght; // largura do sprite do background
    private float StartPosicao; // posição inicial
    private Transform cam; // qual é a câmera

    public float parallaxEfeito; // valor para cada objeto do parallax

    void Start()
    {
        StartPosicao = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x; // pegando a largura do sprite
        cam = Camera.main.transform;   // retorna sempre a câmera principal do jogo
    }

    // Update --> movimento dos sprites na camera
    void Update()
    {
        float rePos = cam.transform.position.x * (1 - parallaxEfeito);
        float distancia = cam.transform.position.x * parallaxEfeito;

        transform.position = new Vector3(StartPosicao + distancia, transform.position.y, transform.position.x); // movimentação parallax
    
        if(rePos > StartPosicao + lenght)
        {
            StartPosicao += lenght;

        }else if(rePos < StartPosicao - lenght)
        {
            StartPosicao -= lenght;
        }
            
    
    
    }
}
