using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    float score;
    Hiscores hiscores = new Hiscores();
    int toiletPaperGrabbed = 0;
    [SerializeField] float toiletPaperWorth = 10;
    [SerializeField] float displayMultiplier = 10;
    [SerializeField] TextMeshProUGUI scoreboard;
    [SerializeField] TextMeshProUGUI scoreboardDeathMenu;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        hiscores.LoadHiscores();
    }

    // Update is called once per frame
    void Update()
    {
        string stringScore = ((score * displayMultiplier) + (toiletPaperGrabbed * toiletPaperWorth)).ToString("0000000");
        scoreboard.text = "Score: " + stringScore;
        scoreboardDeathMenu.text = "Score: " + stringScore;
    }

    public void Add(float amount)
    {
        score += amount;
    }

    public float GetScore()
    {
        return score;
    }

    public void AddToiletPaper(int amount)
    {
        toiletPaperGrabbed += amount;
    }

    public void SaveScore()
    {
        hiscores.AddToHiscores(Mathf.RoundToInt(score * displayMultiplier));
        SaveSystem.SaveHiscores(hiscores);
    }
}
