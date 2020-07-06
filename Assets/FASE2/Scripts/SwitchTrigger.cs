using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{

    public AudioClip newTrack;

    private SwitchMusicEnemy theAM;

    void Start()
    {
        theAM = FindObjectOfType<SwitchMusicEnemy>();
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Player")
        {
            if(newTrack != null)
                theAM.ChangeBackMusic(newTrack);
        }
    }
}
