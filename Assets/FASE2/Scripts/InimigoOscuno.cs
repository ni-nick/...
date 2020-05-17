using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoOscuno : Inimigo
{
    public GameObject OscunoPoder;
    public Transform tiroSpawnner;
    public float tiroRate;
    private float proximoTiro;


    void Start()
    {

    }

    protected override void Update()
    {

        base.Update();

        if (alvoDiatancia < 0)
        {
            if (!viradoDireira)
            {
                Flip();
            }
        }
        else
        {
            if (viradoDireira)
            {
                Flip();
            }
        }
        if(Mathf.Abs(alvoDiatancia) < diatanciaAtaque && Time.time > proximoTiro)
        {
            anim.SetTrigger("Atacando");
            proximoTiro = Time.time + tiroRate;
        }
    }

    public void Atacando()
    {
        GameObject tempPoder = Instantiate(OscunoPoder, tiroSpawnner.position, tiroSpawnner.rotation);
        if (!viradoDireira)
        {
            tempPoder.transform.eulerAngles = new Vector3(0, 0, 180);
        }
    }

}