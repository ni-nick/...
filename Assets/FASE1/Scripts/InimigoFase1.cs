using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoFase1 : MonoBehaviour
{

    private bool colidde = false;
    public float move = -2;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(move, GetComponent<Rigidbody2D>().velocity.y);
        if (colidde)
        {
            //Flip();
        }

    }


}
