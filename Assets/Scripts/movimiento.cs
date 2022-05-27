using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class movimiento : MonoBehaviour
{
    //Variables publicas
    public float velx, vely, veljoy;
    public GameObject sueloInicial;
    public Vector2 position;
    public Button salto;
    public Joystick joystick, djoy;
    public bool pausa;
    public SpriteRenderer sr;
    public Sprite[] skinJug;

    //otras variables
    Rigidbody2D rb2d;
    float horizontal;
    bool bder = false, bizq = false, canJump = true, secondJump = true;
    Vector2 posicionInicial;

    //Metodo que se ejecuta al inicio
    void Start()
    {
        setSkin();
        rb2d = GetComponent<Rigidbody2D>();
        posicionInicial = transform.position;
        Time.timeScale = 1;
        StartCoroutine("caida");
    }

    //Metodo que se actualiza cada frame
    void FixedUpdate()
    {
        //esta parte se encarga de recoger los datos de los inputs y la posicion del jugador
        position = transform.position;
        horizontal = Input.GetAxis("Horizontal");

        //esta parte se encarga de hacer la cuenta para aplicar las fisicas dependiendo de la velocidad x que le apliques y mover al personaje
        position.x = position.x + velx * horizontal;
        transform.position = position;

        //esta parte se encarga de recojer los datos de los joystick y mover al jugador aplicando fisicas no tan avanzadas
        //joystick estatico
        Vector2 direction = Vector2.right * joystick.Horizontal;
        gameObject.transform.Translate(direction * veljoy * Time.fixedDeltaTime);
        //joystick dinamico
        Vector2 directionDy = Vector2.right * djoy.Horizontal;
        gameObject.transform.Translate(directionDy * veljoy * Time.fixedDeltaTime);

        //esta parte se encarga de mover al personaje con las flechas de dirección tambien aplicando fuerzas a las fisicas del personaje
        //flecha derecha
        if (bder == true)
        {
            Vector2 direction2 = Vector2.right * 0.8f;

            gameObject.transform.Translate(direction2 * veljoy * Time.fixedDeltaTime);
        }
        //flecha izquierda
        if (bizq == true)
        {
            Vector2 direction2 = Vector2.right * -0.8f;

            gameObject.transform.Translate(direction2 * veljoy * Time.fixedDeltaTime);
        }
    }

    //Corutina que se ejecuta cuando el personaje es eliminado y tiene que reaparecer.
    IEnumerator caida()
    {
        float trans = 1.8f;
        position.x = posicionInicial.x;
        position.y = posicionInicial.y;
        sueloInicial.GetComponent<Renderer>().material.color = new Color(1, 1, 1, trans);
        sueloInicial.SetActive(true);

        for(int i = 0; i <= 15; i++)
        {
            trans -= 0.1f;
            yield return new WaitForSeconds(0.1f);
            sueloInicial.GetComponent<Renderer>().material.color = new Color(1, 1, 1, trans);
        }

        sueloInicial.SetActive(false);
    }
   
    //Serie de metodos para comprobar hacia donde se esta moviendo el jugador
    public void izq()
    {
        bizq = true;
    }
    public void izq2()
    {
        bizq = false;
    }
    public void der()
    {
        bder = true;
    } 
    public void der2()
    {
        bder = false;
    }

    //Metodo con el que se asigna una skin dependiendo de la seleccionada anteriormente en la tienda
    public void setSkin()
    {
        int i= PlayerPrefs.GetInt("index");
        sr.sprite = skinJug[i];
    }

    //metodo que se ejecuta al presionar el boton de salto
    public void jump()
    {
        if (secondJump == true && canJump == false)
        {
            rb2d.velocity = new Vector2(0,0);
            rb2d.AddForce(Vector2.up * vely * 100);
            secondJump = false;
        }

        if (canJump == true)
        {

            rb2d.AddForce(Vector2.up * vely * 100);
            canJump = false;
        }
    }

    //metodo que detecta cuando un GameObject entra en contacto con otro

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("suelo")) {
            canJump = true;
            secondJump = true;
        }
        if (collision.gameObject.CompareTag("caida"))
        {
            StartCoroutine("caida");
            ControladorVida.controlarVida(-1);

            transform.position = position;
        }

        if (collision.gameObject.CompareTag("plataforma"))
        {
            canJump = true;
            secondJump = true;
            transform.parent = collision.transform;
        }

        if (collision.gameObject.CompareTag("enemy"))
        {
            ControladorVida.controlarVida(-1);
        }

        if (collision.gameObject.CompareTag("pinchos"))
        {
            ControladorVida.controlarVida(-1);
        }


    }

    //metodo que detecta cuando un GameObject deja de estar en contacto con otro
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("plataforma"))
        {
            transform.parent = null;
        }
    }




}
