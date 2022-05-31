using UnityEngine;

public class controlSonidoMenu : MonoBehaviour
{
    //Variables publicas
    public AudioSource musicaMenuIntro, MusicaMenuLoop;

    //Variables
    private controlSonidoMenu instace;
    bool inicio;

    //Metodo para recojer una instancia del objeto que reproduce la musica
    public controlSonidoMenu Instance
    {
        get
        {
            return instace;
        }
    }

    //Metodo que se ejecuta nada mas abrir la aplicacion
    private void Awake()
    {
        //Busca el objeto y si lo encuentra con valor > 1 lo elimina
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        //si la instancia es diferente a la actual o no es nula tambien la destruye y si no la crea
        if(instace != null && instace != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instace = this;
        }

        //Con esto no se destruira el objeto que contiene la musica mientras navegamos en los menus.
        DontDestroyOnLoad(gameObject);

    }

    //Esto controla que la cancion se ejecute en bucle
    private void Update()
    {
        if (musicaMenuIntro.isPlaying == false && inicio == false)
        {
            MusicaMenuLoop.Play();
            inicio = true;
        }
    }
}
