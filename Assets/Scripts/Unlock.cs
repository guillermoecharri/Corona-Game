using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlock : MonoBehaviour
{
    [SerializeField] Button[] equipButtons = new Button[8];
    [SerializeField] int[] scoreRequirements = new int[8];
    [SerializeField] PlayerSkin playerSkin;

    // Start is called before the first frame update
    void Start()
    {
        Hiscores hiscores = new Hiscores();
        hiscores.LoadHiscores();
        int highestScore = hiscores.GetHiscores()[0];

        for(int i = 0; i < equipButtons.Length; i++)
        {
            if (scoreRequirements[i] > highestScore) //highest hiscore isn't high enough
            {
                equipButtons[i].interactable = false;
            }
            else //highest hiscore is high enough
            {
                equipButtons[i].interactable = true;
            }
        }
    }

    public void EquipSkin(int skinNum)
    {
        playerSkin.EquipSkin(skinNum);
    }
}
