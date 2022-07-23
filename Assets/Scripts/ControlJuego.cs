using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlJuego : MonoBehaviour
{
    //Variables publicas
    public Image helpI;
    public Image CreditosI;
    public static bool pausap = false;
    public Text Ipause;
    public GameObject[] control;
    //Variables
    bool pausa = false;

    //Metodo que se ejecuta al incio del juego
    private void Start()
    {


        pausap = false;


        
        //control de framerate (now= 60fps)
        Application.targetFrameRate = 60;

        //if que asigna el control seleccionado por el jugador
        if(selControles.jug == true)
        {
            if(PlayerPrefs.GetInt("controles") == 0)
            {
                control[0].gameObject.SetActive(false);
            }
            else
            {
                control[0].gameObject.SetActive(true);
                control[PlayerPrefs.GetInt("controles")].gameObject.SetActive(true);
            }
            
        }

        //if que solo se ejecuta SOLO la primera vez que abres el juego
        if(PlayerPrefs.GetInt("first") == 0)
        {
            PlayerPrefs.SetInt("first", 1);
            PlayerPrefs.SetInt("controles", 2);
            PlayerPrefs.SetInt("index", 0);
            PlayerPrefs.SetInt("red", 1);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            pause();
        }
    }

    //Metodo que al pulsar el boton asociado nos lleva al menu
    public void menu(string level) {
        selControles.jug = false;
        selControles.opciones = false;
        SceneManager.LoadScene(level);
        
    }

    //Metodo que al pulsar el boton asociado empezaria el juego
    public void jugar()
    {
        selControles.jug = true;
        Time.timeScale = 1;
        SceneManager.LoadScene("nivel0");
    }

    //Metodo que al pulsar el boton asociado abre "Como Jugar"
    public void help()
    {
        helpI.gameObject.SetActive(true);  
    }
    //Metodo que al pulsar el boton asociado cierra "Como Jugar"
    public void help2()
    {
        helpI.gameObject.SetActive(false);  
    }

    //Metodo que al pulsar el boton asociado se abre "Creditos"
    public void creditos()
    {
        CreditosI.gameObject.SetActive(true);
    }
    //Metodo que al pulsar el boton asociado se cierra "Creditos"
    public void creditos2()
    {
        CreditosI.gameObject.SetActive(false);
    }

    //Metodo que al pulsar el boton asociado te lleva a las opciones
    public void opciones(string level)
    {
        SceneManager.LoadScene(level);
        selControles.opciones = true;
    }
    //Metodo que al pulsar el boton asociado te lleva a la tienda
    public void tienda()
    {
        SceneManager.LoadScene("tienda");
    }

    //Metodo que al pulsar el boton asociado reinicia el juego
    public void reiniciar()
    {
        SceneManager.LoadScene("nivel0");
    }

    //Metodo que al pulsar el boton asociado abre las redes sociales en los Creditos
    public void enlaces(string url)
    {
        Application.OpenURL(url);
    }


    //Metodo que al pulsar el boton asociado pone pausa al juego y a la musica
    public void pause()
    {
        if (pausa == true)
        {
            if(PlayerPrefs.GetInt("controles") != 0)
            {
                control[PlayerPrefs.GetInt("controles")].gameObject.SetActive(true);
                control[0].gameObject.SetActive(true);
            }
                
            Ipause.gameObject.SetActive(false);
            Time.timeScale = 1;
            controlSonidoJuego.cancion.Play();
            pausa = false;
            pausap = false;
        }
        else
        {
            control[PlayerPrefs.GetInt("controles")].gameObject.SetActive(false);
            control[0].gameObject.SetActive(false);
            Ipause.gameObject.SetActive(true);
            Time.timeScale = 0;
            controlSonidoJuego.cancion.Pause();
            pausa = true;
            pausap = true;


        }
        
    }

    //Metodo que al pulsar el boton asociado cierra el juego
    public void salir() {
        Application.Quit();
    }
}
