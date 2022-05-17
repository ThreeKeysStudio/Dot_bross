using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlJuego : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60;
        if(selControles.jug == true)
        {
            control[PlayerPrefs.GetInt("controles")].gameObject.SetActive(true);
        }

    }

    public void menu(string level) {
        selControles.jug = false;
        selControles.opciones = false;
        SceneManager.LoadScene(level);
        
    }
    public void jugar()
    {
        selControles.jug = true;
        Time.timeScale = 1;
        SceneManager.LoadScene("nivel0");
        
    }
    public Image helpI;
    public Image CreditosI;
    
    public void help()
    {
        helpI.gameObject.SetActive(true);  
    }
    public void help2()
    {
        helpI.gameObject.SetActive(false);  
    }

    public void creditos()
    {
        CreditosI.gameObject.SetActive(true);
    }
    public void creditos2()
    {
        CreditosI.gameObject.SetActive(false);
    }

    public void opciones(string level)
    {
        SceneManager.LoadScene(level);
        selControles.opciones = true;
    }

    public void tienda()
    {
        SceneManager.LoadScene("tienda");
    }
    public void reiniciar()
    {
        SceneManager.LoadScene("nivel0");
    }
    public void enlaces(string url)
    {
        Application.OpenURL(url);
    }

    public static bool pausap = false;
    bool pausa = false;
    public Text Ipause;
    public GameObject[] control;
    
    public void pause()
    {
        if (pausa == true)
        {
            
            control[PlayerPrefs.GetInt("controles")].gameObject.SetActive(true);
            control[0].gameObject.SetActive(true);
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
    public void salir() {
        Application.Quit();
    }
}
