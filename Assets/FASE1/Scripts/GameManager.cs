using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
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
               isPaused= true;
        }

       
    }



}
