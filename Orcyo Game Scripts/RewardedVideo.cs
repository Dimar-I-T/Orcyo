/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedVideo : MonoBehaviour
{

    string gameIdGP = "3883299";
    string myPlacementId = "rewardedVideo";

    public GameObject didNotFinishTheAd;
    public GameObject NotReadyAtTheMoment;
    public GameObject UnknownError;

    public static bool Error1;
    public static bool Error2;
    public static bool Error3;

    public static bool IklanKeSkip;
    public static bool tombolAktif = true;

    public static int jumlahAngka;
    public int angkaMaksimalTambahEnergi;

    public GameObject tombolTambahEnergi;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameIdGP, false);

        Advertisement.AddListener(this);
    }

    private void Update()
    {
        // Didn't Finish the ad Error
        if (Error1)
        {
            didNotFinishTheAd.SetActive(true);
            Error2 = false;
            Error3 = false;
        }else if (!Error1)
        {
            didNotFinishTheAd.SetActive(false);
        }

        // Not Ready at The Moment Error
        if (Error2)
        {
            NotReadyAtTheMoment.SetActive(true);
            Error1 = false;
            Error3 = false;
        }else if (!Error2)
        {
            NotReadyAtTheMoment.SetActive(false);
        }

        // Unknown Error
        if (Error3)
        {
            UnknownError.SetActive(true);
            Error2 = false;
            Error1 = false;
        }else if (!Error3)
        {
            UnknownError.SetActive(false);
        }

        // Jika jumlahAngka masih kurang sama dengan 2 maka tombol masih aktif
        if(tombolAktif == true)
        {
            tombolTambahEnergi.SetActive(true);
        }else if(tombolAktif == false)
        {
            tombolTambahEnergi.SetActive(false);
        }
    }

    public void ShowRewardedVideo()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(myPlacementId))
        {
            Advertisement.Show(myPlacementId);
        }
        else
        {
            Error2 = true;
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            jumlahAngka++;
            duaenergi.Energi += 1;
            empatenergi.Energi += 1;
            satuenergi.Energi += 1;
            if(jumlahAngka >= angkaMaksimalTambahEnergi)
            {
                tombolAktif = false;
            }else if(jumlahAngka == 0)
            {
                tombolAktif = true;
            }
        }
        else if (showResult == ShowResult.Skipped)
        {
            Error1 = true;
            IklanKeSkip = true;
        }
        else if (showResult == ShowResult.Failed)
        {
            Error3 = true;
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == myPlacementId)
        {
            // Optional actions to take when the placement becomes ready(For example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

    public void Error1Close()
    {
        Error1 = false;
    }

    public void Error2Close()
    {
        Error2 = false;
    }

    public void Error3Close()
    {
        Error3 = false;
    }

}*/
