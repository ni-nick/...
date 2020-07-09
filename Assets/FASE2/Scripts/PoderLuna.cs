using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderLuna : MonoBehaviour
{
    public float velocidade = 10;
    public int dano = 1;
    public float tempoDestruir = 1.5f;


    void Start()
    {
        Destroy(gameObject, tempoDestruir);
    }
    void Update()
    {
        transform.Translate(Vector3.right * velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {

        Inimigo outroInimigo = collider2D.GetComponent<Inimigo>();
        if (outroInimigo != null)
        {
            if (outroInimigo.saude  <= dano)
            {
                outroInimigo.morte.Play();
            }
            outroInimigo.LevaDano(dano);
    
        }

        Destroy(gameObject);
    }
}
