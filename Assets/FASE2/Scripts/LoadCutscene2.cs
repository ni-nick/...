using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCutscene2 : MonoBehaviour
{
 //   Jogador2 jogador2;

    private void OnTriggerEnter2D(Collider2D other)
    {

       // PlayerPrefs.SetInt("Vida", other.gameObject.GetComponent<Jogador2>().Vida);

        if (other.gameObject.CompareTag("Player")) // quando o objeto para passar de fase tocar no "Player"
        {
            SceneManager.LoadScene("DialogoDamadaMorte"); // ele pega a cena atual e encaminha para a cena da cutscene
        }


    }
}