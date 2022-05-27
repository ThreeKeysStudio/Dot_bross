using UnityEngine;

public class controlSonidoJuego : MonoBehaviour
{
    public AudioSource musicaInicio, musicaLoop;
    public static AudioSource cancion;
    bool inicio=false;
    void Start()
    {
        GameObject musicaMenu;
        musicaMenu = GameObject.FindGameObjectWithTag("sonido_menu");
        Destroy(musicaMenu);

        cancion = musicaInicio;
        cancion.Play();
    }
    private void Update()
    {

        if (cancion.isPlaying == false && ControlJuego.pausap == false)
        {
            
            cancion = musicaLoop;
            cancion.Play();
        }
    }
}
