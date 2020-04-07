using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jogador2 : MonoBehaviour
{
    public float forcaPulo;
    public float velocidadeMax;

    public int Vida;
    public int Recompensas;

    //variaveis de objetos
    public Text TextVida;
    public Text TextRecompensas;

    public bool isGround;


    void Start()
    {
        TextVida.text = Vida.ToString();
        TextRecompensas.text = Recompensas.ToString();
    }


    void FixedUpdate()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        float movimento = Input.GetAxis("Horizontal");

        rigidbody.velocity = new Vector2(movimento * velocidadeMax, rigidbody.velocity.y);


        if (movimento < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;

        }
        else if (movimento > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (movimento > 0 || movimento < 0)
        {
            GetComponent<Animator>().SetBool("andando", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("andando", false);
        }


        if (Input.GetKeyDown(KeyCode.UpArrow) && isGround)
        {
            rigidbody.AddForce(new Vector2(0, forcaPulo));
        }

        // pular

        if (isGround)
        {
            GetComponent<Animator>().SetBool("pulando", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("pulando", true);
            GetComponent<Animator>().SetBool("andando", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("moeda"))
        {
            Destroy(collision2D.gameObject);
            Recompensas++;
            TextRecompensas.text = Recompensas.ToString();
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Inimigos"))
        {
            //criar codigo
        }
        if (collision2D.gameObject.CompareTag("plataforma"))
        {
            isGround = true;
        }


        if (collision2D.gameObject.CompareTag("trampolim"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 14f); // aumentar os números, aumenta a força do pulo no trampolim
        }
    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("plataforma"))
        {
            isGround = false;
        }
    }
}

