using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalaInimigo : MonoBehaviour
{

        public bool ativar = false;
        public GameObject canvasinimigo;
        public GameObject inimigoteste;

    void Start()
        {

        }

        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.transform.name == "Jogador")
            {
            ativar = true;

            canvasinimigo.GetComponent<CanvasGroup>().alpha = 1;
            canvasinimigo.SetActive(true);
            Debug.Log("eu passo aqui mas eu não funciono");

            }
        }
        void OnTriggerExit2D(Collider2D colliderr2D)
        {
            if (colliderr2D.transform.name == "Jogador")
            {

            ativar = false;
            canvasinimigo.GetComponent<CanvasGroup>().alpha = 0;
            Destroy(inimigoteste);
        }
        }
            void OnGui()
        {
            if (ativar == true)
            {
            canvasinimigo.SetActive(true);
            }
        }

    }
