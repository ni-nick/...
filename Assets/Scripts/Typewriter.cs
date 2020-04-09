using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typewriter : MonoBehaviour
{

    public Text textWriter;
    public float tempoescrita = 0.1f;
    public string Escrevafrase;


    void Start()
    {
        StartCoroutine("mostraTexto", Escrevafrase); // vai começar mostrar a corrotina
    }

    IEnumerator mostraTexto(string textType)
    {
        textWriter.text = "";
        for( int letter = 0; letter <textType.Length; letter++ )
        {
            textWriter.text = textWriter.text + textType[letter];
            yield return new WaitForSeconds (tempoescrita); //tempo que vai levar para terminar de escrever

        }
    }


}
