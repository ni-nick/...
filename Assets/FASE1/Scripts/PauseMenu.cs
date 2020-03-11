using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
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
    void pause()
    {
        PainelControleUI.SetActive(true);
        Time.timeScale = 0f;
        jogopause = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Abertura");
    }
}
