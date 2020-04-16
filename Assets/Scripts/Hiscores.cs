using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiscores : MonoBehaviour
{
    private int[] hiscores = new int[5];

    public int[] GetHiscores()
    {
        return hiscores;
    }

    public void SetHiscores(int[] hiscores)
    {
        this.hiscores = hiscores;
    }

    public void SetNew()
    {
        hiscores = new int[] { 0, 0, 0, 0, 0 };
    }

    public void LoadHiscores()
    {
        SaveData data = SaveSystem.LoadHiscores();
        hiscores = data.hiscores;
    }

    public void AddToHiscores(int score)
    {
        for (int i = 0; i < hiscores.Length; i++)
        {
            if(hiscores[i] < score)
            {
                int temp = hiscores[i];
                hiscores[i] = score;
                score = temp;
            }
        }
    }
}
