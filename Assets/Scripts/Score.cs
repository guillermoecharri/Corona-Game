using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    float score;
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
        scoreboard.text = "Score: " + Mathf.RoundToInt(score * displayMultiplier);
    }

    public void Add(float amount)
    {
        score += amount;
    }
}
