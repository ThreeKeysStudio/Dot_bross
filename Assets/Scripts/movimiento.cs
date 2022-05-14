using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class movimiento : MonoBehaviour
{

    Rigidbody2D rb2d;
    CircleCollider2D bd2d;
    float horizontal;
    public float velx,vely, veljoy;
    public GameObject sueloInicial;
    bool canJump=true, secondJump=true;
    public Vector2 position;
    public Button salto;
    Vector2 posicionInicial;
    public Joystick joystick;
    public bool pausa;
    bool bder=false, bizq=false; 
    // Start is called before the first frame update
    void Start()
    {
        setSkin();
        rb2d = GetComponent<Rigidbody2D>();
        bd2d = GetComponent<CircleCollider2D>();
        posicionInicial = transform.position;
        Time.timeScale = 1;
        StartCoroutine("caida");
    }
    void FixedUpdate()
    {
        position = transform.position;
        horizontal = Input.GetAxis("Horizontal");

        
        position.x = position.x + velx * horizontal;

        transform.position = position;

        Vector2 direction = Vector2.right * joystick.Horizontal;

        gameObject.transform.Translate(direction * veljoy * Time.fixedDeltaTime);
        
        if (bder == true)
        {
            Vector2 direction2 = Vector2.right * 0.8f;

            gameObject.transform.Translate(direction2 * veljoy * Time.fixedDeltaTime);
        }
        if (bizq == true)
        {
            Vector2 direction2 = Vector2.right * -0.8f;

            gameObject.transform.Translate(direction2 * veljoy * Time.fixedDeltaTime);
        }

        checkPolvoSalto();
    }

    private void checkPolvoSalto()
    {
        
    }
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

    public SpriteRenderer sr;
    public Sprite[] skinJug;
    //public static int index=0;
    public void setSkin()
    {
        int i= PlayerPrefs.GetInt("index");
        sr.sprite = skinJug[i];
    }


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

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("plataforma"))
        {
            transform.parent = null;
        }
    }




}
