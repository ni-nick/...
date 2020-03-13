using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu2 : MonoBehaviour
{
    public static bool jogopause = false;
    public GameObject PainelControleUI;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (jogopause)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void resume()
    {
        PainelControleUI.SetActive(false);
        Time.timeScale = 1f;
        jogopause = false;
    }
    public void pause()
    {
        PainelControleUI.SetActive(true);
        Time.timeScale = 0f;
        jogopause = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Abertura");
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("Fase2");
    }

    public void SairJogo()
    {
        Application.Quit();
        Debug.Log("saindo");
    }
}
