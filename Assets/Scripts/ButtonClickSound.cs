using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    public void PlayButtonSound()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
    }
}
