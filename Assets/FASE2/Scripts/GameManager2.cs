using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public GameObject PainelControle;


    public bool isPaused = false;
    public bool play = false;


    void Start()
    {

    }


    void Update()
    {

    }

    public void Play()
    {
        if (play)
        {
            PainelControle.SetActive(false);
            play = false;
        }
        else
        {
            PainelControle.SetActive(true);
            play = true;
        }


    }



    public void Pause()
    {
        if (isPaused)
        {
            PainelControle.SetActive(false);
            isPaused = false;
        }
        else
        {
            PainelControle.SetActive(true);
            isPaused = true;
        }


    }

}
