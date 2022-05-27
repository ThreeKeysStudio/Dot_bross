using UnityEngine;
using GoogleMobileAds.Api;

public class iniciaAnuncios : MonoBehaviour
{
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
    }
}
