using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorVida : MonoBehaviour
{
    // Start is called before the first frame update
    public Image c1, c2, c3;
    Image caux;
    ArrayList  lista= new ArrayList();
    public Text go;
    public GameObject jugador;
    public Button salto, pausa, izq;
    public Joystick joy;
    static int vida;
    int vidaaux;

    int cont = 3;
    void Start()
    {
        lista.Add(c1);
        lista.Add(c2);
        lista.Add(c3);
        vida = 3;
        vidaaux = vida;
    }

    // Update is called once per frame
    void Update()
    {


        if (vida < vidaaux) {
            vidaaux = vida;
            StartCoroutine("eliminarCorazon");
        }

        /*if (vida > vidaaux) {
            vidaaux = vida;
            sumarCorazon();
        }*/

        if (vida <= 0)
        {
            StartCoroutine("GameOver");
        }

    }

    /*public void sumarCorazon()
    {
            
            caux = (Image)lista[cont];
            caux.enabled = enabled;
            cont++;

    }*/

    IEnumerator eliminarCorazon() {
            cont--;
            caux = (Image)lista[cont];
            caux.enabled = false;

        for (int i = 0; i <= 4; i++)
        {
            yield return new WaitForSeconds(0.15f);
            jugador.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.15f);
            jugador.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
        }

    }

    public static void controlarVida(int i) {

        if (vida != 0)
        {
            vida = vida + i;
        }
    }

    IEnumerator GameOver() {
        go.gameObject.SetActive(true);
        jugador.gameObject.SetActive(false);
        pausa.gameObject.SetActive(false);
        joy.gameObject.SetActive(false);
        izq.gameObject.SetActive(false);
        salto.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0;
        //siguienteNivel();
        calcularDinero(controladorPuntuacion.p);
        setScore(controladorPuntuacion.p);

        
    }
    public void setScore(int score)
    {
        int scoreaux;
        scoreaux = score / 100;

        if(PlayerPrefs.GetInt("best") <= scoreaux)
        {
            PlayerPrefs.SetInt("best", scoreaux);
        }

        int sc1, sc2;

        sc1= PlayerPrefs.GetInt("sc1");
        sc2 = PlayerPrefs.GetInt("sc2");

        PlayerPrefs.SetInt("sc1", scoreaux);
        PlayerPrefs.SetInt("sc2", sc1);
        PlayerPrefs.SetInt("sc3", sc2);

    }
    public void siguienteNivel()
    {
        SceneManager.LoadScene("nivel1");
    }
    int dinero, dineroC;
    public void calcularDinero(int puntuacion)
    {
        dineroC = (int)((puntuacion/100) * 1.5f);
        dinero = PlayerPrefs.GetInt("money") + dineroC;
        PlayerPrefs.SetInt("money", dinero);
    }
}
