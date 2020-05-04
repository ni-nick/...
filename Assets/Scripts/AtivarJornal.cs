using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtivarJornal : MonoBehaviour
{

    public bool ativar = false;

    public GameObject JornalCanvas;
    public GameObject AtivaJornals;


    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.transform.name == "Jogador")
        {
            ativar = true;

            JornalCanvas.GetComponent<CanvasGroup>().alpha = 1;
            JornalCanvas.SetActive(true);

        }
    }
    void OnTriggerExit2D(Collider2D colliderr2D)
    {
        if (colliderr2D.transform.name == "Jogador")
        {

            ativar = false;
            JornalCanvas.GetComponent<CanvasGroup>().alpha = 0;
           // Destroy(AtivaJornals);
          //  Destroy(JornalCanvas);
        }
    }
    void OnGui()
    {
        if (ativar == true)
        {
            JornalCanvas.SetActive(true);
        }
    }

}
