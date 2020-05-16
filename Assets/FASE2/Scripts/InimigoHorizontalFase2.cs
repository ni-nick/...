using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoHorizontalFase2 : Inimigo
{
    private bool collidde = false;
    private float move = -2;

    protected override void Update()
    {
  

        GetComponent<Rigidbody2D>().velocity = new Vector2(move, GetComponent<Rigidbody2D>().velocity.y);
        if (collidde)
        {
            Flip();
        }
    }

    public void Flip()
    {
        move *= -1;
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        collidde = false;
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("NGruda"))
        {
            collidde = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("NGruda"))
        {
            collidde = false;
        }
    }

}