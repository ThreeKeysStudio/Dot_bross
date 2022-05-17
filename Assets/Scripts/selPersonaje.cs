using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public TMP_InputField codigoTxt;
    string codigo;

    public void setCodigo()
    {
        codigo = codigoTxt.text;

        if (codigo == "1NS1D3H3LPC0D3")
        {
            PlayerPrefs.SetInt("inside", 1);
            go.GetComponent<Text>().text = "Comprado";
            codigoTxt.text = "";
        }
        else
        {
            StartCoroutine("incorrecto");
        }

        if (codigo == "L1N03ST4B4")
        {
            PlayerPrefs.SetInt("hmjts", 1);
            go.GetComponent<Text>().text = "Comprado";
            codigoTxt.text = "";
        }
        else
        {
            StartCoroutine("incorrecto");
        }
    }

    IEnumerator incorrecto()
    {
        codigoTxt.interactable= false;
        codigoTxt.textComponent.color = Color.red;
        codigoTxt.text = "Codigo incorrecto";
        yield return new WaitForSeconds(2);
        codigoTxt.text = "";
        codigoTxt.textComponent.color = Color.black;
        codigoTxt.interactable = true;
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
