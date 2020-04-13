using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSky : MonoBehaviour
{
    [SerializeField] SpriteRenderer sky; //the image that this script will adjust the color of
    [SerializeField] GameObject sunAndMoon; //the object that contains the sun and moon that this script will rotate
    [SerializeField] float secondsPerDay; //rate at which the color will go from 100V to 0V and then back to 100V
    private float secondsPassed;
    
    // Start is called before the first frame update
    void Start()
    {
        secondsPassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        secondsPassed += Time.deltaTime;
        float timeOfDay = (secondsPassed % secondsPerDay) / secondsPerDay; //a value from 0 - 1 representing the time of day.
        float brightness = CalculateBrightness(timeOfDay);
        UpdateSky(brightness);
        UpdateSunAndMoon(timeOfDay);
    }

    //Calculates what the brightness of the day should be like based on the time (how long its been since the level was started).
    private float CalculateBrightness(float timeOfDay)
    {
        //brightness is based off time of day. If time is 0 or 1 then brightness will be 1. The more towards the middle the darker it will be, at timeOfDay = 0.5 brightness will be 0.
        float temp = (0.5f) - timeOfDay;
        float brightness = 2 * (Mathf.Abs(temp));
        return brightness;
    }

    //Adjust the shade of the sky based on the given brightness.
    private void UpdateSky(float brightness)
    {
        //grab the color of the sky
        float h = 0;
        float s = 0;
        float v = 0;
        Color.RGBToHSV(sky.color, out h, out s, out v);

        //adjust v based on the brightness
        v = brightness;
        //Debug.Log("v: " + v);

        //reset the color of the image
        sky.color = Color.HSVToRGB(h, s, v);
    }

    //Adjust the rotation of the sun and moon based on the time of day
    private void UpdateSunAndMoon(float timeOfDay)
    {
        float zRotation = timeOfDay * 360;
        sunAndMoon.transform.rotation = Quaternion.Euler(0, 0, zRotation);
    }
}
