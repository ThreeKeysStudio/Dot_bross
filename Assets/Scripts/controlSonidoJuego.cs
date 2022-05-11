using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlSonidoJuego : MonoBehaviour
{
    public AudioSource musicaInicio, musicaLoop;
    public static AudioSource cancion;
    bool inicio=false   ;
    void Start()
    {
        GameObject musicaMenu;
        musicaMenu = GameObject.FindGameObjectWithTag("sonido_menu");
        Destroy(musicaMenu);
        musicaInicio.Play();
        cancion = musicaInicio;
       
    }
    private void Update()
    {
        if (musicaInicio.isPlaying == false && inicio==false)
        {
            musicaLoop.Play();
            cancion = musicaLoop;
            inicio = true;
        }
    }
}
