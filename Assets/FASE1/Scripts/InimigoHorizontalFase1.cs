using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoHorizontalFase1 : MonoBehaviour
{
    private bool collidde = false;
    private float move = -2;

    void Update()
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

    void OnCollisionEnter2D(Collision2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("NGruda"))
        {
            collidde = true;
        }
    }

    void OnCollisionExit2D(Collision2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("NGruda"))
        {
            collidde = false;
        }
    }
}
