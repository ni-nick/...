using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{
    public float forcaPulo;
    public float velocidadeMax;

    public int Vida;
    public int Recompensas;

    //variaveis de objetos
    public Text TextVida;
    public Text TextRecompensas;

    public bool isGround;

    public Rigidbody2D rbody;

    [SerializeField] public Transform player;
    [SerializeField] public Transform PontoRespwn;
    [SerializeField] public Transform player2;
    [SerializeField] public Transform PontoRespwn2;

    //levar dano do inimigo
    public float danoTempo = 1f;
    private bool levouDano = false;
    public Animator anim;

    void Start()
    {
        TextVida.text = Vida.ToString();
        TextRecompensas.text = Recompensas.ToString();
        rbody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        float movimento = Input.GetAxis("Horizontal");

        rigidbody.velocity = new Vector2(movimento * velocidadeMax, rigidbody.velocity.y);


        if (movimento < 0)
        {
            //GetComponent<SpriteRenderer>().flipX = true;
            transform.localScale = new Vector3(-0.4625f, 0.45625f, 0.5f);

        }
        else if (movimento > 0)
        {
            //GetComponent<SpriteRenderer>().flipX = false;
            transform.localScale = new Vector3(0.4625f, 0.45625f, 0.5f);
        }

        if (movimento > 0 || movimento < 0)
        {
            GetComponent<Animator>().SetBool("andando", true);
            //GetComponent<Animator>().SetBool("Tuinchi", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("andando", false);
            //GetComponent<Animator>().SetBool("Tuinchi", true);
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
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(collision2D.gameObject);
            Recompensas++;
            TextRecompensas.text = Recompensas.ToString();
        }

        if (collision2D.gameObject.CompareTag("Inimigos"))
        {
           
            rbody.velocity = new Vector2(rbody.velocity.x, 0.0f);
            rbody.AddForce(new Vector2(0, forcaPulo/2));

            Destroy(collision2D.gameObject);
            Recompensas++;
            TextRecompensas.text = Recompensas.ToString();

        }


        if (collision2D.gameObject.CompareTag("Inimigos2"))
        {
            rbody.velocity = new Vector2(rbody.velocity.x, 0.0f);
            rbody.AddForce(new Vector2(0, forcaPulo / 2));

            Destroy(collision2D.gameObject);
            Recompensas+=2;
            TextRecompensas.text = Recompensas.ToString();

        }

        if (collision2D.gameObject.CompareTag("Vida"))
        {
            Destroy(collision2D.gameObject);
           Vida++;
            TextVida.text = Vida.ToString();

        }

        if (collision2D.gameObject.CompareTag("ZonaMorte"))
        {

            rbody.velocity = new Vector2(rbody.velocity.x, 0.0f);
            rbody.AddForce(new Vector2(0, forcaPulo / 2));

            player.transform.position = PontoRespwn.transform.position;
            StartCoroutine(LevouDanoInimigo());
        }

        if (collision2D.gameObject.CompareTag("ZonaMorte2"))
        {
            rbody.velocity = new Vector2(rbody.velocity.x, 0.0f);
            rbody.AddForce(new Vector2(0, forcaPulo / 2));

            player2.transform.position = PontoRespwn2.transform.position;
            StartCoroutine(LevouDanoInimigo());
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Inimigos"))
        {
            player.transform.position = PontoRespwn.transform.position;
            StartCoroutine(LevouDanoInimigo());

        }

        if (collision2D.gameObject.CompareTag("Inimigos2"))
        {
            player2.transform.position = PontoRespwn2.transform.position;
            StartCoroutine(LevouDanoInimigo2());
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

    IEnumerator LevouDanoInimigo()
    {
        
        levouDano = true;
        Vida--;
        TextVida.text = Vida.ToString();
        if (Vida == 0)
        {
            anim.SetTrigger("morrendo");
            Invoke("LunaMorte", 2f);

        }

        else
        {
            Physics2D.IgnoreLayerCollision(9, 11); // ignorar a camada do player e do inimigo pra poder levar dano
            for (float i = 0; i < danoTempo; i += 0.2f) // vai fazer o sprite piscar pra mostrar que levou dano
            {
                GetComponent<SpriteRenderer>().enabled = false;
                yield return new WaitForSeconds(0.1f);
                GetComponent<SpriteRenderer>().enabled = true;
                yield return new WaitForSeconds(0.1f);
            }
            Physics2D.IgnoreLayerCollision(9, 11, false);
            levouDano = false;
        }
    }

    IEnumerator LevouDanoInimigo2()
    {

        levouDano = true;
        Vida-=2;
        TextVida.text = Vida.ToString();
        if (Vida == 0)
        {
            anim.SetTrigger("morrendo");
            Invoke("LunaMorte", 2f);

        }

        else
        {
            Physics2D.IgnoreLayerCollision(9, 11); // ignorar a camada do player e do inimigo pra poder levar dano
            for (float i = 0; i < danoTempo; i += 0.2f) // vai fazer o sprite piscar pra mostrar que levou dano
            {
                GetComponent<SpriteRenderer>().enabled = false;
                yield return new WaitForSeconds(0.1f);
                GetComponent<SpriteRenderer>().enabled = true;
                yield return new WaitForSeconds(0.1f);
            }
            Physics2D.IgnoreLayerCollision(9, 11, false);
            levouDano = false;
        }
    }

    void LunaMorte()
    {
        SceneManager.LoadScene("GameOver");
    }
}

