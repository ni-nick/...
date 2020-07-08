using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCutscene : MonoBehaviour
{
   // private int vidas = 0;
    //private string fase2 = "DialogoMaria";


  //  void Start()
   // {
//
  //  }
  //  void Update()
  //  {
    //    if(Application.loadedLevelName == fase2)
     //   {
     //       Jogador.Vida = vidas;
   //     }
   // }

  //  void guardar()
  //  {
   //     vidas = Jogador.Recompensas;
    //}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // quando o objeto para passar de fase tocar no "Player"
        {
          //  guardar();
           // DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene("DialogoMaria"); // ele pega a cena atual e encaminha para a cena da cutscene
        }

    }
}