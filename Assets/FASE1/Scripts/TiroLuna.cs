using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroLuna : MonoBehaviour
{

    public float speed = 10;
    public int damage = 1;
    public float tempodestuir = 1.5f;

    void Start()
    {
        Destroy(gameObject, tempodestuir);
    }


    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision2D)
    {
        Destroy(gameObject);
    }
}
