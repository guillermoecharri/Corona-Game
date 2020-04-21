using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    string placement = "rewardedVideo";
    [SerializeField] GameObject deathMenu;
    [SerializeField] GameObject player;
    [SerializeField] GameObject cloud;
    [SerializeField] GameObject continueButton;

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
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            //StartCoroutine(WaitTimer());

            //reward
            deathMenu.SetActive(false);
            continueButton.GetComponent<Button>().interactable = false;
            player.GetComponent<PlayerController>().SetAlive(true);
            player.GetComponent<PlayerHealth>().SetFullHealth();
            cloud.GetComponent<CoronaCloudController>().PlayerRevived();

            //Destroy(gameObject);
        }
        else if(showResult == ShowResult.Failed){
            Debug.Log("Ads Failed");
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsReady(string placementId)
    {
    }

    /*void OnDestroy()
    {
        Debug.Log("DestroyAdController");
        myButton.onClick.RemoveListener(ShowRewardedVideo);
        Advertisement.RemoveListener(this);
    }*/
    void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

    /*IEnumerator WaitTimer()
    {

        yield return new WaitForSeconds(1);
    }*/
    }
