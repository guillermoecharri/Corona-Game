using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHighscores : MonoBehaviour
{
    [SerializeField] Hiscores hiscores;
    [SerializeField] TextMeshProUGUI score1;
    [SerializeField] TextMeshProUGUI score2;
    [SerializeField] TextMeshProUGUI score3;
    [SerializeField] TextMeshProUGUI score4;
    [SerializeField] TextMeshProUGUI score5;

    void Awake()
    {
        hiscores.LoadHiscores();
        score1.text = "#1 : " + hiscores.GetHiscores()[0];
        score2.text = "#2 : " + hiscores.GetHiscores()[1];
        score3.text = "#3 : " + hiscores.GetHiscores()[2];
        score4.text = "#4 : " + hiscores.GetHiscores()[3];
        score5.text = "#5 : " + hiscores.GetHiscores()[4];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
