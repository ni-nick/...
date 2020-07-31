using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    public void Gameover()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Gameover2()
    {
        SceneManager.LoadScene("GameOver2");
    }

    public void start()
    {
        SceneManager.LoadScene("Fase1");
    }
    public void voltarmenu()
    {
        SceneManager.LoadScene("Abertura");
    }
    public void creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void historia()
    {
        SceneManager.LoadScene("Historia");
    }
}

