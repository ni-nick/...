using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarJornal2 : MonoBehaviour
{

    public bool ativar = false;

    public GameObject JornalCanvas;
    public GameObject AtivaJornals;


    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.transform.name == "Player")
        {
            ativar = true;

            JornalCanvas.GetComponent<CanvasGroup>().alpha = 1;
            JornalCanvas.SetActive(true);

        }
    }
    void OnTriggerExit2D(Collider2D colliderr2D)
    {
        if (colliderr2D.transform.name == "Player")
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

