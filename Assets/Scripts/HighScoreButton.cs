using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreButton : MonoBehaviour
{
    [SerializeField] GameObject hiscorePanel;

    public void EnableHiscorePanel()
    {
        hiscorePanel.SetActive(true);
    }

    public void DisableHighscorePanel()
    {
        hiscorePanel.SetActive(false);
    }
}
