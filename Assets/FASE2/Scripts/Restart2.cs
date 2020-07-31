using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart2 : MonoBehaviour
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

    public void start2()
    {
        SceneManager.LoadScene("Fase2");
    }

    public void ajustessom()
    {
        SceneManager.LoadScene("Ajustes");
    }
    public void voltarmenu()
    {
        SceneManager.LoadScene("Abertura");
    }
    public void creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

}
