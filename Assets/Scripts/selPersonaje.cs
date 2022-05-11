using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selPersonaje : MonoBehaviour
{
    int comprado;
    int valor;
    string nombre;

    GameObject go;
    public GameObject[] skins;

    private void Start()
    {
        for (int i = 0; i < skins.Length; i++)
        {
            go = GameObject.Find(skins[i].name + "/Text");
            if (PlayerPrefs.GetInt(skins[i].name) == 1)
            {
                go.GetComponent<Text>().text = "Comprado";
            }

            if (i == PlayerPrefs.GetInt("index"))
            {
                go.GetComponent<Text>().color = Color.red;
            }

        }
    }
    public void ipc(int i)
    {
        
        comprado = PlayerPrefs.GetInt(nombre);
        go = GameObject.Find(nombre + "/Text");
        if (comprado == 0)
        {
            if (tienda.comprar(valor) == true)
            {
                PlayerPrefs.SetInt(nombre, 1);
                
                go.GetComponent<Text>().text = "Comprado";
            }
        }
        else
        {
            int ind = PlayerPrefs.GetInt("index");
            go = GameObject.Find(skins[ind].name + "/Text");
            go.GetComponent<Text>().color=Color.white;

            PlayerPrefs.SetInt("index", i);
            ind = PlayerPrefs.GetInt("index");
            go = GameObject.Find(skins[ind].name + "/Text");
            go.GetComponent<Text>().color = Color.red;
        }
        
        
    } 
    public void setNombre(string n)
    {
        this.nombre = n;
    }

    public void setValor(int v)
    {
        this.valor = v;
    }
}
