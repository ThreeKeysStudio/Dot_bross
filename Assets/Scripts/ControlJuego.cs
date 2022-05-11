using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlJuego : MonoBehaviour
{
    private void Start()
    {
    }
    public void menu(string level) {
        SceneManager.LoadScene(level);

    }
    public void jugar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("nivel0");
        selControles.opciones = false;
        selControles.jug = true;
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
        selControles.jug = false;
    }
    public void tienda()
    {
        SceneManager.LoadScene("tienda");
    }
    public void reiniciar()
    {
        SceneManager.LoadScene("nivel0");
    }

    bool pausa = false;
    public Text Ipause;
    public void pause()
    {
        if (pausa == true)
        {
            Ipause.gameObject.SetActive(false);
            Time.timeScale = 1;
            controlSonidoJuego.cancion.Play();
            pausa = false;
            
        }
        else
        {
            Ipause.gameObject.SetActive(true);
            Time.timeScale = 0;
            controlSonidoJuego.cancion.Pause();
            pausa = true;
            
        }
        
        
    }
    public void salir() {
        Application.Quit();
    }
}
