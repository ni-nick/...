using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCutscene : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // quando o objeto para passar de fase tocar no "Player"
        {
            SceneManager.LoadScene("DialogoMaria"); // ele pega a cena atual e encaminha para a cena da cutscene
        }

    }
}