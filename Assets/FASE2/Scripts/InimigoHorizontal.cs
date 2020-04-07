using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoHorizontal : Inimigo
{

    void Start()
    {
        
    }

   protected override void Update()
    {
        base.Update();

        if (Mathf.Abs (targetdistancia) < distanciaataque)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, velocidade * Time.deltaTime);
        }
    }















    // certo ---------------------------------------------------------------------
    // Update is called once per frame
  //  void Update()
   // {
      //  GetComponent<Rigidbody2D>().velocity = new Vector2(move, GetComponent<Rigidbody2D>().velocity.y);
      //  if (colidde)
      //  {
         //   Flip();
       // }
        
  //  }

   // private void Flip()
  //  {
   //     move *= -1;
    //    GetComponent<SpriteRenderer>().flipX = GetComponent<SpriteRenderer>().flipX;
    //    colidde = false;
   // }

  //  void OnCollisionEnter2D(Collision2D col)
 //   {
    //    if (col.gameObject.CompareTag("Plataforma"))
    //    {
        //    colidde = true;
    //    }
    ///}

    //void OnCollisionExit2D(Collision2D col)
    //{
      //  if (col.gameObject.CompareTag("Plataforma"))
      //  {
        //    colidde = false;
      //  }
   // }
}
