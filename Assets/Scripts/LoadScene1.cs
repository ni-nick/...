using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene1 : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine("Wait");

    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(60);
        SceneManager.LoadScene("Fase1");
    }
}
