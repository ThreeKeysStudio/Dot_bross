using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using UnityEngine.SocialPlatforms;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ranking : MonoBehaviour
{
    public static ranking instance;
    public Text connect;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
       
        
        LogIn();
    }

    public void LogIn()
    {
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                connect.text = "Conectado";
            }
            else
            {
                connect.text = "desconectado";
            }
        });
    }
    public void enviarPuntuacion(int p)
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(PlayerPrefs.GetInt("best"), "CgkInqzcqNsHEAIQAQ", success => { });
        }
    }

    public void mostrarRanking()
    {
            PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkInqzcqNsHEAIQAQ");
    }
}
