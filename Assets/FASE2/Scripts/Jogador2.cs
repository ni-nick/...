using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jogador2 : MonoBehaviour
{
    public float forcaPulo;
    public float velocidadeMax;

    public LayerMask chao;
    public Transform terra;

    public int Vida;
    public int Recompensas;

    //variaveis de objetos
    public Text TextVida;
    public Text TextRecompensas;

    public bool isGround;

    public Light luz;

    //tiro do player
    public Animator anim;
    public float fireRate = 0.5f;
    public float nextfire; // quando pode dar o proximo tiro
    public GameObject tiroPefab;
    public Transform shootspawner;

    //chekpoint
    [SerializeField] public Transform player;
    [SerializeField] public Transform PontoRespwn;
    [SerializeField] public Transform player2;
    [SerializeField] public Transform PontoRespwn2;
    [SerializeField] public Transform player3;
    [SerializeField] public Transform PontoRespwn3;

    //sons da cena

    [SerializeField] private AudioSource pulo;
    [SerializeField] private AudioSource moeda;
    [SerializeField] private AudioSource morte; // morte do inimigo 

 //   public bool morreu = false;

    //levar dano do oscuno e do inimigo
    public float danoTempo = 1f;
    private bool levouDano = false;

    void Start()
    {
        TextVida.text = Vida.ToString();
        TextRecompensas.text = Recompensas.ToString();
        //rbody = GetComponent<Rigidbody2D>();

     //   if (!morreu) {
      //      Vida = PlayerPrefs.GetInt("Vida");
       //     morreu = false;
     //   }
    }


        void FixedUpdate(){

        float movimento = Input.GetAxis("Horizontal");

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.velocity = new Vector2(movimento * velocidadeMax, rigidbody.velocity.y);


        if (movimento < 0)
        {
            // GetComponent<SpriteRenderer>().flipX = true;
            transform.localScale = new Vector3(-0.6356f, 0.6153f, 0.7f);

        }
        else if (movimento > 0)
        {
            //  GetComponent<SpriteRenderer>().flipX = false;
            transform.localScale = new Vector3(0.6356f, 0.6153f, 0.7f);
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
            pulo.Play();
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


    void Update()
    {
        isGround = Physics2D.Linecast(transform.position, terra.position, chao);

        if (Input.GetKeyDown(KeyCode.Q) && Time.time > nextfire)
        { 
            nextfire = Time.time + fireRate;
            GetComponent<Animator>().SetBool("atirando", true);
            GameObject tempotiro = Instantiate(tiroPefab, shootspawner.position, shootspawner.rotation);


            if(transform.localScale.x < 0)
            {
            tempotiro.transform.eulerAngles = new Vector3(0, 0, 180);
            }

        }

        else
        {
            GetComponent<Animator>().SetBool("atirando", false);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("moeda"))
       {
            moeda.Play();
            Destroy(collision2D.gameObject);
            Recompensas++;
            TextRecompensas.text = Recompensas.ToString();
        }

        if (collision2D.gameObject.CompareTag("Vida"))
        {
            //moeda.Play();
            Destroy(collision2D.gameObject);
            Vida +=5;
            TextVida.text = Vida.ToString();
        }

        if (collision2D.gameObject.CompareTag("MoedaGanhou"))
        {
            SceneManager.LoadScene("YouWin");
        }

        if (collision2D.gameObject.CompareTag("ZonaMorte"))
        {
            Light l = GameObject.FindWithTag("Luz").GetComponent<Light>();
            l.intensity = 7;
            l.range = 13;

            player.transform.position = PontoRespwn.transform.position;
            StartCoroutine(LevouDanoInimigo());
        }

        if (collision2D.gameObject.CompareTag("ZonaMorte2"))
        {

            Light y = GameObject.FindWithTag("Luz").GetComponent<Light>();
            y.intensity = 8;
            y.range = 12;

            player2.transform.position = PontoRespwn2.transform.position;
            StartCoroutine(LevouDanoInimigo());
        }

        if (collision2D.gameObject.CompareTag("ZonaMorte3"))
        {

           // Light p = GameObject.FindWithTag("Luz").GetComponent<Light>();
           // p.intensity = 7;
          //  p.range = 13;

            player3.transform.position = PontoRespwn3.transform.position;
            StartCoroutine(LevouDanoInimigo());
        }

        if (collision2D.gameObject.CompareTag("Oscuno") && !levouDano)
        {
            StartCoroutine(LevouDano());
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Inimigos"))
        {

            Light k = GameObject.FindWithTag("Luz").GetComponent<Light>();
            k.intensity = 7;
            k.range = 13;

            player.transform.position = PontoRespwn.transform.position;
            StartCoroutine(LevouDanoInimigo());

        }

        if (collision2D.gameObject.CompareTag("plataforma"))
        {
       
           // isGround = true;
        }

        if (collision2D.gameObject.CompareTag("trampolim"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 15f); // aumentar os números, aumenta a força do pulo no trampolim
        }

        if (collision2D.gameObject.CompareTag("auxiliar"))
        {
          //  isGround = true;
        }

        if (collision2D.gameObject.CompareTag("Oscuno") && !levouDano)
        {
            StartCoroutine(LevouDano());
        }
    }


    void OnCollisionExit2D(Collision2D collision2D)
    {

        if (collision2D.gameObject.CompareTag("plataforma"))
        {
           // isGround = false;
        }

        if (collision2D.gameObject.CompareTag("auxiliar"))
        {
           // isGround = false;
        }

    }

    IEnumerator LevouDano()
    {
        levouDano = true;
        Vida--;
        TextVida.text = Vida.ToString();
        if(Vida == 0)
        {
            anim.SetTrigger("morrendo"); 
            Invoke("LunaMorte",1f);

        }

        else
        {
            Physics2D.IgnoreLayerCollision(9,11); // ignorar a camada do player e do inimigo pra poder levar dano
            for(float i = 0; i < danoTempo; i += 0.1f) // vai fazer o sprite piscar pra mostrar que levou dano
            {
                GetComponent<SpriteRenderer>().enabled = false;
                yield return new WaitForSeconds(0.05f);
                GetComponent<SpriteRenderer>().enabled = true;
                yield return new WaitForSeconds(0.05f);
            }
            Physics2D.IgnoreLayerCollision(9, 11, false);
            levouDano = false;
        }
    }

    IEnumerator LevouDanoInimigo()
    {
        levouDano = true;
        Vida-=2;
        
        ////Debug.Log("Vida: " + Vida.ToString());

      // morreu = true;
      //  PlayerPrefs.SetInt("Vida", Vida);

        TextVida.text = Vida.ToString();
        if (Vida == 0)
        {
            anim.SetTrigger("morrendo");
            Invoke("LunaMorte", 1f);

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
        SceneManager.LoadScene("GameOver2");
    }



}
