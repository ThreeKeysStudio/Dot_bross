using UnityEngine;

public class controlSonidoJuego : MonoBehaviour
{
    //Variables publicas
    public AudioSource musicaInicio, musicaLoop;
    public static AudioSource cancion;

    //Metodo que se ejecuta al empezar el juego
    void Start()
    {
        GameObject musicaMenu;
        musicaMenu = GameObject.FindGameObjectWithTag("sonido_menu");
        Destroy(musicaMenu);

        cancion = musicaInicio;
        cancion.Play();
    }

    //Metodo que controla que la cancion se repita en bucle
    private void Update()
    {
        if (cancion.isPlaying == false && ControlJuego.pausap == false)
        {
            cancion = musicaLoop;
            cancion.Play();
        }
    }
}
