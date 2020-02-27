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
    public void start()
    {
        SceneManager.LoadScene("Fase1");
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

