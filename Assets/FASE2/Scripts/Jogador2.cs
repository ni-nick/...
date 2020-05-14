using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public Animator anim;
    public float fireRate = 0.5f;
    public float nextfire; // quando pode dar o proximo tiro
    public GameObject tiroPefab;
    public Transform shootspawner;

    [SerializeField] public Transform player;
    [SerializeField] public Transform PontoRespwn;
    [SerializeField] public Transform player2;
    [SerializeField] public Transform PontoRespwn2;
    [SerializeField] public Transform player3;
    [SerializeField] public Transform PontoRespwn3;


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

        if (collision2D.gameObject.CompareTag("ZonaMorte"))
        {
            player.transform.position = PontoRespwn.transform.position;
            Vida--;
            TextVida.text = Vida.ToString();
            // GetComponent<Animator>().SetBool("morrendo", true);

            if (Vida == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        if (collision2D.gameObject.CompareTag("ZonaMorte2"))
        {
            player2.transform.position = PontoRespwn2.transform.position;
            Vida--;
            TextVida.text = Vida.ToString();
            // GetComponent<Animator>().SetBool("morrendo", true);

            if (Vida == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        if (collision2D.gameObject.CompareTag("ZonaMorte3"))
        {
            player3.transform.position = PontoRespwn3.transform.position;
            Vida--;
            TextVida.text = Vida.ToString();
            // GetComponent<Animator>().SetBool("morrendo", true);

            if (Vida == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Inimigos"))
        {

            //conferir se da pra ativar o spawner
            Vida--;
            TextVida.text = Vida.ToString();
            if (Vida == 0)
            {
                SceneManager.LoadScene("GameOver");
            }

        }
        if (collision2D.gameObject.CompareTag("plataforma"))
        {
            isGround = true;
        }

        if (collision2D.gameObject.CompareTag("trampolim"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 14f); // aumentar os números, aumenta a força do pulo no trampolim
        }

        if (collision2D.gameObject.CompareTag("auxiliar"))
        {
            isGround = true;
        }
    }


    void OnCollisionExit2D(Collision2D collision2D)
    {

        if (collision2D.gameObject.CompareTag("plataforma"))
        {
            isGround = false;
        }

        if (collision2D.gameObject.CompareTag("auxiliar"))
        {
            isGround = false;
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Time.time > nextfire)
        {

            GetComponent<Animator>().SetBool("atirando", true);
            nextfire = Time.time + fireRate;
            GameObject tempotiro = Instantiate(tiroPefab, shootspawner.position, shootspawner.rotation);
        }
        else
        {
            GetComponent<Animator>().SetBool("atirando", false);
        }
    }

  
}
