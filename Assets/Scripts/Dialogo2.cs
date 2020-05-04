using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo2 : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] falas;
    private int index;
    public float typingSpeed;

    public GameObject continuaButton;


    void Start()
    {
        StartCoroutine(Type());
    }
  
    void Update()
    {
        if(textDisplay.text == falas[index])
        {
            continuaButton.SetActive(true);
        }
    }


    IEnumerator Type()
    {
        foreach (char letter in falas[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void ProximaFala()
    {

        continuaButton.SetActive(false);

        if (index < falas.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continuaButton.SetActive(false);
        }
    }
}
