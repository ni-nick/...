using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

    public int saude;
    public float velocidade;
    public float distanciaataque;
    public GameObject coin;
    public GameObject animacaomorte;

    public Animator anim;
    protected bool facingright = true;
    protected Transform target;
    protected float targetdistancia;
    protected Rigidbody2D rb2d;
    protected SpriteRenderer sprite;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        target = FindObjectOfType<Jogador>().transform;
    }

     protected virtual void Update() // serve para o objeto seguir
       {
       targetdistancia = transform.position.x - target.position.x;

     }

    protected void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void recebeDano (int dano)
    {
        saude -= dano;
        if(saude <= 0)
        {
           // Instantiate(coin, transform.position, transform.rotation);
           // Instantiate(animacaomorte, transform.position, transform.rotation);

            gameObject.SetActive(false);
            Destroy(sprite);
        }
        else
        {
            StartCoroutine(recebeDanoRoutine());
        }
    }

    IEnumerator recebeDanoRoutine()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
