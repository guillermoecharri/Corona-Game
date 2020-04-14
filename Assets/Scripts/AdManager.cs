using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    string placement = "rewardedVideo";
    [SerializeField] GameObject deathMenu;
    [SerializeField] GameObject player;
    [SerializeField] GameObject cloud;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize("3552890", true);

    }

    public void ShowAd(string p)
    {
        Advertisement.Show(p);
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Temp");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            //reward
            deathMenu.SetActive(false);
            player.GetComponent<PlayerController>().SetAlive(true);
            player.GetComponent<PlayerHealth>().SetFullHealth();
            cloud.GetComponent<CoronaCloudController>().PlayerRevived();
        }
        else if(showResult == ShowResult.Failed){
            Debug.Log("Ads Failed");
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Temp");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Temp");
    }
}
