using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtivarDialogo3 : MonoBehaviour
{

    public bool ativar = false;

    public GameObject FalaCanvas;
    public GameObject AtivaCanvas;


    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.transform.name == "Player")
        {
            ativar = true;

            FalaCanvas.GetComponent<CanvasGroup>().alpha = 1;
            FalaCanvas.SetActive(true);

        }
    }
    void OnTriggerExit2D(Collider2D colliderr2D)
    {
        if (colliderr2D.transform.name == "Player")
        {

            ativar = false;
            FalaCanvas.GetComponent<CanvasGroup>().alpha = 0;
            Destroy(AtivaCanvas);
            Destroy(FalaCanvas);
        }
    }
    void OnGui()
    {
        if (ativar == true)
        {
            FalaCanvas.SetActive(true);
        }
    }

}
