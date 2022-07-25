using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ControladorVida : MonoBehaviour
{
    //Variables publicas
    public Image c1, c2, c3;
    public GameObject jugador;
    public Button salto, pausa, izq;
    public Joystick joy;
    public Text go;
    public AudioSource sonidoMuerte;
    public Camera mainCamera;

    //Variables
    Image caux;
    ArrayList  lista= new ArrayList();
    static int vida;
    int dinero, dineroC, vidaaux, cont = 3;
    ranking ranking = new ranking();

    //Metodo que se ejecuta al empezar el juego, añade al array las imagenes de los corazones y asigna cuanta vida tiene el jugador
    void Start()
    {
        lista.Add(c1);
        lista.Add(c2);
        lista.Add(c3);
        vida = 3;
        vidaaux = vida;
    }

    //Metodo que ejecuta constantemente, controla que se eliminen los corazones cuando el jugador pierde vida y si no le queda vida empieze el game over
    void Update()
    {
        if (vida < vidaaux) {
            vidaaux = vida;
            StartCoroutine("eliminarCorazon");
        }
        if (vida <= 0)
        {
            StartCoroutine("GameOver");
        }

    }

    //Coorutina que se ejecuta cuando el jugador se cae y pierde vida, elimina el corazon del array
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


    //Metodo que se encarga de controlar cuantas vidas tiene el jugador
    public static void controlarVida(int i) {

        if (vida != 0)
        {
            vida = vida + i;
        }
    }
    
    //Coorutina que se ejecuta cuando al jugador no le quedan vidan
    IEnumerator GameOver() {

        mainCamera.cullingMask = (1 << LayerMask.NameToLayer("DEFAULT"));
        go.gameObject.SetActive(true);
        jugador.gameObject.SetActive(false);
        pausa.gameObject.SetActive(false);
        joy.gameObject.SetActive(false);
        izq.gameObject.SetActive(false);
        salto.gameObject.SetActive(false);
        controlSonidoJuego.cancion.Stop();
        
        yield return new WaitForSeconds(0.1f);
        
        sonidoMuerte.Play();
        Time.timeScale = 0;

        calcularDinero(controladorPuntuacion.p);
        setScore(controladorPuntuacion.p);
    }

    //Metodo que coje la puntuacion que ha conseguido el jugador y la compara para sacar la mejor puntuacion del jugador y tambien se pone en el primer puesto de las tres ultimas
    public void setScore(int score)
    {
        int scoreaux;
        scoreaux = score / 100;

        if(PlayerPrefs.GetInt("best") <= scoreaux)
        {
            PlayerPrefs.SetInt("best", scoreaux);
            ranking.enviarPuntuacion(scoreaux);
        }

        int sc1, sc2;

        sc1= PlayerPrefs.GetInt("sc1");
        sc2 = PlayerPrefs.GetInt("sc2");

        PlayerPrefs.SetInt("sc1", scoreaux);
        PlayerPrefs.SetInt("sc2", sc1);
        PlayerPrefs.SetInt("sc3", sc2);


        
    }
    
    //Metodo que calcula el dinero que consigue el jugador por cada partida. El dinero depende de la puntuacion que consiga el jugador
    public void calcularDinero(int puntuacion)
    {
        dineroC = (int)((puntuacion/100) * 1.5f);
        dinero = PlayerPrefs.GetInt("money") + dineroC;
        PlayerPrefs.SetInt("money", dinero);
    }
}
