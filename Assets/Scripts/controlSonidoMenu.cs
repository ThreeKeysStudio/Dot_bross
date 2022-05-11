using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlSonidoMenu : MonoBehaviour
{
    private controlSonidoMenu instace;
    public AudioSource musicaMenuIntro,MusicaMenuLoop;
    bool inicio;
    public controlSonidoMenu Instance
    {
        get
        {
            return instace;
        }
    }

    private void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        if(instace != null && instace != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instace = this;
        }
        DontDestroyOnLoad(gameObject);

    }

    private void Update()
    {
        if (musicaMenuIntro.isPlaying == false && inicio == false)
        {
            MusicaMenuLoop.Play();
            inicio = true;
        }
    }
}
