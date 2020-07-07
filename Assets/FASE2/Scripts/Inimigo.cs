using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

    public int saude;

    public float velocidade;
    public float diatanciaAtaque;
    public GameObject moeda;

    protected Animator anim;
    protected bool viradoDireira = true;
    protected Transform alvo;
    protected float alvoDiatancia;
    protected Rigidbody2D rb2d;

    protected SpriteRenderer sprite;

    //public AudioSource morte; // morte do inimigo 

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        alvo = FindObjectOfType<Jogador2>().transform;

    }


    public void Flip()
    {
        viradoDireira = !viradoDireira;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    protected virtual void Update()
    {
        alvoDiatancia = transform.position.x - alvo.position.x;
    }

    public void LevaDano(int dano)
    {
        saude -= dano;
        if(saude <= 0)
        {
            Instantiate(moeda, transform.position, transform.rotation);

            gameObject.SetActive(false);

            //morte.Play();
            //Destroy(sprite);
            Destroy(gameObject);
        }
        else
        {
            // corrotina do dano
            StartCoroutine(LevaDano());
        }
    }

    // espera segundos antes de continuar 
    IEnumerator LevaDano()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
