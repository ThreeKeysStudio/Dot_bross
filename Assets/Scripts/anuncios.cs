using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api; ///Para referenciar las librerias de Admob
using System.ComponentModel;
using System; ///Para evitar errores de EventArgs

public class anuncios : MonoBehaviour
{
    private static anuncios instance; ///Para referenciar este script desde otros
    //private string appID = "ca-app-pub-5129558101525248~3674812084"; ///Coloca tu ID de aplicacion aqui

    private RewardedAd rewardedAd;
    private string RewardAD = "ca-app-pub-5129558101525248/8229118853"; ///Coloca tu ID de Anuncio Bonificado aqui


    /// Para evitar que crashee
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        MobileAds.Initialize(initStatus => { }); ///IMPORTANTE INICIALIZAR, NO OLVIDAR ESTA LINEA DE CODIGO

        rewardedAd = new RewardedAd(RewardAD);

        rewardedAd.OnAdLoaded += HandleRewardedAdLoaded; ///Evento cuando carga el anuncio
        rewardedAd.OnAdOpening += HandleRewardedAdOpening; ///Evento cuando es abierto
        rewardedAd.OnAdClosed += HandleRewardedAdClosed; ///Evento cuando es cerrado
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward; ///Evento cuando es visto por el usuario completamente y se entrega la recompensa

        RequestRewardedAd();
    }

    public void RequestRewardedAd() ///Codigo para cargarlo (No para mostrarlo) 
    {
        AdRequest request = new AdRequest.Builder().Build();

        rewardedAd.LoadAd(request);
    }

    public void ShowRewardedAd() ///Para mostrarlo, debe haber sido previamente Cargado
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
        else
        {
            {
                Debug.Log("Reward ad not loaded");
            }
        }
    }
    public void HandleRewardedAdLoaded(object sender, EventArgs args) ///Cargado
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }


    public void HandleRewardedAdOpening(object sender, EventArgs args) ///Abierto
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }


    public void HandleRewardedAdClosed(object sender, EventArgs args) ///Cerrado
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args) ///Visto completo (Entregar Recompensa)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
        recompensa();
        RequestRewardedAd();
    }

    
    public void recompensa()
    {
        int dinero;
        dinero = PlayerPrefs.GetInt("money") + 200;
        PlayerPrefs.SetInt("money", dinero);
    }
}