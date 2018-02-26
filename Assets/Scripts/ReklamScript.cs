using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReklamScript : MonoBehaviour {
    private InterstitialAd reklamObjesi;
    void Start()
    {
        BannerView reklamObjesi = new BannerView("************************", adSize: AdSize.SmartBanner, position: AdPosition.Top);
        AdRequest reklamiAl = new AdRequest.Builder().Build();
        reklamObjesi.LoadAd(reklamiAl);
    }
}

