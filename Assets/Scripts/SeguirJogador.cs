using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJogador : MonoBehaviour
{

    public Transform target;



    void Start()
    {
    
    }

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target.position, 5 * Time.deltaTime);

    }
}
