using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script adds a tint to the background and changes the color of that tint as the score increases.
public class BackgroundTint : MonoBehaviour
{
    [SerializeField] Score scoreboard;
    [SerializeField] SpriteRenderer tint;
    [SerializeField, Range(0, 255)] float intensity;
    [SerializeField] float rateOfChange;
    private const float RGB_MAX = 255;

    // Start is called before the first frame update
    void Start()
    {
        tint.color = new Color(0, 0, 255, 0); //blue but not yet visible
    }

    // Update is called once per frame
    void Update()
    {
        float score = scoreboard.GetScore();
        if(score < rateOfChange * 1) //1. incease the alpha from 0 to "intensity"
        {
            //Debug.Log("Increasing tint's alpha.");
            UpdateColor(0, 0, 255, (intensity * (score / rateOfChange)));
        }
        else if (score < rateOfChange * 2) //2. shift from blue to blue/green
        {
            //Debug.Log("Increasing tint's green.");
            UpdateColor(0, RGB_MAX * ((score - rateOfChange) / rateOfChange), 255, (intensity));
        }
        else if (score < rateOfChange * 3) //3. shift from blue/green to green
        {
            //Debug.Log("Decreasing tint's blue.");
            UpdateColor(0, 255, RGB_MAX * (((rateOfChange * 3) - score) / rateOfChange), intensity);
        }
        else if (score < rateOfChange * 4) //4. shift from green to yellow (increase red)
        {
            UpdateColor(RGB_MAX * ((score - rateOfChange * 3) / rateOfChange), 255, 0, intensity);
        }
        else if (score < rateOfChange * 5) //5. shift from yellow to red (decrease green)
        {
            UpdateColor(255, RGB_MAX * (((rateOfChange * 5) - score) / rateOfChange), 0, intensity);
        }
        else //6. be full red
        {
            UpdateColor(255, 0, 0, intensity);
        }

    }

    private void UpdateColor(float r, float g, float b, float a)
    {
        tint.color = new Color32((byte)r, (byte)g, (byte)b, (byte)a);
    }
}
