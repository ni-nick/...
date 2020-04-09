using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogo1 : MonoBehaviour
{

    public GameObject painelbox;
    public TextAsset arquivo;
    public string[] texto;
    public Text textoMensagem;

    private int fimdalinha;
    private int linhaAtual;
    public bool ativo;


    void Start()
    {
        if (arquivo != null)
        {
            texto = (arquivo.text.Split('\n'));
        }

        if (fimdalinha == 0)
        {
            fimdalinha = texto.Length;
        }
        desabilitar();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            habilitar();

            if (linhaAtual < fimdalinha)
            {
                textoMensagem.text = texto[linhaAtual];
            }
            if (painelbox.activeSelf)
            {
                linhaAtual += 1;
            }
        }
        if (linhaAtual > fimdalinha)
        {
            linhaAtual = 0;
            desabilitar();
        }
    }

    void habilitar()
    {
        painelbox.SetActive(true);
    }

    void desabilitar()
    {
        painelbox.SetActive(false);
    }


}