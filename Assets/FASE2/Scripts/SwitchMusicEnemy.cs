using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicEnemy : MonoBehaviour
{

    public AudioSource backMusic; // a musica de background do jogo 


    public void ChangeBackMusic(AudioClip music)
    {
        backMusic.Stop();
        backMusic.clip = music;
        backMusic.Play();
    } 
}
