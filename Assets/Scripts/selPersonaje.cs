using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class selPersonaje : MonoBehaviour
{
    //Variables publicas
    public GameObject[] skins;
    public TMP_InputField codigoTxt;
    public Text cod1, cod2;

    //variables
    int comprado, valor;
    string nombre, codigo;
    GameObject go;

    //Metodo que se ejecuta al iniciar la tienda
    private void Start()
    {
        //El bucle comprueba una por una que skin esta comprada o no y cual es la que esta seleccionada por el jugador
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
    //Metodo para las skins que necesitan codigo para ser desbloqueadas
    public void setCodigo()
    {
        codigo = codigoTxt.text;

        if (codigo == "1NS1D3H3LPC0D3")
        {
            PlayerPrefs.SetInt("inside", 1);
            cod1.text = "Comprado";
            codigoTxt.text = "";
        }
        else
        {
            StartCoroutine("incorrecto");
        }

        if (codigo == "L1N03ST4B4")
        {
            PlayerPrefs.SetInt("hmjts", 1);
            cod2.text = "Comprado";
            codigoTxt.text = "";
        }
        else
        {
            StartCoroutine("incorrecto");
        }
    }
    //Coorutina usada para cuando un codigo es incorrecto
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

    //Metodo que comprueba si la skin seleccionada por el jugador esta comprada, y si no lo esta comprueba si tiene sufientes monedas.
    public void ipc(int i)
    {
        
        comprado = PlayerPrefs.GetInt(nombre);
        Debug.Log(comprado);
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

    //metodo para asignar un nombre a las skins
    public void setNombre(string n)
    {
        this.nombre = n;
    }
    //metodo para asignar un valor a las skins
    public void setValor(int v)
    {
        this.valor = v;
    }
}
