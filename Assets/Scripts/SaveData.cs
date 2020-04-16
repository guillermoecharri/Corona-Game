using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int[] hiscores;
    public int skinNum;

    public SaveData (Hiscores hiscores)
    {
        this.hiscores = hiscores.GetHiscores();
    }

    public SaveData (PlayerSkin playerSkin)
    {
        this.skinNum = playerSkin.GetSkinNum();
    }

    public SaveData()
    {
        this.hiscores = new int[] { 0, 0, 0, 0, 0 };
        this.skinNum = 0;
    }
}
