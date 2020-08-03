using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAbertura : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine("Wait");

    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("Abertura");
    }
}

