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









}
