using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    float score;
    int toiletPaperGrabbed = 0;
    [SerializeField] float toiletPaperWorth = 10;
    [SerializeField] float displayMultiplier = 10;
    [SerializeField] TextMeshProUGUI scoreboard;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreboard.text = "Score: " + (Mathf.RoundToInt(score * displayMultiplier) + Mathf.RoundToInt(toiletPaperGrabbed * toiletPaperWorth));
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
}
